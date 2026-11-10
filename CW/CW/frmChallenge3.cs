using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmChallenge3 : BaseForm
    {
        public frmChallenge3()
        {
            InitializeComponent();
        }

        #region Form variables
        // declares variables to be used in rendering the game
        private Graphics gfxDisplay;
        private Bitmap bmpDisplay;

        // used to store the index of the current level in the array that is created from loadLevelsFromtText()
        private int currentLevel;
        private List<Level> levels = new List<Level> { };
        private Tile[,] backupGrid;
        private int initialPlayerX;
        int initialPlayerY;

        // mutiplied by pixelSize to give the height and width of the display in screen pixels
        private int displayHorizontal = 20;
        private int displayVertical = 15;

        private int pixelSize = 30;

        // sprite map used to associate images with tile types
        private Dictionary<char, Image> sprites = new Dictionary<char, Image>();

        // declares variables used for the game aspect of the form
        private int timeTaken = 0;
        private int score = 0;
        #endregion
        #region Form event listeners

        // start the game by loading questions and allowing interaction
        private void btnStart_Click(object sender, EventArgs e)
        {
            // populate the levels list
            LoadLevelsFromText(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\PuzzleLevels.txt");

            // ensure all values are at their initial state
            score = 0;
            currentLevel = 0;
            lblScore.Text = "Score: 0";
            lblLevel.Text = $"Level: {currentLevel + 1}";

            // disable the start button to prevent the user breaking the form's logic by pressing again
            btnStart.Enabled = false;
            btnReset.Enabled = true;
            btnNextLevel.Enabled = true;

            
            MakeNewBackups();
            RenderDisplay();

            // add event listener so user can interact via key press
            KeyPress += frmChallenge3_KeyPress;
            tmrChallenge3.Start();

        }

        // reset level to its initial state
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetLevel();
        }

        // display the next level without evaluating the score achieved
        private void btnNextLevel_Click(object sender, EventArgs e)
        {
            DisplayNextLevel();
        }

        // show main menu form
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            tmrChallenge3.Stop();
            frmMainMenu newMainMenu = new frmMainMenu();
            newMainMenu.Show();
            this.Hide();
        }

        // log out and show login form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            tmrChallenge3.Stop();
            frmLogin newLogin = new frmLogin();
            newLogin.Show();
            this.Hide();
        }

        // show login form
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp3 newHelp = new frmHelp3();
            newHelp.Show();
        }

        // attempt to move the player, check if its a valid movement, then check if this movement resulted in a level finish
        private void frmChallenge3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (levels == null || levels.Count == 0 || currentLevel >= levels.Count)
            {
                MessageBox.Show("Error: No level data available.");
                return;
            }

            // integers used to represent the direction in which the player is attempting to move
            int dx = 0, dy = 0;
            var level = levels[currentLevel];
            switch (char.ToLower(e.KeyChar))
            {
                case 'w': dy = -1; break;  // up
                case 's': dy = 1; break;   // down
                case 'a': dx = -1; break;  // left
                case 'd': dx = 1; break;   // right
            }

            if (level.MovePlayer(dx, dy))
            {
                RenderDisplay();  // redraw level if movement happened
            }

            // if the player has reached the end as a result of their movement
            if (level.Grid[level.Player.Y, level.Player.X].Type == 'F')
            {
                HandleFinish();
            }
        }

        // prepare the game by loading all required assets
        private void frmChallenge3_Load(object sender, EventArgs e)
        {
            // ensure that key presses are intercepted by the form so that movement via key press works
            KeyPreview = true;
            LoadSprites();
            LoadLevelsFromText(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TextFiles\PuzzleLevels.txt");
            LoadDisplay();
        }

        // increment time and modify label
        private void tmrChallenge3_Tick(object sender, EventArgs e)
        {
            // increment the time and then modify the label accordingly
            timeTaken++;
            lblTimeTaken.Text = "Time Taken: " + (timeTaken / 10.0).ToString("0.0");
            HandleTimeColour();
        }
        #endregion
        #region Rendering logic
        // populate the sprites dictionary by loading images in a predetermined directory
        private void LoadSprites()
        {
            string workingDirectory = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + $"\\Images\\Challenge3\\";

            // define a dictionary of character-to-filename mappings
            Dictionary<char, string> spriteFiles = new Dictionary<char, string>
            {
                { 'X', "brick.png" },
                { 'O', "space.png" },
                { 'P', "player.png" },
                { 'B', "box.png" },
                { 'I', "box.png" },
                { '1', "top.png" },
                { '2', "right.png" },
                { '3', "bottom.png" },
                { '4', "left.png" },
                { 'C', "centre.png" },
                { 'F', "finish.png" }
            };

            // iterate over the dictionary and load sprites dynamically
            foreach (var entry in spriteFiles)
            {
                string fullPath = Path.Combine(workingDirectory, entry.Value);
                if (!File.Exists(fullPath))
                {
                    MessageBox.Show($"Error: Sprite image not found for key '{entry.Key}' at path: {fullPath}");
                    continue;
                }
                try
                {
                    sprites[entry.Key] = Image.FromFile(fullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading sprite for '{entry.Key}': {ex.Message}");
                }
            }
        }

        // prepare the pictGame control for rendering
        private void LoadDisplay()
        {
            // set the dimensions of the picture box
            pictGame.Size = new Size(displayHorizontal * pixelSize, displayVertical * pixelSize);

            // create Bitmap with picture box's size to modify later
            bmpDisplay = new Bitmap(pictGame.Width, pictGame.Height);

            // create a Graphics object that will be used to draw with and consequently modify the Bitmap
            gfxDisplay = Graphics.FromImage(bmpDisplay);

            // set interpolation mode and pixel offset mode to ensure that the 6x6 pixel art does not appear blurry when stretched
            gfxDisplay.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gfxDisplay.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            // create a light-grey rectangle that spans the entire display - this is our default state
            gfxDisplay.FillRectangle(Brushes.Black, 0, 0, bmpDisplay.Width, bmpDisplay.Height);

            // load the modified bitmap into picture box
            pictGame.Image = bmpDisplay;
        }

        // render the current state of the level onto pictGame
        private void RenderDisplay()
        {
            // reset the display to ensure that the old frame doesn't interfere with the new one
            gfxDisplay.Clear(Color.Black);

            Level level = levels[currentLevel];

            // Height - 1 because the last line is metadata
            for (int y = 0; y < level.Height - 1; y++)
            {
                for (int x = 0; x < level.Width; x++)
                {
                    Tile tile = level.Grid[y, x];

                    // draw a square with the tile's sprite in the current coordinates
                    if (tile.Sprite != null)
                    {
                        gfxDisplay.DrawImage(tile.Sprite, x * pixelSize, y * pixelSize, pixelSize, pixelSize);
                    }
                }
            }

            // draw the player
            gfxDisplay.DrawImage(sprites['P'], level.Player.X * pixelSize, level.Player.Y * pixelSize, pixelSize, pixelSize);

            // update the picture box's display with the new frame
            pictGame.Image = bmpDisplay;         
        }
        #endregion
        #region Game logic

        // load all levels from the text file and place them into individual level objects
        private void LoadLevelsFromText(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Error: Level file not found.");
                return;
            }
            // create new list to store questions in
            levels = new List<Level>();
            string[] lines = File.ReadAllLines(filePath);
            // skip the first line; it's a template
            List<string> levelLines = lines.Skip(1).ToList();
            int expectedLinesPerLevel = 16;

            // if not every level is 16 lines the modulo will be a non-zero value
            if (levelLines.Count % expectedLinesPerLevel != 0)
            {
                MessageBox.Show("Warning: The level file contains an incomplete level. Incomplete data will be ignored.");
            }
            int numLevels = levelLines.Count / expectedLinesPerLevel; // number of levels
            for (int i = 0; i < numLevels; i++)
            {
                // skip levels that have been processed, then take 16 lines to represent another level
                var levelData = levelLines.Skip(i * expectedLinesPerLevel).Take(expectedLinesPerLevel).ToArray();
                try
                {
                    // attempt to add the level to the levels list
                    levels.Add(new Level(levelData, sprites));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading level {i + 1}: {ex.Message}");
                }
            }
        }

        // return the level to its original state
        private void ResetLevel()
        {
            if (levels == null || levels.Count == 0)
            {
                MessageBox.Show("Error: No levels loaded.");
                return;
            }
            if (backupGrid == null)
            {
                MessageBox.Show("Error: Backup grid is not available.");
                return;
            }

            // set the current grid to its original state, then create a new deep copy of this original state
            // this must be done as copied objects are shallow copies by default
            levels[currentLevel].Grid = backupGrid;
            backupGrid = Level.DeepCopyGrid(levels[currentLevel].Grid);

            if (levels[currentLevel].Player == null)
            {
                MessageBox.Show("Error: Player data is missing.");
                return;
            }

            // reset the players position
            levels[currentLevel].Player.X = initialPlayerX;
            levels[currentLevel].Player.Y = initialPlayerY;
            RenderDisplay();
        }

        // check and add the score the user achieved, then display the next level
        private void HandleFinish()
        {
            // add the appropriate score and update the score label
            score += CheckTime(timeTaken);
            lblScore.Text = "Score: " + score;
            tmrChallenge3.Stop();
            MessageBox.Show($"Congratulations! Level {currentLevel + 1} beaten");
            tmrChallenge3.Start();
            DisplayNextLevel();
        }

        // return the score the user achieved depending on their time taken
        private int CheckTime(int unprocessedTime)
        {
            // time is stored in centiseconds; 1 unit is 100ms, so division by 10 is necessary
            int time = (int)Math.Ceiling(unprocessedTime / 10.0);
            if (time <= levels[currentLevel].Times["Gold"]) return 8;
            else if (time <= levels[currentLevel].Times["Silver"]) return 5;
            else if (time <= levels[currentLevel].Times["Bronze"]) return 2;
            else return 1;
        }

        // modify values to indicate the next level is to be used, then render this change
        private void DisplayNextLevel()
        {
            if (currentLevel < levels.Count - 1)
            {
                // increment the current level counter and then call methods to prepare and display the level
                currentLevel++;
                lblLevel.Text = $"Level: {currentLevel + 1}";
                MakeNewBackups();
                RenderDisplay();
                timeTaken = 0;
                tmrChallenge3.Start();
            }
            else
            {
                // end of the game has been reached
                HandleEndGame();
            }
        }

        // create deep copies of the level for reverting to the original level state when required
        private void MakeNewBackups()
        {
            backupGrid = Level.DeepCopyGrid(levels[currentLevel].Grid);
            initialPlayerX = levels[currentLevel].Player.X;
            initialPlayerY = levels[currentLevel].Player.Y;
        }

        // stop any further interaction, and check if the user achieved the minimum score
        private void HandleEndGame()
        {
            tmrChallenge3.Stop();
            MessageBox.Show("Congratulations! You reached the end.");
            btnStart.Enabled = true;
            btnNextLevel.Enabled = false;
            btnReset.Enabled = false;
            timeTaken = 0;
            // remove event listeners to prevent interaction after game is finished
            this.KeyPress -= frmChallenge3_KeyPress;

            if (score >= 15)
            {
                MessageBox.Show("Congratulations! You've won the game! All challenges completed.");
                CurrentUser.publicCurrentUser.SaveScore(score, 3);
                frmMainMenu newMainMenu = new frmMainMenu();
                newMainMenu.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Sorry, you didn't attain the minimum score of 15. Try again; practice makes perfect.");
                score = 0;
                lblScore.Text = "Score: ";
                lblLevel.Text = "Level: ";
                lblTimeTaken.Text = "Time taken: ";
                gfxDisplay.FillRectangle(Brushes.Black, 0, 0, bmpDisplay.Width, bmpDisplay.Height);
                pictGame.Image = bmpDisplay;
            }
        }

        // change the lblTimeTaken control colour depending on the time taken for the user to beat the level
        private void HandleTimeColour()
        {
            if (timeTaken / 10 < levels[currentLevel].Times["Gold"]) lblTimeTaken.ForeColor = Color.Gold;
            else if (timeTaken / 10 < levels[currentLevel].Times["Silver"]) lblTimeTaken.ForeColor = Color.Silver;
            else if (timeTaken / 10 < levels[currentLevel].Times["Bronze"]) lblTimeTaken.ForeColor = Color.Brown;
            else lblTimeTaken.ForeColor = Color.Gray;
        }

        #endregion
    }
}
