using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    class User
    {
        #region Private Properties
        private string privateUserUsername = ""
        ;
        private string privateUserPassword = ""
        ;
        private string privateUserFirstname = ""
        ;
        private string privateUserLastname = "";
        private List<int> privateUserScores = new List<int> { 0, 0, 0 };
        private int privateUserAge = 0;
        private bool privateUserIsAdmin = false;
        #endregion
        #region Public Properties
        public string publicUserUsername
        {
            get { return privateUserUsername; }
            set { privateUserUsername = value; }
        }
        public string publicUserPassword
        {
            get { return privateUserPassword; }
            set { privateUserPassword = value; }
        }
        public string publicUserFirstname
        {
            get { return privateUserFirstname; }
            set { privateUserFirstname = value; }
        }
        public string publicUserLastname
        {
            get { return privateUserLastname; }
            set { privateUserLastname = value; }
        }

        public List<int> publicUserScores
        {
            get { return privateUserScores; }
            set
            {
                // valdiate scores have been passed and properly formatted
                if (value == null)
                {
                    MessageBox.Show("Scores cannot be null.");
                    return;
                }
                if (value.Count != 3)
                {
                    MessageBox.Show("Scores array must contain exactly 3 elements.");
                    return;
                }
                // validate each score is non-negative:
                foreach (int score in value)
                {
                    if (score < 0)
                    {
                        MessageBox.Show("Scores cannot be negative.");
                        return;
                    }
                }

                privateUserScores = value;
            }
        }

        public int publicUserAge
        {
            get { return privateUserAge; }
            set { privateUserAge = value; }
        }

        public bool publicUserIsAdmin
        {
            get { return privateUserIsAdmin; }
            set { privateUserIsAdmin = value; }
        }



        #endregion
        #region Constructors
        public User() // blank Constructor
        {
        }
        public User(string username, string password, string firstname, string lastname, List<int> scores, int age, bool isAdmin)
        {
            publicUserUsername = username;
            publicUserPassword = password;
            publicUserFirstname = firstname;
            publicUserLastname = lastname;
            publicUserScores = scores;
            publicUserAge = age;
            publicUserIsAdmin = isAdmin;
        }
        #endregion

        // load users from the UserDetails bin file, then place their details into individual User objects
        public static List<User> LoadUsersBin()
        {
            List<User> myList = new List<User>();
            try
            {
                string binDirectory = Path.Combine(
        new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName,
        "TextFiles", "UserDetails.bin");

                // read all lines from the file using UTF8 encoding.
                string[] encodedLines = File.ReadAllLines(binDirectory, new UTF8Encoding(false));

                foreach (string encodedLine in encodedLines)
                {
                    // skip empty lines
                    if (string.IsNullOrWhiteSpace(encodedLine))
                        continue;

                    // decode the current line
                    string decodedLine = Encoding.UTF8.GetString(Convert.FromBase64String(encodedLine));

                    // split the decoded line into parts
                    string[] userArray = decodedLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // ensure expected number of fields before parsing
                    if (userArray.Length < 9)
                        continue;  

                    string username = userArray[0];
                    string password = userArray[1];
                    string firstname = userArray[2];
                    string lastname = userArray[3];
                    // if score stored invalidly
                    if (!int.TryParse(userArray[4], out int score1) ||
    !int.TryParse(userArray[5], out int score2) ||
    !int.TryParse(userArray[6], out int score3))
                    {
                        continue;
                    }

                    List<int> scores = new List<int> { score1, score2, score3 };

                    // if age stored invalidly
                    if (!int.TryParse(userArray[7], out int age))
                        continue;

                    // if admin marker stored invalidly
                    if (!bool.TryParse(userArray[8], out bool isAdmin))
                        continue;

                    // create a user using the loaded details and add to list
                    User userFromFile = new User(username, password, firstname, lastname, scores, age, isAdmin);
                    myList.Add(userFromFile);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error when looking for the User text file:\n" + e);
            }
            return myList;
        }

        // modify the current user's score, both in memory and in the UserDetails bin file
        public void SaveScore(int newScore, int challengeNumber)
        {
            // ensure valid score
            if (newScore < 0)
            {
                MessageBox.Show("Score cannot be negative.");
                return;
            }

            // ensure valid challenge
            if (challengeNumber < 1 || challengeNumber > 3)
            {
                MessageBox.Show("Invalid challenge number.");
                return;
            }

            try
            {
                string filePath = Path.Combine(
                    new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName,
                    "TextFiles", "UserDetails.bin");

                // read each line from the file
                string[] encodedLines = File.ReadAllLines(filePath, new UTF8Encoding(false));

                // create a list to hold the decoded lines
                List<string> decodedLines = new List<string>();

                // decode line individually
                foreach (string encodedLine in encodedLines)
                {
                    // skip blank lines
                    if (string.IsNullOrWhiteSpace(encodedLine))
                        continue;

                    // decode line 
                    string decodedLine = Encoding.UTF8.GetString(Convert.FromBase64String(encodedLine));
                    decodedLines.Add(decodedLine);
                }

                bool userFound = false;
                // loop through each decoded record and update the score for the matching user.
                for (int i = 0; i < decodedLines.Count; i++)
                {
                    
                    string[] parts = decodedLines[i].Split(',');

                    // check if the record belongs to the current user.
                    if (parts[0] == publicUserUsername)
                    {
                        userFound = true;
                        // get the user's old score.
                        int oldScore = int.Parse(parts[3 + challengeNumber]);

                        // update the score for the specified challenge.
                        parts[3 + challengeNumber] = newScore.ToString();

                        // rebuild the structure
                        decodedLines[i] = string.Join(",", parts);


                        // update the current user's score in memory
                        switch (challengeNumber)
                        {
                            case 1:
                                CurrentUser.publicCurrentUser.publicUserScores[0] = newScore;
                                break;
                            case 2:
                                CurrentUser.publicCurrentUser.publicUserScores[1] = newScore;
                                break;
                            case 3:
                                CurrentUser.publicCurrentUser.publicUserScores[2] = newScore;
                                break;
                            default:
                                break;
                        }

                        // inform the user whether the score was changed
                        if (oldScore != newScore)
                        {
                            MessageBox.Show($"Score updated successfully. Score for Challenge {challengeNumber} was updated from {oldScore} to {newScore}.");
                        }
                        else
                        {
                            MessageBox.Show($"Score remains unchanged. Score for Challenge {challengeNumber} is already {newScore}.");
                        }

                        // since the user is found and updated, exit the loop
                        break;
                    }
                }

                if (!userFound)
                {
                    MessageBox.Show("User not found in the file.");
                    return;
                }

                // re-encode each record separately into Base64.
                List<string> encodedOutput = new List<string>();
                foreach (string decodedLine in decodedLines)
                {
                    string encodedLine = Convert.ToBase64String(Encoding.UTF8.GetBytes(decodedLine));
                    encodedOutput.Add(encodedLine);
                }

                // write the encoded lines back to the file
                File.WriteAllLines(filePath, encodedOutput, new UTF8Encoding(false));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving score: " + ex.Message);
            }
        }


    }


}
