using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOthello
{
    public struct OthelloMove
    {
        public OthelloPiece Colour;
        public int Row;
        public int Col;

        public OthelloMove(OthelloPiece colour, int i, int j)
        {
            Colour = colour;
            Row = i;
            Col = j;
        }
    }
}
