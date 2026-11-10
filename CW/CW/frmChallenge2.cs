using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmChallenge2 : BaseForm


    {
        public frmChallenge2()
        {
            InitializeComponent();
        }

        #region Form variables
        // variables associated with the actual layout of the gates and buttons
        private bool outputConnected = false;
        private int connections = 0;
        private Control connectionStart;
        private Control connectionEnd;
        private List<Control[]> connectedObjects = new List<Control[]> { };

        // variables associated with the movement of gates
        private bool dragging = false;
        private int curPosX, curPosY;
        private Point initialPos;

        // variables associated with the game aspect of the form
        private int noOfAttempts = 0;
        private int score = 0;
        private List<LogicGateQuestion> questions = new List<LogicGateQuestion> { };
        #endregion
        #region Form event listeners

        // event listeners for all picture boxes i.e. gates
        private void pictMouseDown(object sender, MouseEventArgs e)
        {
            // validates that a picture box has sent the event and assigns it to the local variable clickPictureBox - needed to be able to view only the current picture box's tag
            if (e.Button == MouseButtons.Right && sender is PictureBox clickedPictureBox)
            {
                // sets the picture boxes tag to dragging to differentiate it from other picture boxes; ensure that moving other another picture box does not cause it to drag when not required
                clickedPictureBox.Tag = "dragging";

                // set the current position of the cursor so that the difference after movement can be calculated in the MouseMove method, and set initialPos so that the picture box can be rolled back if necessary
                curPosX = Cursor.Position.X;
                curPosY = Cursor.Position.Y;
                initialPos = clickedPictureBox.Location;
            }
        }

        // event listener attached to all gates to update their position when cursor moves while dragging
        private void pictMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is PictureBox clickedPictureBox)
            {
                // if this is the picture box that had the mouse down on it in the previous method
                if (clickedPictureBox.Tag as string == "dragging")
                {
                    // set dragging equal to true so that the form can differentiate from just a regular click; mouse up is executed after click, 
                    // so the check will be done in Click when the mouse is raised and the logic will not executed, then dragging will be set back to false in MouseUp
                    dragging = true;

                    // calculate and add on the difference in cursor position from the last time MouseMove was executed
                    clickedPictureBox.Left += Cursor.Position.X - curPosX;
                    curPosX = Cursor.Position.X;
                    clickedPictureBox.Top += Cursor.Position.Y - curPosY;
                    curPosY = Cursor.Position.Y;
                }
            }

            // cause pnlBoundary to redraw any arrows between gates after a movement occurs to prevent ghosting
            pnlBoundary.Invalidate();
        }

        // remove dragging attribute when mouse is raised
        private void pictMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is PictureBox clickedPictureBox)
            {
                // set dragging back to false, so that if the picture box is clicked on again without any dragging then the regular click logic will execute
                dragging = false;

                // reset the picture boxes tag
                clickedPictureBox.Tag = "";

                // if the picture box is not contained within the panel after the movement, i.e. doesn't intersect with it, reset the picture box's position
                if (!CheckIntersection(clickedPictureBox)) clickedPictureBox.Location = initialPos;
            }
        }

        // event listener for btnsignal being clicked to connect it to other gates
        private void btnSignal_MouseClick(object sender, MouseEventArgs e)
        {
            // if btnSignal is the first control to be clicked on, continue as normal. else, output an error as btnSignal cannot take inputs
            if (connectionStart == null) gateClick(sender, e);
            else MessageBox.Show("Sorry, you cannot end a connection at the signal button.");
        }

        // ditto but for btnoutput
        private void btnOutput_MouseClick(object sender, MouseEventArgs e)
        {
            // if btnOutput is the second control to be clicked on, continue as normal. else, output an error as btnOutput cannot give outputs
            if (connectionStart != null) { gateClick(sender, e); }
            else { MessageBox.Show("Sorry, you cannot start a connection at the output button."); }
        }

        // log out and show login form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin newLogin = new frmLogin();
            newLogin.Show();
            this.Hide();
        }

        // show main menu
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu newMainMenu = new frmMainMenu();
            newMainMenu.Show();
            this.Hide();
        }

        // show help form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp2 newHelp = new frmHelp2();
            newHelp.Show();
        }

        // start the game by allowing interaction and loading questions
        private void btnStart_Click(object sender, EventArgs e)
        {
            // populate the questions list
            LoadQuestionsFromCSV(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\LogicGateQuestions.txt");
            score = 0;
            lblScore.Text = "Score: 0";

            // load the first question
            DisplayQuestion();

            // hide the start button to prevent the user breaking the game by clicking it again
            btnStart.Visible = false;
            btnSkip.Enabled = true;

            // add event listener to allow user to evaluate the circuits they build by pressing 'C'
            KeyPress += new KeyPressEventHandler(frmChallenge2_KeyPress);
        }

        // skip a question by displaying the next one without evaluating score
        private void btnSkip_Click(object sender, EventArgs e)
        {
            ProceedToNextQuestionOrStopGame();
        }

        // event listener that connects two gates together when they're clicked consecutively
        private void gateClick(object sender, MouseEventArgs e)
        {
            // gates can only be connected by left clicking
            if (e.Button != MouseButtons.Left) return;

            // ensure that the click was not a result of the user moving a gate
            if (sender is PictureBox || sender is Button && !dragging)
            {
                
                Control clickedItem = (Control)sender;
                
                // if this is the first gate that the user has clicked on, set it to be the beginning of a new connection
                if (connectionStart == null)
                {
                    connectionStart = clickedItem;
                    connectionStart.BackColor = Color.Orange;
                }
                // if this is the second gate that the user has clicked on and it's not the same one they clicked on the first time
                else if (clickedItem != connectionStart)
                {
                    // set it to be the end of a new connection
                    connectionEnd = clickedItem;
                    // to prevent the user from cheating, prevent direct connections between the signal generator and the output
                    if (connectionStart == btnSignal && connectionEnd == btnOutput 
                        || connectionEnd == btnSignal && connectionStart == btnOutput) 
                    { MessageBox.Show("Sorry, you cannot connect the signal generator directly to the output"); }

                    else
                    {
                        connectionEnd.BackColor = Color.Red;

                        // create a new array to represent the connection
                        Control[] pictureBoxesToAdd = new Control[] { connectionStart, connectionEnd };

                        // check that there is no existing connection between the two gates selected
                        bool alreadyConnected = TryRemoveConnection(connectionStart, connectionEnd);

                        
                        if (!alreadyConnected)
                            // all gates can only give one output. if this output is used, display an error
                            if (connectionStart is Gate && ((Gate)connectionStart).connectedFrom == true) MessageBox.Show("Sorry, you can't connect this gate to another as its output channel is already being used.");

                            // all gates can only take one or two inputs. if these inputs are being used, display an error message.                          
                            else if (connectionEnd is Gate && ((Gate)connectionEnd).activeConnectionsTo >= ((Gate)connectionEnd).MaxConnectionsTo || connectionEnd == btnOutput && outputConnected) MessageBox.Show("Sorry, the end gate already has the maximum number of inputs.");

                            // otherwise, this is a valid connection
                            else
                            {
                               
                                connections++;
                                connectedObjects.Add(pictureBoxesToAdd);

                                // set the appropriate values for each object;
                                // for the start of the connection, set it so that its output is being used. for the end, set it so that another input is used. if the end is the output, set it so that its input is already used
                                if (connectionStart is Gate) { ((Gate)connectionStart).connectedFrom = true; }
                                if (connectionEnd is Gate) { ((Gate)connectionEnd).activeConnectionsTo++; }
                                if (connectionEnd == btnOutput) { outputConnected = true; }

                                // display the new connections value
                                UpdateConnectionsLabel();
                            }
                    }
                    
                    // regardless of the outcome, reset the colours of the gates that were clicked to ensure minimal confusion after a connection attempt
                    ResetConnectionSelection();
                }
            }

            pnlBoundary.Invalidate();
        }

        // evaluate the circuit when c is pressed
        private void frmChallenge2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // as written in the help form, c executes the circuit
            if (e.KeyChar == 'c' || e.KeyChar == 'C')
            {
                // to prevent users from cheating, they must first meet the minimum number of connections for the current question
                if (connections < questions[0].MinimumConnections) { MessageBox.Show("Meet the minimum number of connections first"); return; }

                // get the value that would be expected from the current circuit set-up
                bool resultingValue = EvaluateCircuitReturn();
                btnOutput.BackColor = (resultingValue) ? Color.Green : Color.Red; 

                if (resultingValue == questions[0].CorrectReturn)
                {
                    // user has produced the correct output
                    score += CheckAttempts();
                    lblScore.Text = "Score: " + score;
                    MessageBox.Show("Correct answer!");

                    ProceedToNextQuestionOrStopGame();
                }
                else
                {
                    // user has produced the wrong output, add an attempt and continue question
                    noOfAttempts++;
                    CheckAttemptsColour();
                    lblAttempts.Text = "Attempts: " + noOfAttempts;
                    MessageBox.Show("Incorrect answer. Try again!");
                }
            }
        }

        // prepare the form for the game upon loading
        private void frmChallenge2_Load(object sender, EventArgs e)
        {
            // invoke "doublebuffered" on pnlBoundary; prevent flickering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlBoundary, new object[] { true });
            // populate the questions list
            LoadQuestionsFromCSV(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\LogicGateQuestions.txt");

            // ensure that key presses are intercepted by the form and thus by event listeners
            KeyPreview = true;
        }

        // draw lines between connected gates
        private void pnlBoundary_Paint(object sender, PaintEventArgs e)
        {
            // draw a line for each connection between two gates
            foreach (var connection in connectedObjects)
            {
                // the start and end of a connection are the first and second items in a connection list respectively
                Control from = connection[0];
                Control to = connection[1];

                // calculate the center point of 'from' control relative to pnlBoundary
                Point fromCenter = new Point(from.Left + from.Width / 2, from.Top + from.Height / 2);
                // find the center of the control by finding it's centre's position relative to the form, then convert that point to the position relative to the panel
                fromCenter = pnlBoundary.PointToClient(from.Parent.PointToScreen(fromCenter));
                                
                // calculate the center point of 'to' control relative to pnlBoundary
                Point toCenter = new Point(to.Left + to.Width / 2, to.Top + to.Height / 2);
                toCenter = pnlBoundary.PointToClient(to.Parent.PointToScreen(toCenter));

                // draw the line between the centers
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, fromCenter, toCenter);
                }

                // calculate a midpoint for the arrow
                Point midPoint = new Point((fromCenter.X + toCenter.X) / 2, (fromCenter.Y + toCenter.Y) / 2);
                using (Pen arrowPen = new Pen(Color.Black, 2))
                {
                    // set the line to have an arrow cap
                    arrowPen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);
                    // draw a short arrow line starting from the midpoint
                    Point arrowDirection = new Point(midPoint.X + (toCenter.X - fromCenter.X) / 100, midPoint.Y + (toCenter.Y - fromCenter.Y) / 100);
                    e.Graphics.DrawLine(arrowPen, midPoint, arrowDirection);
                }
            }
        }
        #endregion
        #region Gate logic

        // return the  value gained from executing the current circuit
        private bool EvaluateCircuitReturn()
        {
            foreach (Control[] connectedObjectPair in connectedObjects)
            {
                Control startPoint = connectedObjectPair[0];
                Control endPoint = connectedObjectPair[1];
                // if the output button is directly connected to the signal generator then true will always be returned
                if (endPoint == btnOutput && startPoint == btnSignal) return true;
                // if the output button is at the end point of a connection, begin evaluation of the circuit using the gate that is connected
                // to btnOutput as the start point
                else if (endPoint == btnOutput) return EvaluateGateReturn(startPoint);

            }
            return false;
        }

        // return the value gained from the current gate
        private bool EvaluateGateReturn(Control startingPoint)
        {
            if (startingPoint == null)
            {
                MessageBox.Show("Error: Invalid starting gate.");
                return false;
            }

            // the parameter "startingPoint" describes the starting gate from which the remaining gates branch off
            // as the output is gained from evaluation from right to left, this will ultimately be the end of the connection in a pair of connected gates

            // sets gates to be used if the current gate has two inputs
            Control firstGate = null;
            Control secondGate = null;

            // for each pair of connected gates and buttons on the screen
            foreach (Control[] connectedObjectPair in connectedObjects)
            {
                Control startPoint = connectedObjectPair[0];
                // endPoint is used to describe the end of a connection in any pair, but will end up being startingPoint as the circuit is evaluated from end to start
                Control endPoint = connectedObjectPair[1];      
                // if the current gate has one input and has been connected to the signal button, return the output that the current gate would give if given a single true value
                // this is used to end recursion of the method, as the gates are evaluated right to left and consequently this would be the very left
                if (endPoint == startingPoint && startPoint == btnSignal && ((Gate)endPoint).MaxConnectionsTo == 1) return ((Gate)endPoint).returnValue(true);
                // if the starting point is the end point of a connection
                else if (endPoint == startingPoint)
                    // if the current gate will take only one input only one evaluateGateReturn call must be used
                    if (((Gate)endPoint).MaxConnectionsTo == 1) return ((Gate)endPoint).returnValue(EvaluateGateReturn(startPoint));
                    else
                    {
                        // as btnSignal does not have its own returnValue method unlike gates, a separate check is performed when setting it as the first or second gate connected to startingPoint
                        if (firstGate == null && startPoint == btnSignal) firstGate = btnSignal;
                        else if (startPoint == btnSignal) secondGate = btnSignal;

                        // set the gates on which evaluateGateReturn will be called to continue the evaluation of the circuit
                        // these are the gates which are connected to startingPoint
                        else if (firstGate == null) firstGate = startPoint;
                        else secondGate = startPoint;                 
                        
                        if (secondGate != null) return ((Gate)endPoint).returnValue(firstGate == btnSignal ? true : EvaluateGateReturn(firstGate), secondGate == btnSignal ? true : EvaluateGateReturn(secondGate));

                        // call the returnValue method for the current control using the output results of the two previous gates it is connected to
                        // recursive programming is used to simplify evaluation of the current layout
                        // btnSignal is treated as true
                    }
            }
            // if the whole array has been searched and there is no secondGate yet there is a firstGate, then treat the missing secondGate as false
            if (firstGate != null) return ((Gate)startingPoint).returnValue(firstGate == btnSignal ? true : EvaluateGateReturn(firstGate), false);

            return false;
        }
 
        // prepare the returned gate for addition to the form
        private void CreateNewGate(string gate, int xPosition, int yPosition)
        {

            // create a gate with the appropriate properties using the name of the gate provide in the questions text file
            Gate gateToAdd = ReturnGateToAdd(gate);
            gateToAdd.Location = new Point(xPosition, yPosition);
            gateToAdd.MouseDown += pictMouseDown; // add the appropriate event listeners to the new gate
            gateToAdd.MouseMove += pictMouseMove;
            gateToAdd.MouseUp += pictMouseUp;
            gateToAdd.MouseClick += gateClick;
            gateToAdd.BackColor = Color.LightBlue;
            gateToAdd.Name = "gate_" + gate + "_" + Guid.NewGuid().ToString("N"); // add a unique name to the gate to ensure that checks involving gate names work properly
            Controls.Add(gateToAdd); // add the new gate to the form
            gateToAdd.BringToFront();
        }

        // return the appropriate object based on the name of the gate in the text file
        private Gate ReturnGateToAdd(string gateName)
        {
            Gate gate;
            switch (gateName)
            {
                case "NOT": gate = new NotGate(); break;
                case "BUFFER": gate = new Buffer(); break;
                case "OR": gate = new OrGate(); break;
                case "AND": gate = new AndGate(); break;
                case "NAND": gate = new NAndGate(); break;
                case "XOR": gate = new XOrGate(); break;
                case "XNOR": gate = new XNOrGate(); break;
                case "NOR": gate = new NOrGate(); break;
                default: gate = new Buffer(); break;

            }
            string relativePath = $"Images\\Challenge2\\{gateName}.png"; // instantiate a new gate object and set its image based on the gate name
            string fullPath = Path.Combine(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName, relativePath);

            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"Error: Image file not found for gate {gateName} at path: {fullPath}");
                return gate;
            }

            try
            {
                gate.Image = Image.FromFile(fullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading gate image: " + ex.Message);
            }

            gate.SizeMode = PictureBoxSizeMode.StretchImage;
            gate.Size = new Size(107, 82);
            return gate;
        }

        // remove all gates from the form and update all variables to reflect this change
        private void RemoveAllGates()
        {
            // ensure all states are reset to prevent any errors from states transferring between questions
            dragging = false;
            outputConnected = false;
            connectionStart = null;
            connectionEnd = null;
            connectedObjects = new List<Control[]> { };

            // iterate through all controls and remove those that are gates
            // index is backwards to prevent index shifting issues
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is Gate)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        // remove the connection between two gates if they already exist in connectedObjects
        private bool TryRemoveConnection(Control fromControl, Control toControl)
        {
            for (int i = 0; i < connectedObjects.Count; i++)
            {
                // check the connection in either direction
                if ((connectedObjects[i][0].Name == fromControl.Name && connectedObjects[i][1].Name == toControl.Name) ||
                    (connectedObjects[i][0].Name == toControl.Name && connectedObjects[i][1].Name == fromControl.Name))
                {
                    // remove the connection and update connection count and labels
                    connections--;
                    UpdateConnectionsLabel();
                    ResetGateConnectionStates(connectedObjects[i][0], connectedObjects[i][1]);
                    connectedObjects.RemoveAt(i);
                    

                    return true;
                }
            }
            return false;
        }

        // ensure colours are reset after attempting a connection / disconnection
        private void ResetConnectionSelection()
        {
            // reset selected gate colours to prevent any confusion 
            if (connectionStart != null)
            {
                connectionStart.BackColor = Color.LightBlue;
                connectionStart = null;
            }
            if (connectionEnd != null)
            {
                connectionEnd.BackColor = Color.LightBlue;
                connectionEnd = null;
            }
            btnSignal.BackColor = Color.White;
            btnOutput.BackColor = Color.Red;
        }

        // ensure that the properties of the gates reflect a disconnection
        private void ResetGateConnectionStates(Control start, Control end)
        {
            // if a connection is removed, set the properties of the two gates to values representing this change;
            // freeing the first gates output and removing one of the second gate's inputs
            if (start is Gate) ((Gate)start).connectedFrom = false;
            if (end is Gate) ((Gate)end).activeConnectionsTo--;
            if (start == btnOutput || end == btnOutput) outputConnected = false;
        }

        // ensure that a gate has been dragged onto the panel and nothing else
        private bool CheckIntersection(PictureBox picture)
        {
            if (picture == null || picture.Parent == null)
            {
                MessageBox.Show("Error: Invalid gate or missing parent control.");
                return false;
            }

            Rectangle pictureBoxBounds = picture.Bounds;
            Rectangle panelBounds = pnlBoundary.ClientRectangle;

            // ensure the picture boxes location is correctly aligned with the panel by finding its screen location and converting that to a client location relative to the panel 
            pictureBoxBounds.Location = pnlBoundary.PointToClient(picture.Parent.PointToScreen(picture.Location));

            return panelBounds.Contains(pictureBoxBounds);
        }
        #endregion
        #region Game logic
        // load question from a pre-existing text file and put values into individual question objects
        private void LoadQuestionsFromCSV(string filePath)
        {
            // ensure the questions file exists to prevent the program from crashing
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Error: The questions file was not found.");
                return;
            }

            // create new list to store questions in
            questions = new List<LogicGateQuestion>();
            string[] lines = File.ReadAllLines(filePath);
            // skip the first line; it's a template
            var allQuestions = lines.Skip(1)
                .Select(line =>
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 8)
                    {
                        // validate numeric values with TryParse
                        if (!int.TryParse(parts[4], out int gold) ||
                            !int.TryParse(parts[5], out int silver) ||
                            !int.TryParse(parts[6], out int bronze) ||
                            !int.TryParse(parts[7], out int minConnections))
                        {
                            return null;
                        }

                        // parse the rest of the parts safely
                        try
                        {
                            return new LogicGateQuestion
                            {
                                Title = parts[0],
                                Text = parts[1],
                                Difficulty = parts[2],
                                CorrectReturn = Convert.ToBoolean(parts[3]),
                                TargetAttempts = new Dictionary<string, int>
                        {
                            { "Gold", gold },
                            { "Silver", silver },
                            { "Bronze", bronze }
                        },
                                MinimumConnections = minConnections,
                                AvailableGates = parts.Skip(8).ToList()
                            };
                        }
                        catch (Exception ex)
                        {                         
                            MessageBox.Show("Error parsing a question: " + ex.Message);
                            return null;
                        }
                    }
                    return null;
                })
                .Where(q => q != null)
                .ToList();

            // shuffle the question list after loading questions
            ShuffleQuestions(allQuestions);
        }

        // randomise question order to prevent cheating, then select a set amount of questions from each difficulty
        private void ShuffleQuestions(List<LogicGateQuestion> allQuestions)
        {
            // shuffle the questions list
            Random rand = new Random();
            allQuestions = allQuestions.OrderBy(x => rand.Next()).ToList();

            // categorise shuffled questions by difficulty
            var easyQuestions = allQuestions.Where(q => q.Difficulty == "Easy").ToList();
            var mediumQuestions = allQuestions.Where(q => q.Difficulty == "Medium").ToList();
            var hardQuestions = allQuestions.Where(q => q.Difficulty == "Hard").ToList();
            var veryHardQuestions = allQuestions.Where(q => q.Difficulty == "Very Hard").ToList();

            // randomly select questions from the shuffled lists by difficulty
            questions.AddRange(easyQuestions.OrderBy(x => rand.Next()).Take(4));
            questions.AddRange(mediumQuestions.OrderBy(x => rand.Next()).Take(3));
            questions.AddRange(hardQuestions.OrderBy(x => rand.Next()).Take(2));
            questions.AddRange(veryHardQuestions.OrderBy(x => rand.Next()).Take(1));
        }

        // display a question by updating control values and loading all the gates required for that question
        private void DisplayQuestion()
        {
            // reset the state of the game to ensure that nothing is carried over to the next question
            connections = 0;
            UpdateConnectionsLabel();
            RemoveAllGates();
            noOfAttempts = 0;
            lblAttempts.Text = "Attempts: 0";
            CheckAttemptsColour();
            // hard-coded position that is updated as gates are added
            int xPosition = 12;
            int yPosition = 539;
          
            if (questions.Count > 0)
            {
                var question = questions[0]; // get the first question

                // set each controls value to represent the values in the new question
                lblTitle.Visible = true;
                lblTitle.Text = question.Title;
                txtQuestion.Text = question.Text;
                CheckDifficulty(question.Difficulty);
                CheckDesiredOutput(question.CorrectReturn);
                foreach (string gate in question.AvailableGates)
                {
                    CreateNewGate(gate, xPosition, yPosition);
                    // increment the x position by the size of a gate plus some padding
                    xPosition += 113;
                }
            }
            else
            {
                // no more questions to display
                txtQuestion.Text = "No more questions available.";
                // remove event listener to prevent interaction after the game is finished
                KeyPress -= new KeyPressEventHandler(frmChallenge2_KeyPress);
            }
        }

        // update the connections label to reflect changes in connections
        private void UpdateConnectionsLabel()
        {
            lblConnections.Text = "Connections: " + connections;
            // set the label colour to indicate whether the user has met the minimum requirement of connections
            lblConnections.ForeColor = connections < questions[0].MinimumConnections ? Color.Red : Color.Green;
        }

        // set the difficulty label's colour depending on the question's difficulty
        private void CheckDifficulty(string difficulty)
        {
            lblDifficulty.Visible = true;
            lblDifficulty.Text = difficulty;
            // set the label text and colour to the appropriate values
            switch (difficulty)
            {
                case "Easy": lblDifficulty.ForeColor = Color.LimeGreen; return;
                case "Medium": lblDifficulty.ForeColor = Color.Orange; return;
                case "Hard": lblDifficulty.ForeColor = Color.Red; return;
                case "Very Hard": lblDifficulty.ForeColor = Color.Gray; return;
            }
        }

        // get the value by which the score will be multiplied depending on the difficulty of the question
        private int GetMultiplier()
        {
            // return the value that the user's score will be multiplied by depending on the difficulty of the current question
            switch (questions[0].Difficulty)
            {
                case "Easy": return 1;
                case "Medium": return 2;
                case "Hard": return 3;
                case "Very Hard": return 4;
                default: return 1;
            }
        }

        // return the appropriate score depending on the difficulty of the question and the number of attempts
        private int CheckAttempts()
        {
            // return the appropriate score based on the number of attempts the user needed to solve the question
            if (noOfAttempts <= questions[0].TargetAttempts["Gold"]) return 4 * GetMultiplier();
            else if (noOfAttempts <= questions[0].TargetAttempts["Silver"]) return 3 * GetMultiplier();
            else if (noOfAttempts <= questions[0].TargetAttempts["Bronze"]) return 2 * GetMultiplier();
            else return 1 * GetMultiplier();
        }

        // modify btnDesireOutput's colour to indicate the expected output for that question
        private void CheckDesiredOutput(bool output)
        {
            // set the desired output indicator to the appropriate colour so that the user knows what they're attempting to return
            btnDesiredOutput.BackColor = (output) ? Color.Green : Color.Red;
        }

        // change the attempt label's colour depending on the number of attempts accumulated
        private void CheckAttemptsColour()
        {
            // set the attempt counter to the appropriate colour to indicate to the user how well they're performing
            var targetAttempts = questions[0].TargetAttempts;
            if (noOfAttempts <= targetAttempts["Gold"]) lblAttempts.ForeColor = Color.Gold;
            else if (noOfAttempts <= targetAttempts["Silver"]) lblAttempts.ForeColor = Color.Silver;
            else if (noOfAttempts <= targetAttempts["Bronze"]) lblAttempts.ForeColor = Color.Brown;
            else lblAttempts.ForeColor = Color.Gray;
        }

        // check if there are questions left, then display the next one or stop the game
        private void ProceedToNextQuestionOrStopGame()
        {
            // remove the current question if one exists
            if (questions.Count > 0)
            {
                questions.RemoveAt(0);
            }

            if (questions.Count > 0)
            {
                DisplayQuestion();
            }
            else
            {
                StopGame();
            }
        }

        // stop the game by preventing interaction, then check if the user achieved the minimum score
        public void StopGame()
        {
            txtQuestion.Text = "No more questions available.";
            KeyPress -= new KeyPressEventHandler(frmChallenge2_KeyPress); // disable the execute event listener

            btnSkip.Enabled = false;
            btnStart.Visible = true;
            if (score >= 15)
            {
                MessageBox.Show("Congratulations! You've won the game! Challenge 3 unlocked.");
                CurrentUser.publicCurrentUser.SaveScore(score, 2);
                frmMainMenu newMainMenu = new frmMainMenu();
                newMainMenu.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Sorry, you didn't attain the minimum score of 15. Try again; practice makes perfect.");
                RemoveAllGates();
                score = 0;
                lblScore.Text = "Score: " + score;
                lblDifficulty.Visible = false;
                lblTitle.Visible = false;
                connections = 0;
            }
        }
        #endregion
    }
}
