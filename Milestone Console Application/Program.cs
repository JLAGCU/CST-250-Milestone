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
            PrintBoard(board); // display the board
            Console.ReadKey();
        }

        static void PrintBoard(Board board) // Prints the current state of the board to the console
        {
            for (int row = 0; row < board.Size; row++)
            {
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
                Console.WriteLine(); // Move to the next line for the next row
            }
        }
    }
}