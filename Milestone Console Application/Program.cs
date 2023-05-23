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
        static void PrintBoardDuringGame(Board board) // Prints the current state of the board during the game
        {
            Console.WriteLine("Current Board State:"); // Display a heading indicating the current state of the board
            Console.WriteLine();
            Console.Write("  ");
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write(column + " "); // Display the column numbers at the top of the board
            }
            Console.WriteLine();
            Console.Write("  ");
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write("--"); // Display dashes to separate the column numbers from the board cells
            }
            Console.WriteLine();

            for (int row = 0; row < board.Size; row++) // Iterate over each row in the board
            {
                Console.Write(row + "|"); // Display the row number at the beginning of each row
                for (int column = 0; column < board.Size; column++)
                {
                    Cell cell = board.Grid[row, column]; // Get the cell at the current row and column

                    if (cell.Visited) // If the cell has been visited
                    {
                        if (cell.Live) // If the cell is "live", print "X"
                        {
                            Console.Write("X "); // Display "X" for a visited live cell
                        }
                        else // Otherwise, print the number of live neighbors the cell has or an empty square
                        {
                            if (cell.LiveNeighborCount == 0)
                            {
                                Console.Write("- "); // Display "-" for a visited non-live cell with no live neighbors
                            }
                            else
                            {
                                Console.Write(cell.LiveNeighborCount + " "); // Display the number of live neighbors for a visited non-live cell
                            }
                        }
                    }
                    else if (board.Grid[row, column].Live) // If the cell has not been visited and it is live, print "?"
                    {
                        Console.Write("? "); // Display "?" for an unvisited live cell
                    }
                    else // If the cell has not been visited and it is not live, print a question mark
                    {
                        Console.Write("? "); // Display "?" for an unvisited non-live cell
                    }
                }
                Console.WriteLine(); // Move to the next line after printing all cells in the row
            }
            Console.WriteLine();
        }
    }
}