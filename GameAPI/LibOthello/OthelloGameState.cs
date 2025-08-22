using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOthello
{
    public class OthelloGameState
    {
        public int[,] Board { get; }
        public int TurnPlayer { get; }

        public int AvailableMoves { get; }

        public bool GameOver { get; }

        public int BlackPieces { get { return CountBlackPieces(); } }
        public int WhitePieces { get { return CountWhitePieces(); } }

        public OthelloGameState(OthelloGame game)
        {
            Board = CopyGameBoard(game.Board);
            TurnPlayer = ParseTurnPlayer(game.TurnPlayer);
            AvailableMoves = game.AvailableMoves.Count;
            GameOver = game.GameOver;
        }

        private int CountBlackPieces()
        {
            return CountPiecesOfColour(1);
        }

        private int CountWhitePieces()
        {
            return CountPiecesOfColour(-1);
        }

        private int CountPiecesOfColour(int colour)
        {
            int result = 0;
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    if (Board[i,j] == colour)
                    {
                        result++;
                    }
                }
            }

            return result;
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
