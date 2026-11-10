using System;

namespace Petkunas__Lukas___Byte_size_Quiz
{

    public partial class frmStaffMenu : BaseForm
    { 

        public frmStaffMenu()
        {
            InitializeComponent();
        }

        #region Form variables
        #endregion
        #region Form event listeners

        // show leaderboard
        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            frmLeaderboard leaderboardForm = new frmLeaderboard();
            leaderboardForm.Show();
            this.Hide();
        }
        // show user modification form
        private void btnModifyUsers_Click(object sender, EventArgs e)
        {
            frmModifyUsers modifyForm = new frmModifyUsers();
            modifyForm.Show();
            this.Hide();
        }
        // show main menu
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu newMainMenu = new frmMainMenu();
            newMainMenu.Show();
            this.Hide();
        }
        #endregion
    }
}
