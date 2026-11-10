using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace Petkunas__Lukas___Byte_size_Quiz
{

    public partial class frmLogin : BaseForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Form variables
        #endregion
        #region Form event listeners

        // validate user input, then check if the user input a valid record. if they did, log them in and display main menu
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // username is converted to lowercase for simplicity, but password is not for case sensitivty - ensure security
            string username = txtUsername.Text.ToLower().Trim();
            string password = txtPassword.Text.Trim();       

            if (!LoginValidation())
                return; // stop if basic validation fails.

            List<User> PermittedUsers = User.LoadUsersBin(); // list of all the users from the bin file

            // if the user file is not loaded correctly
            if (PermittedUsers == null || PermittedUsers.Count == 0)
            {
                lblAlert.Show();
                lblAlert.Text = "No user data available. Please contact an admin.";
                return;
            }

            foreach (User UserInList in PermittedUsers)
            {
                // if there is a match between the given username and a username in the list
                if (UserInList.publicUserUsername == username)
                {
                    try
                    {
                        // convert the stored password hash back to a byte array, and then extract the first 16 bytes (the salt) from said array
                        byte[] hashBytes = Convert.FromBase64String(UserInList.publicUserPassword);

                        if (hashBytes.Length < 36)
                        {
                            // expected 16 bytes for the salt and 20 bytes for the hash.
                            MessageBox.Show("Stored password is in an unexpected format.");
                            continue;
                        }

                        // extract the salt from hashBytes
                        byte[] salt = new byte[16];
                        Array.Copy(hashBytes, 0, salt, 0, 16);

                        // use the extracted salt to create a new PBKDF2 instance with the provided password and 75623 - an arbitrary and unpredictable number of - iterations of hashing
                        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 75623);

                        // the resulting hash, if password was entered correctly, will be the same as when the password was registered
                        // as it will have used the same salt and number of iterations. these can be compared to ensure the correct password was entered
                        byte[] hash = pbkdf2.GetBytes(20);

                        // compared each byte in the hash array
                        bool passwordMatches = true;
                        for (int i = 0; i < 20; i++)
                        {
                            if (hashBytes[i + 16] != hash[i])
                            {
                                passwordMatches = false;
                                break;
                            }
                        }

                        if (passwordMatches)
                        {
                            MessageBox.Show("Welcome to the system, " + UserInList.publicUserUsername);
                            CurrentUser.publicCurrentUser = UserInList;
                            frmMainMenu newForm = new frmMainMenu();
                            newForm.Show();
                            Hide();
                            return; // exit after a successful login
                        }
                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show("Error processing stored password format: " + fe.Message);
                        continue;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message);
                        continue;
                    }
                }
            }

            if (CurrentUser.publicCurrentUser == null)  // if no user has accessed after attempting to login
            {
                lblAlert.Show();
                lblAlert.Text = "Sorry, you must enter a valid username and password";
            }

        }

        // show the register form
        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister newForm = new frmRegister();
            newForm.Show();
            this.Hide();
        }

        // remove preexisting data, then prepare textboxes for the custom caret logic
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // remove user details from memory to ensure that they aren't present when logging in with new details
            CurrentUser.publicCurrentUser = null;

            // since the textboxes are automatically focused on start-up, this ensures that the caret is removed from the start
            // otherwise, the caret would be present until you clicked on the textbox
            txtUsername.GotFocus += RemoveCaret;
            txtPassword.GotFocus += RemoveCaret;

            // bind the methods which update the cursor's position to the event listeners which correspond to the user interacting with the textboxes
            txtUsername.TextChanged += UpdateCursorPosition;
            txtUsername.Click += UpdateCursorPosition;
            txtUsername.KeyDown += UpdateCursorPosition;

            txtPassword.TextChanged += UpdateCursorPosition;
            txtPassword.Click += UpdateCursorPosition;
            txtPassword.KeyDown += UpdateCursorPosition;

            // bind the methods which hide the cursor to the event listeners which correspond to the user leaving the textboxes
            txtUsername.Leave += StopCursor;
            txtPassword.Leave += StopCursor;

        }

        // toggle caret visibility
        private void tmrCursor_Tick(object sender, EventArgs e)
        {
            // invert visibility after every tick to mimic a console's caret
            lblCursor.Visible = !lblCursor.Visible;
        }

        // hide or show password depending on checkbox value
        private void chkToggleHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToggleHide.Checked == true)
            {
                // make the password visible if checked
                txtPassword.PasswordChar = '\0';
                txtPassword.ForeColor = Color.White;
            }
            else
            {
                // obfuscate the password if unchecked
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.DarkGray;
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
        #region Log-in logic
        // ensure the user input valid data in the fields
        public bool LoginValidation()
        {
            string loginname = txtUsername.Text.ToLower().Trim();
            string password = txtPassword.Text.Trim();
            // if both fields are blank
            if (string.IsNullOrWhiteSpace(loginname) && string.IsNullOrWhiteSpace(password))
            {
                lblAlert.Show();
                lblAlert.Text = "Sorry, you cannot leave username and password blank";
                return false;
            }

            // if only one field is blank
            if (string.IsNullOrWhiteSpace(loginname))
            {
                lblAlert.Show();
                lblAlert.Text = "Sorry, you cannot leave username blank";
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblAlert.Show();
                lblAlert.Text = "Sorry, you cannot leave password blank";
                return false;
            }
            return true;
        }
        #endregion
    }
}
