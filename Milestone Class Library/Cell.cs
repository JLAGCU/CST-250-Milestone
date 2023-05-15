using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_250_Milestone
{
    public class Cell
    {
        private int row; // the row position of the cell
        private int column; // the column position of the cell
        private bool visited; // whether the cell has been visited or not
        private bool live; // whether the cell is live or not
        private int liveNeighborCount; // the number of live neighbors for the cell

        public Cell(int row, int column) // Constructor for a Cell object, takes the row and column position as parameters.
        {
            this.row = row;
            this.column = column;
            visited = false;
            live = false;
            liveNeighborCount = 0;
        }

        public int Row // Getter and setter for the row position of the cell.
        {
            get { return row; }
            set { row = value; }
        }

        public int Column // Getter and setter for the column position of the cell.
        {
            get { return column; }
            set { column = value; }
        }

        public bool Visited // Getter and setter for whether the cell has been visited or not.
        {
            get { return visited; }
            set { visited = value; }
        }

        public bool Live // Getter and setter for whether the cell is live or not.
        {
            get { return live; }
            set { live = value; }
        }

        public int LiveNeighborCount // Getter and setter for the number of live neighbors for the cell.
        {
            get { return liveNeighborCount; }
            set { liveNeighborCount = value; }
        }
    }
}
