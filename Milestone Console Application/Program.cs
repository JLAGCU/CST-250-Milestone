using CST_250_Milestone;

namespace MilestoneConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10); // create a 10x10 board
            board.SetupLiveNeighbors(); // randomly set "live" cells
            board.CalculateLiveNeighbors(); // calculate the number of live neighbors for each cell

            Console.WriteLine("============DEBUG============");
            Console.WriteLine("Live bomb locations:");
            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    if (board.Grid[row, column].Live)
                    {
                        Console.WriteLine("Row: {0}, Column: {1}", row, column);
                    }
                }
            }
            Console.WriteLine("==========END DEBUG==========");
            Console.WriteLine("");

            bool endGame = false; // variable to track the endgame condition

            while (!endGame) // loop until the endgame condition is met
            {
                PrintBoardDuringGame(board); // display the board during the game
                Console.WriteLine("Enter a row number:");
                int row;
                while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= board.Size)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and {0}.", board.Size - 1);
                }

                Console.WriteLine("Enter a column number:");
                int column;
                while (!int.TryParse(Console.ReadLine(), out column) || column < 0 || column >= board.Size)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and {0}.", board.Size - 1);
                }

                board.FloodFill(row, column); // Apply flood fill algorithm starting from the selected cell

                board.Grid[row, column].Visited = true; // Mark the selected cell as visited

                if (board.Grid[row, column].Live) // If the chosen cell is a bomb
                {
                    endGame = true; // Set the endgame condition to true
                    Console.WriteLine("Game Over! You hit a bomb.");
                }
                else if (board.IsAllNonBombCellsRevealed()) // If all non-bomb cells have been revealed
                {
                    endGame = true; // Set the endgame condition to true
                    Console.WriteLine("Congratulations! You won the game.");
                }
            }

            PrintBoard(board); // Display the final state of the board
            Console.ReadKey();
        }
        static void PrintBoard(Board board) // Prints the current state of the board to the console
        {
            Console.WriteLine("Current Board State:");
            Console.WriteLine();
            Console.Write("  ");
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write(column + " ");
            }
            Console.WriteLine();
            Console.Write("  ");
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            for (int row = 0; row < board.Size; row++)
            {
                Console.Write(row + "|");
                for (int column = 0; column < board.Size; column++)
                {
                    Cell cell = board.Grid[row, column]; // Get the cell at the current row and column

                    if (cell.Live) // If the cell is "live", print "X"
                    {
                        Console.Write("X ");
                    }
                    else // Otherwise, print the number of live neighbors the cell has
                    {
                        Console.Write(cell.LiveNeighborCount + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void PrintBoardDuringGame(Board board)
        {
            Console.WriteLine("Current Board State:");
            Console.WriteLine();
            Console.Write("  ");
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write(column + " ");
            }
            Console.WriteLine();
            Console.Write("  ");
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            for (int row = 0; row < board.Size; row++)
            {
                Console.Write(row + "|");
                for (int column = 0; column < board.Size; column++)
                {
                    Cell cell = board.Grid[row, column];

                    if (cell.Visited)
                    {
                        if (cell.Live)
                        {
                            Console.Write("X ");
                        }
                        else
                        {
                            if (cell.LiveNeighborCount == 0)
                            {
                                Console.Write("- "); // Display "-" for a visited cell with no live neighbors
                            }
                            else
                            {
                                Console.Write(cell.LiveNeighborCount + " ");
                            }
                        }
                    }
                    else if (board.Grid[row, column].Live)
                    {
                        Console.Write("? ");
                    }
                    else
                    {
                        Console.Write("? ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}