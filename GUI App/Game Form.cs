using CST_250_Milestone;
using Milestone_Class_Library;
using System.Diagnostics;

namespace GUI_App
{
    // GUI of the Minesweeper game.
    public partial class Game_Form : Form
    {
        // gameBoard is a 2D grid of cells representing the Minesweeper game.
        private Board gameBoard;

        // buttonGrid is a 2D grid of buttons corresponding to the cells in the gameBoard.
        private Button[,] buttonGrid;

        // buttonSize is a constant that defines the size of the buttons in the buttonGrid.
        private const int buttonSize = 30;

        // stopwatch is used to measure the time taken by the player to win the game.
        private Stopwatch stopwatch;

        // Reference to the high score form
        private High_Score_Form highScoreForm;

        // String to store the difficulty level of the current game
        private string difficultyLevel;

        // Constructor initializes the game board and sets up the GUI.
        public Game_Form(int size, High_Score_Form highScoreForm, string difficultyLevel)
        {
            // Standard method call to setup the GUI components.
            InitializeComponent();

            // Initialize the game board and button grid with the given size.
            gameBoard = new Board(size);
            buttonGrid = new Button[size, size];

            // Set the size of the form based on the number of buttons and their size.
            this.ClientSize = new Size(size * buttonSize, size * buttonSize);

            // Save the high score form and difficulty level
            this.highScoreForm = highScoreForm;
            this.difficultyLevel = difficultyLevel;

            // Create and setup the buttons.
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Button button = new Button
                    {
                        Name = $"button{row}{col}",
                        Size = new Size(30, 30),
                        Location = new Point(col * 30, row * 30),
                    };
                    // Add event handlers for the button click and mouse down events.
                    button.Click += Button_Click;
                    button.MouseDown += Button_MouseDown;

                    // Add the button to the button grid and form controls.
                    buttonGrid[row, col] = button;
                    Controls.Add(button);
                }
            }

            // Set up the initial state of the game board.
            gameBoard.SetupLiveNeighbors();
            gameBoard.CalculateLiveNeighbors();

            // Initialize and start the stopwatch.
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        // Event handler for button click event.
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = button.Location.Y / 30;
            int col = button.Location.X / 30;

            // If the clicked cell is a mine, reveal all mines, stop the stopwatch, show game over message and close the form.
            if (gameBoard.Grid[row, col].Live)
            {
                RevealMines();
                stopwatch.Stop();
                MessageBox.Show("Game Over");
                this.Close();
            }
            else // If the clicked cell is not a mine
            {
                gameBoard.FloodFill(row, col);
                UpdateButtonGrid();

                // If all non-mine cells are revealed, flag the mines, stop the stopwatch, show winning message and close the form.
                if (gameBoard.IsAllNonBombCellsRevealed())
                {
                    SetFlagsToMines();
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("{0}:{1}:{2}", 
                        ts.Hours.ToString("00"),
                        ts.Minutes.ToString("00"), 
                        ts.Seconds.ToString("00"));
                    MessageBox.Show($"You Win!\nTime elapsed: {elapsedTime}");
                    this.Close();

                    // Prompt for the player's name
                    string name = Prompt.ShowDialog("You Won! Please enter your name:", "Congratulations!");

                    // Create a new PlayerStats object
                    PlayerStats playerStats = new PlayerStats(name, difficultyLevel, elapsedTime);

                    // Add the player's score to the high score form
                    highScoreForm.AddHighScore(playerStats);
                }
            }
        }

        // Event handler for mouse down event on a button.
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            // If the right mouse button was pressed, toggle the flag on the cell.
            if (e.Button == MouseButtons.Right)
            {
                Button button = (Button)sender;
                int buttonRow = button.Top / buttonSize;
                int buttonColumn = button.Left / buttonSize;

                // If the button is not flagged, flag it, otherwise unflag it.
                if (button.BackgroundImage == null)
                {
                    button.BackgroundImage = Properties.Resources.flag;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    button.BackgroundImage = null;
                }
            }
        }

        // Update the button grid based on the state of the game board.
        private void UpdateButtonGrid()
        {
            for (int row = 0; row < gameBoard.Size; row++)
            {
                for (int col = 0; col < gameBoard.Size; col++)
                {
                    Cell cell = gameBoard.Grid[row, col];
                    Button button = buttonGrid[row, col];

                    // If the cell was visited, disable the button and set the text based on the cell state.
                    if (cell.Visited)
                    {
                        button.Enabled = false;
                        if (cell.Live)
                        {
                            button.Text = "B";
                        }
                        else
                        {
                            button.Text = cell.LiveNeighborCount > 0 ? cell.LiveNeighborCount.ToString() : "";
                        }
                    }
                }
            }
        }

        // Reveal all mines on the game board.
        private void RevealMines()
        {
            for (int i = 0; i < gameBoard.Size; i++)
            {
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    if (gameBoard.Grid[i, j].Live)
                    {
                        buttonGrid[i, j].BackgroundImage = Properties.Resources.mine;
                        buttonGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }

        // Flag all mines on the game board.
        private void SetFlagsToMines()
        {
            for (int row = 0; row < gameBoard.Size; row++)
            {
                for (int col = 0; col < gameBoard.Size; col++)
                {
                    Cell cell = gameBoard.Grid[row, col];
                    Button button = buttonGrid[row, col];

                    // If the cell is a mine, flag it.
                    if (cell.Live)
                    {
                        button.BackgroundImage = Properties.Resources.flag;
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            // Create a new Form instance for the prompt dialog
            Form prompt = new Form()
            {
                // Set the dialog form's border style to FixedDialog. Set the dialog form's title or caption. Set the dialog form's position to the center of the screen
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Create a label to display the text
            Label textLabel = new Label()
            {
                // Automatically adjust the label's size based on the text content. Set the position of the label within the form. Set the text to be displayed on the label
                AutoSize = true,
                Location = new Point(50, 20),
                Text = text
            };

            // Create a text box for the user input
            TextBox textBox = new TextBox()
            {
                // Set the position of the text box within the form. Set the width of the text box
                Location = new Point(100, 50),  
                Width = 100
            };

            // Create a button for submitting the input
            Button confirmation = new Button()
            {
                // Set the text to be displayed on the button. Set the position of the button within the form. Set the dialog result when the button is clicked
                Text = "SUBMIT",  
                Location = new Point(115, 100),
                DialogResult = DialogResult.OK
            };

            // Associate a click event handler with the button to close the dialog form
            confirmation.Click += (sender, e) => { prompt.Close(); };

            // Set the size of the dialog form
            prompt.ClientSize = new Size(300, 150);

            // Add the controls to the dialog form
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);

            // Set the default button for the form to the confirmation button
            prompt.AcceptButton = confirmation;

            // Show the dialog form and return the user's input if the result is OK, otherwise return an empty string
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
