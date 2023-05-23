using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_250_Milestone
{
    public class Board
    {
        private int size; // private field to store the size of the board
        private Cell[,] grid; // private field to store the board's grid
        private int difficulty; // private field to store the difficulty level

        public Board(int size) // constructor to initialize the board
        {
            this.size = size; // set the size of the board
            grid = new Cell[size, size]; // create a new grid
            for (int row = 0; row < size; row++) // loop through the rows of the grid
            {
                for (int column = 0; column < size; column++) // loop through the columns of the grid
                {
                    grid[row, column] = new Cell(row, column); // create a new cell object at the current position in the grid
                }
            }
            difficulty = 10; // default difficulty of 10%
        }

        public int Size // public property to get or set the size of the board
        {
            get { return size; }
            set { size = value; }
        }

        public Cell[,] Grid // public property to get or set the grid of the board
        {
            get { return grid; }
            set { grid = value; }
        }

        public int Difficulty // public property to get or set the difficulty level
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public void SetupLiveNeighbors() // method to randomly initialize the grid with live bombs
        {
            Random random = new Random(); // create a new instance of the random class
            int liveCount = (int)Math.Round(size * size * difficulty / 100.0); // calculate the number of live cells based on the difficulty level
            int count = 0; // initialize a counter
            while (count < liveCount) // loop until the desired number of live cells have been created
            {
                int row = random.Next(size); // generate a random row number
                int column = random.Next(size); // generate a random column number
                if (!grid[row, column].Live) // check if the current cell is not already live
                {
                    grid[row, column].Live = true; // set the current cell as live
                    count++; // increment the counter
                }
            }
        }

        public void CalculateLiveNeighbors() // method to calculate the number of live neighbors for each cell in the grid
        {
            for (int row = 0; row < size; row++) // loop through the rows of the grid
            {
                for (int column = 0; column < size; column++) // loop through the columns of the grid
                {
                    Cell currentCell = grid[row, column]; // get the current cell
                    if (currentCell.Live) // check if the current cell is live
                    {
                        currentCell.LiveNeighborCount = 9; // set the live neighbor count to 9
                        continue; // skip to the next iteration of the loop
                    }
                    int liveNeighbors = 0; // initialize a counter for the number of live neighbors
                    for (int i = -1; i <= 1; i++) // loop through the rows surrounding the current cell
                    {
                        for (int j = -1; j <= 1; j++) // loop through the columns surrounding the current cell
                        {
                            if (i == 0 && j == 0) // skip the current cell
                                continue;
                            int r = row + i; // calculate the row of the neighboring cell
                            int c = column + j; // calculate the column of the neighboring cell
                            if (r >= 0 && r < size && c >= 0 && c < size && grid[r, c].Live) // check if the neighboring cell is valid and live
                            {
                                liveNeighbors++; // increase the counter for the number of live neighbors
                            }
                        }
                    }
                    currentCell.LiveNeighborCount = liveNeighbors; // set the number of live neighbors for the current cell
                }
            }
        }
        public bool IsAllNonBombCellsRevealed() // method to check if all non-bomb cells have been revealed
        {
            for (int row = 0; row < size; row++) // loop through the rows of the grid
            {
                for (int column = 0; column < size; column++) // loop through the columns of the grid
                {
                    Cell currentCell = grid[row, column]; // get the current cell
                    if (!currentCell.Live && !currentCell.Visited) // if the cell is non-bomb and not visited
                    {
                        return false; // return false indicating not all non-bomb cells are revealed
                    }
                }
            }
            return true; // return true indicating all non-bomb cells are revealed
        }
    }
}