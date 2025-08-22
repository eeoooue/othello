using LibOthello;

namespace OthelloGameAPI.Services
{
    public class OpponentService
    {
        private Random Random = new Random();

        public async Task<OthelloMove?> GetOpponentMove(OthelloGame game)
        {
            double bestScore = 0.0;
            OthelloMove? bestMove = null;

            foreach(OthelloMove move in game.AvailableMoves)
            {
                double score = await GetMoveScore(move, game);
                if (score > bestScore)
                {
                    bestMove = move;
                    bestScore = score;
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
            await Task.Delay(25);
            return Random.NextDouble();
        }
    }
}
