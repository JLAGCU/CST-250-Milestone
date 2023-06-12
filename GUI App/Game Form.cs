using CST_250_Milestone;
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

        // Constructor initializes the game board and sets up the GUI.
        public Game_Form(int size)
        {
            // Standard method call to setup the GUI components.
            InitializeComponent();

            // Initialize the game board and button grid with the given size.
            gameBoard = new Board(size);
            buttonGrid = new Button[size, size];

            // Set the size of the form based on the number of buttons and their size.
            this.ClientSize = new Size(size * buttonSize, size * buttonSize);

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
                    MessageBox.Show($"You Win!\nTime elapsed: {ts.Minutes}:{ts.Seconds}.{ts.Milliseconds}");
                    this.Close();
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
}
