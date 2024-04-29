using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class LBlock : Block
    {
        // 'tiles' represents a two demensional array that represents all the posible positions of the block.
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new (0,2), new (1,0), new (1,1), new (1,2)},
            new Position[] { new (0,1), new (1,1), new (2,1), new (2,2)},
            new Position[] { new (1,0), new (1,1), new (1,2), new (2,0)},
            new Position[] { new (0,0), new (0,1), new (1,1), new (2,1)},
        };
        // override the 'Id' parametar.
        public override int Id => 3;
        // override the 'StartOffset' parametar.
        protected override Position StartOffset => new Position(0, 3);
        // override the Tiles field.
        protected override Position[][] Tiles => tiles;
    }
}
