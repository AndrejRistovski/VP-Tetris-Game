using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid; // 'grid' represents a two demensional array that is readonly.
        public int Rows { get; } // 'Rows' represents a row of the grid.
        public int Columns { get; } // 'Columns' represents a column of the grid.
        //Defining an Indexer.
        public int this[int row, int column]
        {
            // Using lambda expressions for accessor 'get' and 'set'.
            get => grid[row, column];
            set => grid[row, column] = value;
        }
        //Constructor for 'GameGrid' class.
        public GameGrid (int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[Rows, Columns];
        }
        //Method that checks if the cell is inside the grid.
        public bool IsInside (int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }
        //Method that checks if the cell is empty or not.
        public bool IsEmpty (int r, int c)
        {
            return IsInside(r,c) && grid[r,c] == 0;
        }
        //Method that checks if the row is full.
        public bool IsRowFull (int r)
        {
            for(int c = 0; c < Columns; c ++)
            {
                if (grid[r,c] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        //Method that checks if the row is empty.
        public bool IsRowEmpty (int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        //Method that clears a row.
        private void ClearRow (int r)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r,c] = 0;
            }
        }
        //Method that moves an entire row one lane down.
        private void MoveRownDown (int r, int numberOfRows)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + numberOfRows, c] = grid[r,c];
                grid[r,c] = 0;
            }
        }
        //Method that clears a row with all its cells full.
        public int ClearFullRows()
        {
            int cleared = 0;
            for(int r = Rows - 1; r >= 0; r --)
            {
                if(IsRowFull (r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRownDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
