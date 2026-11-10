using System;
using System.Drawing;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmMainMenu : BaseForm
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        #region Form variables

        #endregion
        #region Form event listeners

        // handle the state of task buttons and the staff menu button depending on privileges of the user and their scores
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            if (CurrentUser.publicCurrentUser == null)
            {
                MessageBox.Show("No user is logged in. Please log in first.");

                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Close();
                return;
            }

            lblTitle.Text = "Welcome, " + CurrentUser.publicCurrentUser.publicUserFirstname;
            if (CurrentUser.publicCurrentUser.publicUserIsAdmin)
            {
                // disable challenge buttons for staff members and show staff menu
                btnTask1.Enabled = false;
                btnTask2.Enabled = false;
                btnTask3.Enabled = false;
                btnStaffMenu.Visible = true;
            }
            else
            {
                // ensure the user progress data is valid before attempting to load it.
                if (CurrentUser.publicCurrentUser.publicUserScores == null ||
                    CurrentUser.publicCurrentUser.publicUserScores.Count < 3)
                {
                    MessageBox.Show("User score data is incomplete.");
                }
                else
                {
                    LoadUserProgress();
                }
            }
        }

        // show the first challenge
        private void btnTask1_Click(object sender, EventArgs e)
        {
            frmChallenge1 newForm = new frmChallenge1();
            newForm.Show();
            this.Hide();
        }

        // show the second challenge
        private void btnTask2_Click(object sender, EventArgs e)
        {
            frmChallenge2 newForm = new frmChallenge2();
            newForm.Show();
            this.Hide();
        }

        // show the third challenge
        private void btnTask3_Click(object sender, EventArgs e)
        {
            frmChallenge3 newForm = new frmChallenge3();
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

        // show staff menu form
        private void btnStaffMenu_Click(object sender, EventArgs e)
        {
            frmStaffMenu newForm = new frmStaffMenu();
            newForm.Show();
            this.Hide();
        }

        // show help form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpMain newForm = new frmHelpMain();
            newForm.Show();
        }
        #endregion
        #region Menu logic

        // determine the state of the task buttons depending on the user's scores
        private void LoadUserProgress()
        {
            // get logged-in user
            User currentUser = CurrentUser.publicCurrentUser;
            lblScore1.Text = "Score: " + currentUser.publicUserScores[0];
            lblScore2.Text = "Score: " + currentUser.publicUserScores[1];
            lblScore3.Text = "Score: " + currentUser.publicUserScores[2];

            if (currentUser != null)
            {
                // if challenge 1 is completed
                if (currentUser.publicUserScores[0] >= 15)
                {
                    // challenge 1 completed, disable challenge 1 button
                    btnTask1.Enabled = false;
                    btnTask1.ForeColor = Color.Black;
                }
                else
                {
                    // challenge 1 not completed, enable challenge 1 button
                    btnTask1.Enabled = true;
                    btnTask1.ForeColor = Color.SkyBlue;
                }

                // if challenge 2 is completed
                if (currentUser.publicUserScores[1] >= 15)
                {
                    // challenge 2 completed, disable challenge 2 button
                    btnTask2.Enabled = false;
                    btnTask2.ForeColor = Color.Black;
                }
                else
                {
                    // if challenge 1 is completed before enabling challenge 2 button
                    if (currentUser.publicUserScores[0] >= 15)
                    {
                        // challenge 1 completed, enable challenge 2 button
                        btnTask2.Enabled = true;
                        btnTask2.ForeColor = Color.DarkOrange;
                    }
                    else
                    {
                        // challenge 1 not completed, disable challenge 2 button
                        btnTask2.Enabled = false;
                        btnTask2.ForeColor = Color.Black;
                    }
                }

                // if challenge 3 is completed
                if (currentUser.publicUserScores[2] >= 15)
                {
                    // challenge 3 completed, disable challenge 3 button
                    btnTask3.Enabled = false;
                    btnTask3.ForeColor = Color.Black;
                }
                else
                {
                    // if challenge 2 is completed before enabling challenge 3 button
                    if (currentUser.publicUserScores[1] >= 15)
                    {
                        // challenge 2 completed, enable challenge 3 button
                        btnTask3.Enabled = true;
                        btnTask3.ForeColor = Color.Red;
                    }
                    else
                    {
                        // challenge 2 not completed, disable challenge 3 button
                        btnTask3.Enabled = false;
                        btnTask3.ForeColor = Color.Black;
                    }
                }
            }
        }
        #endregion
    }
}
