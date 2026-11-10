using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmLeaderboard : BaseForm
    {
        
        public frmLeaderboard()
        {
            InitializeComponent();
        }

        #region Form variables
        // generate a list of non-admin users by loading users and applying an expression to each user
        private List<User> usersList = User.LoadUsersBin().Where(user => user.publicUserIsAdmin == false).ToList() ?? new List<User>();
        #endregion
        #region Form event listeners

        // prepare control for displaying data, then load and display data
        private void frmLeaderboard_Load(object sender, EventArgs e)
        {
                if (usersList == null || usersList.Count == 0)
                {
                    MessageBox.Show("No non-admin users were found. Please check the users file.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // configure DataGridView columns for total team scores
                ConfigureTotalTeamScoresDataGridView();
                // populate DataGridView with team scores
                PopulateTotalTeamScoresDataGridView();
                // calculate overall score for each team and rank teams
                CalculateAndRankTeams();
                // configure DataGridView columns for average challenge scores
                ConfigureAverageChallengeScoresDataGridView();
                // list the average score for each challenge
                ListAverageChallengeScores();         
        }

        // provide the admin with the top performers when btnTopPerformers is clicked
        private void btnTopPerformers_Click(object sender, EventArgs e)
        {
            // get the top 3 performing users
            var topPerformers = GetTopPerformingUsers(3);
            // display the top performers' information in the order: Name, Age, Total Score
            string message = "";
            if (topPerformers.Count > 0)
            {
                // each if statement ensures that there are more than the given amount of users in the list; ensures that the program does not attempt to access a non-existent value
                if (topPerformers.Count >= 1)
                {
                    int totalScore1 = topPerformers[0].publicUserScores[0] +
                    topPerformers[0].publicUserScores[1] +
                    topPerformers[0].publicUserScores[2];
                    message += topPerformers[0].publicUserFirstname + " " +
                    topPerformers[0].publicUserLastname +
                     " - Age " + topPerformers[0].publicUserAge + ", Score: " + totalScore1 + Environment.NewLine;
                }
                if (topPerformers.Count >= 2)
                {
                    int totalScore2 = topPerformers[1].publicUserScores[0] +
                    topPerformers[1].publicUserScores[1] +
                    topPerformers[1].publicUserScores[2];
                    message += topPerformers[1].publicUserFirstname + " " +
                    topPerformers[1].publicUserLastname +
                    " - Age " + topPerformers[1].publicUserAge + ", Score: " + totalScore2 + Environment.NewLine;
                }
                if (topPerformers.Count >= 3)
                {
                    int totalScore3 = topPerformers[2].publicUserScores[0] +
                    topPerformers[2].publicUserScores[1] +
                    topPerformers[2].publicUserScores[2];
                    message += topPerformers[2].publicUserFirstname + " " +
                    topPerformers[2].publicUserLastname +
                    "- Age " + topPerformers[2].publicUserAge + ", Score: " + totalScore3 + Environment.NewLine;
                }

                MessageBox.Show(message, "Top Performers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No users found", "Top Performers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // show staff menu
        private void btnStaffMenu_Click(object sender, EventArgs e)
        {
            frmStaffMenu newForm = new frmStaffMenu();
            newForm.Show();
            this.Hide();
        }
        // show main menu
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
        #endregion
        #region Data display logic

        // prepare the data grid view to display teams and their scores
        private void ConfigureTotalTeamScoresDataGridView()
        {
            // Add columns for Rank, Age Range, Total Team Score, Challenge 1, Challenge 2, and Challenge 3 scores

            dgvTeamTotalScores.Columns.Add("Rank", "Rank");
            dgvTeamTotalScores.Columns.Add("AgeRange", "Age Range");
            dgvTeamTotalScores.Columns.Add("TotalRangeScore", "Total Range Score");
            dgvTeamTotalScores.Columns.Add("Challenge1", "Challenge 1");
            dgvTeamTotalScores.Columns.Add("Challenge2", "Challenge 2");
            dgvTeamTotalScores.Columns.Add("Challenge3", "Challenge 3");
            // Set the DataGridView to read-only mode; user cannot edit the data grid view
            dgvTeamTotalScores.ReadOnly = true;
        }

        // display average scores in the respective data grid view
        private void ListAverageChallengeScores()
        {
            // calculate average score for each challenge, including only those who have a score more than 0 in a challenge
            try
            {
                double avgChallenge1Score = Math.Round(usersList.Where(user => user.publicUserScores[0] != 0)
                                                               .Average(user => user.publicUserScores[0]), 2);

                double avgChallenge2Score = Math.Round(usersList.Where(user => user.publicUserScores[1] != 0)
                                                                    .Average(User => User.publicUserScores[1]), 2);

                double avgChallenge3Score = Math.Round(usersList.Where(user => user.publicUserScores[2] != 0)
                                                                    .Average(User => User.publicUserScores[2]), 2);
                // display the average scores in a DataGridView
                dgvAverageScores.Rows.Add("1", avgChallenge1Score);

                dgvAverageScores.Rows.Add("2", avgChallenge2Score);

                dgvAverageScores.Rows.Add("3", avgChallenge3Score);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Average scores could not be calculated; most likely because there are no players who have attempted one or more challenges: " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        #endregion
        #region Calculation logic

        // prepare and display user score data in the data grid view
        private void PopulateTotalTeamScoresDataGridView()
        {
            // group Users by age range
            var groupedUsers = usersList.GroupBy(user => (int)Math.Floor(user.publicUserAge / 10.0) * 10);

            foreach (var ageGroup in groupedUsers)
            {
                int ageRangeStart = ageGroup.Key; // Start of the age range (e.g., 0, 10, 20, etc.)
                int ageRangeEnd = ageRangeStart + 10; // End of the age range (e.g., 10, 20, 30, etc.)
                int totalScore = 0;
                int challenge1Score = 0;
                int challenge2Score = 0;
                int challenge3Score = 0;

                // Calculate total score and scores for each challenge within the age range
                foreach (var user in ageGroup)
                {
                    totalScore += user.publicUserScores[0] + user.publicUserScores[1] + user.publicUserScores[2];

                    challenge1Score += user.publicUserScores[0];
                    challenge2Score += user.publicUserScores[1];
                    challenge3Score += user.publicUserScores[2];
                }

                // Add a row to the DataGridView for the current age range
                dgvTeamTotalScores.Rows.Add(0, $"{ageRangeStart}-{ageRangeEnd}", totalScore, challenge1Score, challenge2Score, challenge3Score);
            }
        }

        // rank the teams in the data grid view by score achieved
        private void CalculateAndRankTeams()
        {

            // check that the DataGridView contains the expected column.
            if (!dgvTeamTotalScores.Columns.Contains("TotalRangeScore"))
            {
                MessageBox.Show("The 'TotalRangeScore' column is missing from the Team Total Scores grid.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // try sorting the grid by the TotalRangeScore column.
            try
            {
                dgvTeamTotalScores.Sort(dgvTeamTotalScores.Columns["TotalRangeScore"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sorting team scores: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // rank the teams based on their total scores
            int rank = 1;

            // increment the rank for each next team; as it's sorted in descending order, the next team will always be the one behind the former
            foreach (DataGridViewRow row in dgvTeamTotalScores.Rows)
            {
                row.Cells["Rank"].Value = rank++;
            }
        }

        // prepare the average scores data grid view for displaying data
        private void ConfigureAverageChallengeScoresDataGridView()
        {
            // add columns for Challenge and Average Score
            dgvAverageScores.Columns.Add("Challenge", "Challenge");
            dgvAverageScores.Columns.Add("AverageScore", "Average Score");
        }

        // return users with the highest total score
        private List<User> GetTopPerformingUsers(int count)
        {
            // sort the Users by total score in descending order
            var sortedUsers = usersList.OrderByDescending(User => User.publicUserScores[0] + User.publicUserScores[1] + User.publicUserScores[2]).ToList();

            // return the top performing Users based on the specified count
            return sortedUsers.Take(count).ToList();
        }
        #endregion   
    }
}
