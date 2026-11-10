using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmChallenge1 : BaseForm
    {
        public frmChallenge1()
        {
            InitializeComponent();
        }

        #region Form variables
        // this TextWriter variable will later be instantiated with a derived TextBoxStreamWriter object to allow for console output to be displayed in the TextBox as well 
        private TextWriter writer = null;
        private List<ProgrammingQuestion> questions;
        private Random random = new Random();
        private int score = 0;
        private int timeTaken = 0;
        #endregion
        #region Form event listeners
        // this method is asynchronous as it contains asynchronous, web-related methods stemming from the webview editor
        // prepare the webview control when form loads
        private async void frmChallenge1_Load(object sender, EventArgs e)
        {
            await PrepareWebViewAndConsole();
        }

        // start the game
        private async void btnStart_Click(object sender, EventArgs e)
        {
            // populate the questions list
            LoadQuestionsFromCSV(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\ProgrammingQuestions.txt");
            score = 0;
            lblScore.Text = "Score: 0";
            await DisplayRandomQuestion();
            // prevent the user from breaking the game's logic by hiding the start button
            btnStart.Visible = false;
            btnExecute.Enabled = true;
            btnReset.Enabled = true;
            btnSkip.Enabled = true;
        }

        // show help form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp1 newHelp = new frmHelp1();
            newHelp.Show();
        }

        // log out and show login form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            tmrChallenge1.Stop();
            frmLogin newLogin = new frmLogin();
            newLogin.Show();
            this.Hide();
        }

        // show main menu
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            tmrChallenge1.Stop();
            frmMainMenu newMainMenu = new frmMainMenu();
            newMainMenu.Show();
            this.Hide();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            // reset the text editor's state to what it was initially
            await wbvwEditor.ExecuteScriptAsync($"editor.setValue(`{questions[0].PrewrittenText}`)");
        }

        // skip the question by loading the next one without evaluating score
        private async void btnSkip_Click(object sender, EventArgs e)
        {
            await ProceedToNextQuestionOrStopGame();
        }

        // compile and execute code input by the user
        private async void btnExecute_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnSkip.Enabled = false;
            // validation to ensure that even if the compilation completely fails, the program doesn't crash
            try
            {
                await CompileAndExecuteCode();
            }
            catch
            {
                MessageBox.Show("There was an error when compiling and executing your code.");
                prgrsCompiling.Value = 0;
                return;
            }
            btnReset.Enabled = true;
            btnSkip.Enabled = true;
        }

        // increment and handle changes in time
        private void tmrChallenge1_Tick(object sender, EventArgs e)
        {
            // increment the time taken by 1, equivalent to 100ms
            timeTaken++;
            lblTimeTaken.Text = "Time Taken: " + (timeTaken / 10.0).ToString("0.0");

            // set the time label to an appropriate colour to allow the user to know how well they're doing
            if (timeTaken < questions[0].TargetTimes["Gold"]) lblTimeTaken.ForeColor = Color.Gold;
            else if (timeTaken < questions[0].TargetTimes["Silver"]) lblTimeTaken.ForeColor = Color.Silver;
            else if (timeTaken < questions[0].TargetTimes["Bronze"]) lblTimeTaken.ForeColor = Color.Brown;
            else lblTimeTaken.ForeColor = Color.Gray;
        }

        #endregion
        #region Compilation and execution logic

        // compiles and executes code provided in string form
        private async Task CompileAndExecuteCode()
        {
            // the SyntaxTree is essentially code that has been processed by CodeAnalysis, and can be used to compile using the Roslyn library
            // create a syntax tree from the user's code
            SyntaxTree syntaxTree = await ReturnSyntaxTreeToCompile();

            if (syntaxTree == null)
            {
                // validation failed, so exit early to prevent the compilation of ill-formatted code
                return;
            }

            // compile said code
            CSharpCompilation compilation = CreateCompilationUnit(syntaxTree);
            // execute said compilation and process the result
            ExecuteCompilationUnit(compilation);
        }

        // processes raw code to be in a format that can be compiled

        private async Task<SyntaxTree> ReturnSyntaxTreeToCompile()
        {
            // clear the previous console output - errors and the program output - to avoid confusion with new input
            txtConsole.Text = "";

            string returnType = questions[0].ReturnType;

            // get the current value of the code editor by executing a js method in the webview, then properly format it
            string editorValue = await wbvwEditor.ExecuteScriptAsync("editor.getValue()");
            editorValue = GetCleanEditorCode(editorValue);

            // if anything is missing from the user's code that is deemed necessary to solve the question, return a null string to indicate an ill-formatted code block
            if (!ValidateUserCode(editorValue))
            {
                txtConsole.Text += "\n Your solution does not meet the required logic structure.";
                return null;
            }

            // concatenate the boilerplate c# code with the user input code, then parse as a syntax tree in order to compile later
            return ReturnBoilerplatedCode(returnType, editorValue);
        }

        // ensure that input code can be compiled by replacing literal escapes with their respective values
        private string GetCleanEditorCode(string rawCode)
        {
            // the string returned from the js console is formatted with the escape characters represented as their actual characters instead of what they represent, 
            // so the quotation marks at the start and end are to be removed and escape characters replaced so that they can be understood by the code parser later
            string editorValue = rawCode.Trim('"')
                                        .Replace("\\\"", "\"")
                                        .Replace("\\r", "\r")
                                        .Replace("\\n", "\n");

            // replace any unicode escapes with the characters they represent, then return that string
            return DecodeUnicodeEscapes(editorValue);
        }

        // replace any unicode escapes provided by the webview editor with their respective characters
        private string DecodeUnicodeEscapes(string input)
        {
            // use regex to replace any string formatted with a / followed by any 4 characters, which represents a unicode escape, with their respective unicode value
            return Regex.Replace(
                input,
                @"\\u([0-9A-Fa-f]{4})",
                match => ((char)Convert.ToInt32(match.Groups[1].Value, 16)).ToString()
            );
        }

        // ensure user has all required variables and methods
        private bool ValidateUserCode(string code)
        {
            // for each set of variables and methods / operators
            foreach (var item in questions[0].RequiredKeywords)
            {
                // if the code does not contain one of the variables
                if (!code.Contains(item.Key))
                {
                    txtConsole.Text += $"Error: Missing required variable '{item.Key}'.";

                    return false;
                }

                // for each method / operator
                foreach (var operation in item.Value)
                {
                    // if the code does not contain the method / operator
                    if (!code.Contains(operation))
                    {
                        
                        txtConsole.Text += $"Error: Missing required operation '{operation}' for '{item.Key}'.";

                        return false;
                    }
                }
            }
            // code contains all necessary elements
            return true;
        }

        // put the user's code into a ready-made template to be compiled
        private SyntaxTree ReturnBoilerplatedCode(string type, string code)
        {
            // use string interpolation to add all necessary syntax to the user's code
            string template = $@"
        using System;
        using System.Linq;
        namespace UserCode
        {{
            public class Code
            {{
                public {type} ExecuteCode({type} gruh)
                {{
                    {code}
                }}
            }}
        }}";

            // parse the text with the added syntax to form a syntaxtree
            return CSharpSyntaxTree.ParseText(template);
        }

        // compile the provided syntaxtree for later execution
        private CSharpCompilation CreateCompilationUnit(SyntaxTree syntaxTree)
        {
            // define other necessary objects for compilation - a temporary file name to store compiled code and the location of portable assemblies 
            // MetadataReference objects are needed to provide context for compiling code
            // typeof(object).Assembly.Location adds a reference to mscorlib.dll (which contains core system types like object, string, etc.).
            // typeof(Enumerable).Assembly.Location references System.Linq.dll, which contains LINQ extension methods

            string assemblyName = Path.GetRandomFileName();
            MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
            };

            // update the progress bar to reflect the progress in compilation
            prgrsCompiling.Value = 33;

            // create a compilation unit using Roslyn's API
            return CSharpCompilation.Create(
                assemblyName, // the randomly generated name for the compiled dll
                syntaxTrees: new[] { syntaxTree }, // the parsed c# code that will be compiled
                references: references, // assembly references required for compilation - previously declared
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)); // compile as a dll
        }

        // execute the provided compilation unit
        private void ExecuteCompilationUnit(CSharpCompilation compilation)
        {

            prgrsCompiling.Value = 66;

            // create an empty memory stream to store compiled code
            using (var ms = new MemoryStream())
            {
                // emit (compile) code into memory stream
                EmitResult result = compilation.Emit(ms);

                // if compilation unsuccessful
                if (!result.Success)
                {
                    HandleCompilationErrors(result);
                }
                else
                {
                    GetResultFromCompilation(ms);
                }
            }
        }

        // show any errors provided in the output textbox
        private void HandleCompilationErrors(EmitResult result)
        {
            // handle any compilation errors
            IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError || // treat warnings as errors
                diagnostic.Severity == DiagnosticSeverity.Error); // actual errors

            // output each error for the user to see and consequently amend
            foreach (Diagnostic diagnostic in failures)
            {
                Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
            }

            // reset the progress bar
            prgrsCompiling.Value = 0;
        }

        // get the value that would be gained from executing the user's code
        private void GetResultFromCompilation(MemoryStream ms)
        {
            // move stream position to the start before reading
            ms.Seek(0, SeekOrigin.Begin);

            // convert the memory stream to a byte array and load it as an assembly
            Assembly assembly = Assembly.Load(ms.ToArray());

            // retrieve the "UserCode.Code" type from the dynamically compiled assembly
            Type type = assembly.GetType("UserCode.Code");

            // create an instance of the retrieved type (i.e., instantiate the compiled class)
            object obj = Activator.CreateInstance(type);

            // define a timeout limit (e.g., 5 seconds)
            int timeoutMs = 5000;

            // execute the method asynchronously with a timeout
            Task<string> executionTask = Task.Run(() =>
            {
                try
                {
                    return (string)type.InvokeMember("ExecuteCode",
                        BindingFlags.Default | BindingFlags.InvokeMethod,
                        null,
                        obj,
                        new object[] { "string" });
                }
                catch (Exception ex)
                {
                    return $"Execution Error: {ex.Message}";
                }
            });

            prgrsCompiling.Value = 100;

            // wait for the execution to complete within the timeout
            if (!executionTask.Wait(timeoutMs))
            {
                Console.Error.WriteLine("Execution timed out.");
                System.Threading.SynchronizationContext.Current.Post((_) =>
                    CheckReturn("Execution timed out.")
                , null);
            }
            else
            {
                // Get the result and pass it to CheckReturn
                string returned = executionTask.Result;
                System.Threading.SynchronizationContext.Current.Post((_) =>
                    CheckReturn(returned)
                , null);
            }

            prgrsCompiling.Value = 0;
        }

        #endregion
        #region Game logic

        // prepare the webview control for modification, and attach console output to the textbox
        private async Task PrepareWebViewAndConsole()
        {
            // explicitly trigger initialisation of wbvwEditor's CoreWebView2 in order to be able to execute more operations;
            // when the async task completes then the CoreWebView2 property will be available for use (non-null)
            // this is analogous to simply opening a browser
            prgrsCompiling.Value = 0;
            await wbvwEditor.EnsureCoreWebView2Async();
            prgrsCompiling.Value = 25;
            // load the HTML file found in the MonacoCodeEditor folder which contains the code editor in wbvwEditor
            // wbvwEditor essentially acts like a browser in which the Monaco site is displayed
            wbvwEditor.Source = new Uri(Path.Combine(Application.StartupPath, @"MonacoCodeEditor\index.html"));
            prgrsCompiling.Value = 75;

            // instantiate the writer
            writer = new TextBoxStreamWriter(txtConsole);
            // redirect Console's stream to the TextBoxStreamWriter, which has an overriden Write method
            Console.SetOut(writer);
            Console.SetError(writer);
            prgrsCompiling.Value = 100;
            Console.WriteLine("Loading successful!");
            btnStart.Enabled = true;
        }

        // load all questions from a pre-existing text file and place values into individual question objects
        private void LoadQuestionsFromCSV(string filePath)
        {
            // validate that the file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Error: the questions file was not found.");
                return;
            }

            // create new list to store questions in
            questions = new List<ProgrammingQuestion>();
            string[] lines = File.ReadAllLines(filePath);
            // skip the first line; it's a template
            foreach (var line in lines.Skip(1))
            {
                // split the line at the hashtags
                var parts = line.Split('#');

                // if the line doesn't contain the expected number of elements
                if (parts.Length != 8)
                {
                    MessageBox.Show("Error: The format of a line in the text file is incorrect.");
                    continue; // skip this line
                }

                // create a new question object populate with information from the line
                var question = new ProgrammingQuestion
                {
                    Text = parts[0],
                    ReturnType = parts[1],
                    CorrectReturn = parts[2],
                    PrewrittenText = parts[3],
                    TargetTimes = { { "Gold", Convert.ToInt32(parts[4]) }, { "Silver", Convert.ToInt32(parts[5]) }, { "Bronze", Convert.ToInt32(parts[6]) } },
                    RequiredKeywords = ParseRequiredKeywords(parts[7])

                };
                // add the question to the list
                questions.Add(question);

            }
        }

        // create dictionaries from the string in the text file representing what variables and methods are required for each question
        private Dictionary<string, List<string>> ParseRequiredKeywords(string requiredKeywordsString)
        {
            // required keywords are stored as a dictionary, with required variables as keys and expected methods / operators as values
            var keywordDictionary = new Dictionary<string, List<string>>();

            // each variable - methods pair is separated by a tilde
            string[] requiredKeywordsSections = requiredKeywordsString.Split('~');


            foreach (string section in requiredKeywordsSections)
            {
                // each method / operator is separated by a comma
                var parts = section.Split(',');
                if (parts.Length > 1)
                {
                    // create a new dictionary, with the first part as the key and the list of methods / operators as the list
                    keywordDictionary.Add(parts[0], parts.Skip(1).ToList());
                }
                else
                {
                    MessageBox.Show("Error: Required keywords are not properly formatted.");
                }
            }
            return keywordDictionary;
        }

        // display a question in txtQuestion
        private async Task DisplayRandomQuestion()
        {

            ShuffleQuestions(); // shuffle the questions list
            var question = questions[0]; // get the first question
            txtQuestion.Text = question.Text.Replace("\\n", Environment.NewLine); // replace each \n in the text with an actual new line
            await wbvwEditor.ExecuteScriptAsync($"editor.setValue(`{questions[0].PrewrittenText}`)"); // set the editor's text to equal the current question's prewritten code
            timeTaken = 0;
            tmrChallenge1.Start();
        }

        // randomise question order to prevent cheating by memorising answers
        private void ShuffleQuestions()
        {
            // shuffle the questions list using Fisher-Yates algorithm
            for (int i = questions.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                var temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }
        }

        // ensure that the output gained from executing the user's code corresponds to the one expected for that question
        private async void CheckReturn(string returned)
        {
            Console.WriteLine($"Your output was '{returned}'");
            // if the user's generated output matches the expected output
            if (returned == questions[0].CorrectReturn)
            {
                // user has achieved the correct output
                score += CheckTime(timeTaken);
                lblScore.Text = "Score: " + score;
                MessageBox.Show("Correct answer!");

                await ProceedToNextQuestionOrStopGame();
            }
            else
            {
                // user has not achieved the correct output
                MessageBox.Show("Incorrect answer. Try again!");
            }

        }

        // return the appropriate score depending on the user's time
        private int CheckTime(int time)
        {
            if (time <= questions[0].TargetTimes["Gold"]) return 4;
            else if (time <= questions[0].TargetTimes["Silver"]) return 3;
            else if (time <= questions[0].TargetTimes["Bronze"]) return 2;
            else return 1;
        }

        // check if there are questions left, and either show the next question or handle ending the game
        private async Task ProceedToNextQuestionOrStopGame()
        {
            // ensure that there are questions to remove to prevent any errors
            if (questions.Count > 0)
            {
                questions.RemoveAt(0);
            }
            // stop timer and reset the time
            tmrChallenge1.Stop();
            timeTaken = 0;

            // either load the next question or end the game
            if (questions.Count > 0)
            {
                await DisplayRandomQuestion();
            }
            else
            {
                StopGame();
            }
        }

        // stop further interaction, and check if the user achieved the minimum score
        public void StopGame()
        {
            txtQuestion.Text = "No more questions available.";
            btnExecute.Enabled = false; // disable the execute button
            btnReset.Enabled = false;
            btnSkip.Enabled = false;
            btnStart.Visible = true;
            tmrChallenge1.Stop();
            timeTaken = 0;

            // if the user has achieved the minimum required score
            if (score >= 15)
            {
                MessageBox.Show("Congratulations! You've won the game! Challenge 2 unlocked.");
                CurrentUser.publicCurrentUser.SaveScore(score, 1);
                tmrChallenge1.Stop();
                frmMainMenu newMainMenu = new frmMainMenu();
                newMainMenu.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Sorry, you didn't attain the minimum score of 15. Try again; practice makes perfect.");
                score = 0;
                lblScore.Text = "Score: " + score;
                lblTimeTaken.Text = "Time Taken: " + timeTaken;
            }
        }
        #endregion
    }
}
