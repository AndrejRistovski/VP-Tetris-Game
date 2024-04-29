using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        // 'currentBlock' is a backing filed for the current block.
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
                for(int i=0;i<2;i++)
                {
                    currentBlock.Move(1, 0);
                    if(!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        // 'GameGrid' represents a game grid.
        public GameGrid GameGrid { get; }
        // 'BlockQueue' represents a block queue.
        public BlockQueue BlockQueue { get; }
        // 'GameOver' represents game over.
        public bool GameOver { get; private set; }
        public int  Score { get; private set; }
        public Block HeldBlock { get; private set; }
        public bool CanHold { get; private set; }

        // Constructor for the 'GameState' class.
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        // Method which checks if the current block is in legal position.
        private bool BlockFits()
        {
            foreach (Position position in CurrentBlock.TilePositions())
            {
                if(!GameGrid.IsEmpty(position.Row, position.Column))
                {
                    return false;
                }
            }

            return true;
        }
        // Method which holds the block in place
        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }
            if(HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock=BlockQueue.GetAndUpdate();
            }
            else
            {
                Block temp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = temp;
            }
            CanHold = false;
        }

        // Method to rotate the current block clockwise.
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if(!BlockFits()) 
            {
                CurrentBlock.RotateCCW();
            }
            
        }

        // Method to rotate the current block counter-clockwise.
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        // Method to move the current block left.
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        // Method to move the current block right.
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        // Method which checks if the game is over.
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        // Method which will be called when the current block can not be moved down.
        private void PlaceBlock()
        {
            foreach (Position position in CurrentBlock.TilePositions())
            {
                GameGrid[position.Row, position.Column] = CurrentBlock.Id;
            }

            Score+=GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        // Method to move the current block down.
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
        // Method that returns the number of empty cells immediately below it.
        private int TileDropDistance(Position position)
        {
            int drop = 0;

            while(GameGrid.IsEmpty(position.Row + drop +1,position.Column))
            {
                drop++;
            }
            return drop;
        }
        
        // Method 
        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;
            foreach(Position position in CurrentBlock.TilePositions())
            {
                drop=System.Math.Min(drop,TileDropDistance(position));
            }
            return drop;
        }

        // Method which moves the curent block dawn as meny rows as possible.
        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }


    }
}
