using LibOthello;
using OthelloGameAPI.DataObjects;
using System.Security.Cryptography.Xml;

namespace OthelloGameAPI.Services
{
    public class OthelloGameService
    {
        public OthelloGame Game = new OthelloGame();

        public void NewGame()
        {
            Game = new OthelloGame();
        }

        public int[][] GetGameBoard()
        {
            int[,] board = Game.Board;
            int[][] matrix = CreateJaggedMatrix(board);
            return matrix;
        }

        private static int[][] CreateJaggedMatrix(int[,] grid)
        {
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            var jagged = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jagged[i] = new int[cols];
                for (int j = 0; j < cols; j++) jagged[i][j] = grid[i, j];
            }
            return jagged;
        }

        public void AttemptMove(MoveDataObject dataObject)
        {
            OthelloPiece player = ParseTurnPlayer(dataObject.Player);
            int i = dataObject.I;
            int j = dataObject.J;
            OthelloMove move = new OthelloMove(player, i, j);
            Game.AttemptMove(move);
        }

        private OthelloPiece ParseTurnPlayer(int player)
        {
            if (player == 1)
            {
                return OthelloPiece.Black;
            }
            else
            {
                return OthelloPiece.White;
            }
        }

        public int GetTurnPlayer()
        {
            return Game.GetGameState().TurnPlayer;
        }


        public GameInfoDataObject GetGameInfo()
        {
            OthelloGameState gameState = Game.GetGameState();
            return ConstructGameInfoObject(gameState);
        }

        private GameInfoDataObject ConstructGameInfoObject(OthelloGameState state)
        {
            GameInfoDataObject result = new GameInfoDataObject();

            result.TurnPlayer = state.TurnPlayer;
            result.ScoreBlack = state.BlackPieces;
            result.ScoreWhite = state.WhitePieces;

            result.PlayerMustPass = state.AvailableMoves == 0;
            result.GameOver = state.GameOver;

            return result;
        }
    }
}
