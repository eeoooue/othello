using LibOthello;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace OthelloGameAPI.Services
{
    public class OpponentService
    {
        private Random Random = new Random();
        private HttpClient HttpClient = new HttpClient();

        public async Task<OthelloMove?> GetOpponentMove(OthelloGame game)
        {
            double worstScore = double.MaxValue;
            OthelloMove? bestMove = null;

            foreach(OthelloMove move in game.AvailableMoves)
            {
                double score = await GetMoveScore(move, game);
                if (score < worstScore)
                {
                    bestMove = move;
                    worstScore = score;
                }
            }

            return bestMove;
        }

        private async Task<double> GetMoveScore(OthelloMove move, OthelloGame game)
        {
            OthelloGame futureGame = new OthelloGame(game);
            futureGame.AttemptMove(move);
            return await GetScoreForGameState(futureGame);
        }

        private async Task<double> GetScoreForGameState(OthelloGame game)
        {
            int[][] boardList = CreateJaggedMatrix(game.Board);
            int turnPlayer = GetTurnPlayerAsInt(game.TurnPlayer);

            object payload = new { board = boardList, player = turnPlayer };
            string json = JsonSerializer.Serialize(payload);

            HttpResponseMessage response = await HttpClient.PostAsync(
                "http://opponent-api:5000/evaluate_board",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            response.EnsureSuccessStatusCode();
            string responseText = await response.Content.ReadAsStringAsync();

            if (double.TryParse(responseText, out double score))
            {
                return score;
            }
            else
            {
                throw new Exception($"Invalid response from API: {responseText}");
            }
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


        private int GetTurnPlayerAsInt(OthelloPiece piece)
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
