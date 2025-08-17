using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOthello
{
    public class OthelloGameState
    {
        public int[,] Board;
        public int TurnPlayer;

        public OthelloGameState(OthelloGame game)
        {
            Board = CopyGameBoard(game.Board);
            TurnPlayer = ParseTurnPlayer(game.TurnPlayer);
        }

        private int[,] CopyGameBoard(int[,] board)
        {
            int[,] result = new int[8, 8];

            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    result[i, j] = board[i, j];
                }
            }

            return result;
        }

        private int ParseTurnPlayer(OthelloPiece piece)
        {
            if (piece == OthelloPiece.Black)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
