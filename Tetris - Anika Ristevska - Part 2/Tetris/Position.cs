using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Position
    {
        public int Row { get; set; } // 'Row' represents a row of the block.
        public int Column { get; set; } // 'Column' represents a column of the block.
        //Constructor for the 'Position' class.
        public Position (int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
