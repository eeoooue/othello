using LibOthello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConsole
{
    internal class GamePresenter
    {
        public void PresentGameState(OthelloGameState gamestate)
        {
            PresentContext(gamestate);
            PresentBoard(gamestate.Board);
        }

        public void PresentContext(OthelloGameState gamestate)
        {
            string turnPlayer = ParseTurnPlayer(gamestate.TurnPlayer);
            Console.WriteLine($"Turn Player: {turnPlayer}");
        }

        private string ParseTurnPlayer(int turnPlayer)
        {
            switch (turnPlayer)
            {
                case 1:
                    return "Black (X)";
                default:
                    return "White (O)";
            }
        }

        private void PresentBoard(int[,] board)
        {
            for(int i=0; i<8; i++)
            {
                PresentRow(board, i);
            }
        }

        private void PresentRow(int[,] board, int i)
        {
            StringBuilder sb = new StringBuilder();
            for(int j=0; j<8; j++)
            {
                string x = ConvertCell(board[i,j]);
                sb.Append(x);
            }
            string built = sb.ToString();
            Console.WriteLine(built);
        }

        private string ConvertCell(int value)
        {
            if (value == 1)
            {
                return "X";
            }
            else if (value == -1)
            {
                return "O";
            }
            return "_";
        }
    }
}
