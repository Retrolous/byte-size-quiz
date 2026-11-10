using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmRegister : BaseForm
    {
        public frmRegister()
        {
            InitializeComponent();
            originalFormHeight = Size.Height;
        }

        #region Form variables
        // used to accommodate the alert label by resizing the form 
        private int originalFormHeight;
        #endregion
        #region Form event listeners

        // validate input values, then add the new user to the userdetails bin file
        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return; // immediately exit if basic validation failed

            if (!IsUsernameUnique(txtUsername.Text)) // if the username is not unique / matches with another
            {
                string textFileDirectory = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\UserDetails.bin";

                // check if it is not due to there being *no* usernames loaded
                if (!File.Exists(textFileDirectory))
                {
                    HandleAlert("The file UserDetails.bin was not found.");
                    return;
                }

                // if the issue is not due to a missing file, display the generic message
                HandleAlert("Username already exists. Choose a different username.");
                return;
            }
            // create a new User object with the input details
            User newUser = new User
            {
                publicUserUsername = CleanInput(txtUsername.Text.ToLower()),
                publicUserPassword = CleanInput(txtPassword.Text),
                publicUserFirstname = CleanInput(txtFirstName.Text),
                publicUserLastname = CleanInput(txtLastName.Text),
                publicUserScores = new List<int> { 0, 0, 0 },
                publicUserAge = (int)numAge.Value,
                publicUserIsAdmin = chkAdmin.Checked && txtAdminCode.Text == ReturnSecret()
            };
            // add the new user to the bin file
            SaveUserToFile(newUser);
            
            MessageBox.Show("Registration successful! You can now log in.");
            
            ShowLoginForm();
        }

        // show login form
        private void btnReturnToLogin_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        // show or hide the secret code textbox 
        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            // invert visibility of the text box
            txtAdminCode.Visible = !txtAdminCode.Visible;
        }

        // modify the visiblity of the password
        private void chkToggleHide_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtPassword, chkToggleHide.Checked);
        }

        // modify the visiblity of the repeated password
        private void chkToggleRepeatHide_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtRepeatPassword, chkToggleRepeatHide.Checked);
        }

        // attach caret logic to each textbox
        private void frmRegister_Load(object sender, EventArgs e)
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
        }

        private void tmrCursor_Tick(object sender, EventArgs e)
        {
            // invert visibility after every tick to mimic a console's caret
            lblCursor.Visible = !lblCursor.Visible;
        }
        #endregion
        #region Validation logic

        // ensure user input data is valid to prevent any errors when loading or saving user details
        private bool ValidateInput()
        {

            // perform basic validation (check if fields are not empty)
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
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

            // ensure a valid username has been input
            if (!IsValidUsername(CleanInput(txtUsername.Text)))
            {
                HandleAlert("Username must be 3-20 characters long and can only contain letters, numbers, and underscores.");
                return false;
            }

            // ensure a sufficiently complex password has been input
            if (!IsPasswordComplex(CleanInput(txtPassword.Text)))
            {
                HandleAlert("Password must be at least 8 characters long and include uppercase, lowercase, a digit, and a special character.");
                return false;
            }

            // ensure a valid name has been entered
            if (!IsValidName(txtFirstName.Text))
            {
                HandleAlert("First name contains invalid characters.");
                return false;
            }

            // ensure a valid surname has been entered
            if (!IsValidName(txtLastName.Text))
            {
                HandleAlert("Last name contains invalid characters.");
                return false;
            }

            // ensure the user has repeated their password correctly
            if (txtPassword.Text != txtRepeatPassword.Text)
            {
                HandleAlert("Password must match in both fields.");
                return false;
            }

            // ensure the user has input an appropriate age
            if (numAge.Value <= 3 || numAge.Value >= 120)
            {
                HandleAlert("Age must be valid (greater than 3 and less than 120).");
                return false;
            }

            if (ReturnSecret() == null)
            {
                HandleAlert("The file AdminSecret.bin was not found.");
                return false;
            }

            // ensure that if the user is registering as an admin, they input the correct secret code
            if (chkAdmin.Checked && !(txtAdminCode.Text == ReturnSecret()))
            {
                HandleAlert("Enter the correct admin secret");
                return false;
            }

            return true;
        }

        // ensure that the username input is unique to prevent any clashes when attempting to login
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
                    if (user.publicUserUsername.ToLower() == username.ToLower())
                    {
                        // Username already exists
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

        // ensure that the username input is reasonable before storing
        private bool IsValidUsername(string username)
        {
            // username must be 3-20 characters and contain only letters, numbers, or underscores.
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_]{3,20}$");
            return regex.IsMatch(username);
        }

        // ensure password input is sufficiently difficult to prevent cracking
        private bool IsPasswordComplex(string password)
        {
            // this regex checks for:
            // - at least 8 characters
            // - at least one uppercase letter
            // - at least one lowercase letter
            // - at least one digit
            // - at least one special character
            var regex = new System.Text.RegularExpressions.Regex(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&.])[A-Za-z\d@$!%*?&.]{8,}$"
            );
            return regex.IsMatch(password);
        }

        // ensure that the name is appropriate i.e. contains no numbers, special characters
        private bool IsValidName(string name)
        {
            // this regex allows letters, spaces, hyphens, and apostrophes.
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z\s'-]+$");
            return regex.IsMatch(name);
        }

        // remove whitespace to prevent a user circumventing validation by adding spaces
        private string CleanInput(string input)
        {
            // helper method for ensuring all input fits requirements; modify as necessary
            return input?.Trim();
        }
        #endregion
        #region Saving logic

        // save the new details to the user details file
        private void SaveUserToFile(User User)
        {
            try
            {
                string textFileDirectory = Path.Combine(new DirectoryInfo
                (Environment.CurrentDirectory).Parent.Parent.FullName, "TextFiles", "UserDetails.bin");

                // create a hash from the user input password
                string savedPasswordHash = HashPassword(User.publicUserPassword);

                // append the new user's data to the text file
                using (var fileStream = new FileStream(textFileDirectory, FileMode.Append, FileAccess.Write))
                using (var sw = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    string userData = User.publicUserUsername + "," +
                      savedPasswordHash + "," +
                      User.publicUserFirstname + "," +
                      User.publicUserLastname + "," +
                      User.publicUserScores[0] + "," +
                      User.publicUserScores[1] + "," +
                      User.publicUserScores[2] + "," +
                      User.publicUserAge + "," +
                      User.publicUserIsAdmin +
                      Environment.NewLine;

                    string encodedData = Convert.ToBase64String(Encoding.UTF8.GetBytes(userData));
                    sw.WriteLine(encodedData);
                }

            }
            catch (Exception ex)
            {
                HandleAlert("An error occurred while saving user data: " + ex.Message);
            }
        }

        // hash password for storage
        private string HashPassword(string plainPassword)
        {
            // create a salt: a random string added to the password when hashing to ensure a unique value, even if the same password is hashed twice, to ensure security
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // use the extracted salt to create a new PBKDF2 instance with the provided password and 75623 - an arbitrary and unpredictable number of - iterations
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, 75623);

            // extract the first 20 bytes from the hashed value 
            byte[] hash = pbkdf2.GetBytes(20);

            // combine the salt and the hash to prepare them for storage
            // the salt will be used for future hashing when a user inputs their password and
            // the hash will be compared with the value gained from this input password to see if it matches
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Return the Base64-encoded result.
            return Convert.ToBase64String(hashBytes);
        }

        // return the secret code by fetching and decrypting it
        private string ReturnSecret()
        {
            try
            {
                string binDirectory = new DirectoryInfo
                (Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\AdminSecret.bin";
                string rawStringFileData;

                // read the entire bin file 
                using (var stream = File.Open(binDirectory, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream, new UTF8Encoding(false)))
                    {
                        rawStringFileData = reader.ReadToEnd();
                    }
                }

                // convert base64 digit array to 8 bit digit array, then that array to utf8 string
                return Encoding.UTF8.GetString(Convert.FromBase64String(rawStringFileData));
            }
            catch (Exception e)
            {
                
                return null;
            }
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
        #region Other logic

        // hide or show the current textbox password visibility
        private void TogglePasswordVisibility(TextBox textBox, bool showPassword)
        {
            if (showPassword)
            {
                // set passwordchar to null; show password
                textBox.PasswordChar = '\0';
                textBox.ForeColor = Color.White;
            }
            else
            {
                // hide password if box is unchecked
                textBox.PasswordChar = '*';
                textBox.ForeColor = Color.DarkGray;
            }
        }

        // display any errors arising from invalid input to the user
        public void HandleAlert(string message)
        {
            // modify form size to accommodate label, set it to visible and show message
            Size = new Size(Size.Width, originalFormHeight + 50);
            lblAlert.Visible = true;
            lblAlert.Text = message;
        }

        private void ShowLoginForm()
        {
            // show the login form
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }
        #endregion
    }
}
