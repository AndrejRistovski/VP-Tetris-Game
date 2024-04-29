using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {

        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };

        private readonly Random random = new Random();

        // 'NextBlock' is used to store the next block in the queue.
        public Block NextBlock { get; private set; }

        // Constructor for 'BlockQueue' class.
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        // Method which returns a random block.
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //Method which returns the next block and updates the next blocks property.
        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
