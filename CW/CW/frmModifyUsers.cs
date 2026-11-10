using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmModifyUsers : BaseForm
    {
        public frmModifyUsers()
        {
            InitializeComponent();
            originalFormHeight = Size.Height;
        }

        #region Form variables
        // variables associated with the modification of user data
        private List<User> usersList = User.LoadUsersBin();
        private int currentIndex = 0;
        private User currentUser;
        // used to calculate the required form size to accommodate the warning label
        private int originalFormHeight;
        #endregion
        #region Form event listeners
        // show staff menu form
        private void btnStaffMenu_Click(object sender, EventArgs e)
        {
            frmStaffMenu newForm = new frmStaffMenu();
            newForm.Show();
            this.Hide();
        }
        // show main menu form
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu newForm = new frmMainMenu();
            newForm.Show();
            this.Hide();
        }
        // log out and show login form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin newForm = new frmLogin();
            newForm.Show();
            this.Hide();
        }

        // attach custom caret logic to each textbox, then add all available users to the combo box
        private void frmModifyUsers_Load(object sender, EventArgs e)
        {
            foreach (TextBox currBox in Controls.OfType<TextBox>())
            {
                // since the textboxes are automatically focused on start-up, this ensures that the caret is removed from the start
                // otherwise, the caret would be present until you clicked on the textbox
                currBox.GotFocus += RemoveCaret;
                // bind the methods which update the cursor's position to the event listeners which correspond to the user interacting with the textboxes
                currBox.TextChanged += UpdateCursorPosition;
                currBox.Click += UpdateCursorPosition;
                currBox.KeyDown += UpdateCursorPosition;
                // bind the methods which hide the cursor to the event listeners which correspond to the user leaving the textboxes
                currBox.Leave += StopCursor;

            }

            UpdateList();
        }

        // update the value of all text boxes with the new selected user's data
        private void comboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // change the selected index, then display this change
            currentIndex = comboUsers.SelectedIndex;
            LoadChosenUser(currentIndex);
        }

        // save the user to the UserDetails bin file
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            lblAlert.Visible = false;
            SaveChosenUser();
        }


        private void tmrCursor_Tick(object sender, EventArgs e)
        {
            // invert the visiblity of the cursor every tick
            lblCursor.Visible = !lblCursor.Visible;
        }
        #endregion
        #region User modification logic
        // change all field values to represent the current user's data
        private void LoadChosenUser(int userIndex)
        {
            // set all fields to be their respective values for the current user
            currentUser = usersList[userIndex];
            txtUsername.Text = currentUser.publicUserUsername;
            txtFirstName.Text = currentUser.publicUserFirstname;
            txtLastName.Text = currentUser.publicUserLastname;
            numAge.Value = currentUser.publicUserAge;
            // admins should not have access to passwords for confidentiality
            txtPassword.Text = "";
            chkAdmin.Checked = currentUser.publicUserIsAdmin;
            numScore1.Value = currentUser.publicUserScores[0];
            numScore2.Value = currentUser.publicUserScores[1];
            numScore3.Value = currentUser.publicUserScores[2];
        }

        // save all users to the UserDetails bin file, including the new, updated user
        private void SaveChosenUser()
        {
            string textFileDirectory = Path.Combine(new DirectoryInfo
                        (Environment.CurrentDirectory).Parent.Parent.FullName, "TextFiles", "UserDetails.bin");
            if (!ValidateInput())
            {
                return; // immediately exit if basic validation failed
            }

            // if a non-unique username was entered
            if (!IsUsernameUnique(txtUsername.Text))
            {
                // check if it's because *no* username could be loaded
                if (!File.Exists(textFileDirectory))
                {
                    HandleAlert("The file UserDetails.bin was not found.");
                    return;
                }

                // if the issue is not due to a missing file, display the generic message
                HandleAlert("Username already exists. Choose a different username.");
                return;
            }

            // create a new user with the input details
            var newUser = new User
            {
                publicUserUsername = txtUsername.Text.ToLower(),
                publicUserFirstname = txtFirstName.Text,
                publicUserLastname = txtLastName.Text,
                publicUserPassword = txtPassword.Text,
                publicUserIsAdmin = chkAdmin.Checked,
                publicUserAge = (int)numAge.Value,
                publicUserScores = new List<int> { (int)numScore1.Value, (int)numScore2.Value, (int)numScore3.Value }
            };

            // if no new password has been input by the admin, keep it the same. 
            // else, repeat the hashing process that would occur if a user registered with the same password in frmRegister
            if (txtPassword.Text == "") newUser.publicUserPassword = currentUser.publicUserPassword;
            else newUser.publicUserPassword = HashPassword(txtPassword.Text);

            // modify the user list from the bin file, changing only the current user
            usersList[currentIndex] = newUser;

            // empty the current bin file to ensure that new data doesn't conflict with old
            File.WriteAllBytes(textFileDirectory, Array.Empty<byte>());
            
            // write every user into the now-empty bin file to implement the changed user and ensure old data remains
            foreach (User User in usersList)
            {
                try
                {
                    // append the new user's data to the text file

                    using (var fileStream = new FileStream(textFileDirectory, FileMode.Append, FileAccess.Write))
                    using (var sw = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        string userData = User.publicUserUsername + "," +
                          User.publicUserPassword + "," +
                          User.publicUserFirstname + "," +
                          User.publicUserLastname + "," +
                          User.publicUserScores[0] + "," +
                          User.publicUserScores[1] + "," +
                          User.publicUserScores[2] + "," +
                          User.publicUserAge + "," +
                          User.publicUserIsAdmin +
                          Environment.NewLine; ;

                        string encodedData = Convert.ToBase64String(Encoding.UTF8.GetBytes(userData));
                        sw.WriteLine(encodedData);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving user data: " + ex.Message);
                }
            }
            MessageBox.Show("Information saved successfully.");


            // ensure that the new data shows up in the selection list as well to ensure no human errors occur due to old data showing
            UpdateList();
        }

        // ensure valid values have been input to prevent any errors when loading new details
        private bool ValidateInput()
        {
            // ensure a user was chosen
            if (comboUsers.SelectedIndex <= -1) 
            {
                HandleAlert("Choose a user"); 
                return false; 
            }

            // ensure the admin did not only enter spaces
            if (txtPassword.Text != "" && string.IsNullOrWhiteSpace(txtPassword.Text)) 
            { 
                HandleAlert("If password is not left blank, please enter a new password."); 
                return false; 
            }

            // ensure no fields are blank
            if (string.IsNullOrWhiteSpace(txtUsername.Text.ToLower()) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                HandleAlert("All required fields must be filled.");
                return false;
            }

            // check if there are any commas in the text fields
            if (txtUsername.Text.Contains(",") || txtPassword.Text.Contains(",") || txtFirstName.Text.Contains(",") || txtLastName.Text.Contains(","))
            {
                HandleAlert("Fields must not contain commas.");
                return false;
            }

            // ensure given age is valid
            if (numAge.Value <= 3 || numAge.Value >= 120)
            {
                HandleAlert("Age must be valid (greater than 3 and less than 120).");
                return false;
            }

            // ensure valid scores are input
            if (numScore1.Value < 0 || numScore2.Value < 0 || numScore3.Value < 0)
            {
                HandleAlert("Score must not be less than 0.");
                return false;
            }

            return true;
        }

        // ensure the admin has not input a preexisting user if they've changed the username
        private bool IsUsernameUnique(string username)
        {
            try
            {
                List<User> users = User.LoadUsersBin();

                if (users == null || users.Count == 0) return false;

                // iterate through each line to check for existing usernames
                foreach (User user in users)
                {
                    // check if entered username matches any existing username
                    if (user.publicUserUsername.ToLower() == username.ToLower() && username.ToLower() != currentUser.publicUserUsername.ToLower())
                    {
                        // username already exists
                        return false;
                    }
                }
            }
            catch
            {

                return false;
            }
            // username is unique
            return true;
        }

        // hash password for storage in the bin file
        private string HashPassword(string plainPassword)
        {
            // create a 16-byte salt
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // use PBKDF2 to hash the password along with the salt
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, 75623);
            byte[] hash = pbkdf2.GetBytes(20);

            // combine the salt and hash bytes
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the combined salt and hash to a base64 string
            return Convert.ToBase64String(hashBytes);
        }

        // modify combo box values to reflect any new, updated users
        private void UpdateList()
        {
            // reload the users list, which would now contain the updated user
            usersList = User.LoadUsersBin();
            // clear old data
            comboUsers.Items.Clear();
            // add each user's data into the combo box
            foreach (var user in usersList)
            {
                comboUsers.Items.Add($"{user.publicUserFirstname} {user.publicUserLastname}");
            }
        }

        // show any errors arising from the admin inputting invalid values
        public void HandleAlert(string message)
        {
            // modify the form size to accommodate the alert label, make it visible and display an error message
            Size = new Size(Size.Width, originalFormHeight + 50);
            lblAlert.Visible = true;
            lblAlert.Text = message;
        }
        #endregion
        #region Caret logic
        // import the dll which contains the method to hide the caret in a textbox
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        // import aforementioned method from the dll using the extern keyword. the method takes a handle to the control which should have its caret hidden, in this case the text boxes
        static extern bool HideCaret(IntPtr hWnd);

        private void UpdateCursorPosition(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // hide the caret that the system would typically show when a textbox is selected, then invalidate to render this change
                HideCaret(textBox.Handle);
                textBox.Invalidate();
                tmrCursor.Start();
                // get the position of the caret (insertion point)
                int caretIndex = textBox.SelectionStart;

                // if there is no text in the textbox, place the caret at the start of the textbox
                if (textBox.Text.Length < 1)
                {
                    // the X and Y of textBox will correspond to its top left corner
                    lblCursor.Location = new Point(
                    textBox.Location.X,
                    textBox.Location.Y
                        );
                }
                else
                {
                    // find the location of the selected character(s) within the textbox
                    Point caretLocation = textBox.GetPositionFromCharIndex(caretIndex - 1);

                    // adjust the position of the CursorLabel to align with the caret
                    lblCursor.Location = new Point(
                        textBox.Location.X + caretLocation.X + 10,
                        textBox.Location.Y + caretLocation.Y
                    );
                }


                lblCursor.Visible = true;  // ensure it's visible when the textbox is active
            }
        }

        private void StopCursor(object sender, EventArgs e)
        {
            // stop cursor from flashind and hide
            tmrCursor.Stop();
            lblCursor.Visible = false;
        }

        private void RemoveCaret(object sender, EventArgs e)
        {
            if (sender is TextBox textBox) HideCaret(textBox.Handle);
        }
        #endregion       
    }
}
