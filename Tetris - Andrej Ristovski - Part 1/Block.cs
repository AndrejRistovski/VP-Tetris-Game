using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; } //Two dimensional possition array which contains the tile positions in the 4 rotation states.
        protected abstract Position StartOffset { get; } //Decides where the block spawns in the grid.
        public abstract int Id { get; } // 'Id' which we need to destinguish the blocks.

        private int rotationState; // 'rotationState' which we need to store the current rotation state of the block.

        private Position offset; // 'offset' which we need to store the current offset of the block.

        //Constructor for the 'Block' class.
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }
        //Method which loops over the tile positions in the current rotation state
        // and adds both the row and column offset.
        public IEnumerable<Position> TilePositions()
        {
            foreach(Position position in Tiles[rotationState])
            {
                // The 'foreach' continues where we left off.
                yield return new Position(position.Row + offset.Row, position.Column + offset.Column);
            }
        }
        //Method which rotates the block 90 degrees clockwise.
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        //Methiod which rotates counter-clockwise.
        public void RotateCCW()
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        //Method which moves the block by a given number of rows and columns.
        public void Move (int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }
        //Method which resets the rotation and position.
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
