using LibOthello;
using Microsoft.AspNetCore.Mvc;

namespace OthelloGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OthelloGameController : ControllerBase
    {
        private static OthelloGame Game = new OthelloGame();
        private static OthelloGameState GameState { get { return Game.GetGameState(); } }

        public OthelloGameController()
        {

        }

        [HttpGet("Board")]
        public IActionResult GetBoard()
        {
            int[,] board = GameState.Board;

            return new EmptyResult();
        }

        [HttpGet("TurnPlayer")]
        public IActionResult GetTurnPlayer()
        {
            int turnPlayer = GameState.TurnPlayer;

            return new EmptyResult();
        }

        [HttpPost("Move")]
        public IActionResult SubmitMove()
        {
            OthelloPiece player = Game.TurnPlayer;
            int i = 0; // TODO: receive this
            int j = 0; // TODO: receive this
            OthelloMove move = new OthelloMove(player, i, j);
            Game.AttemptMove(move);

            return new EmptyResult();
        }

        [HttpPost("NewGame")]
        public IActionResult StartNewGame()
        {
            Game = new OthelloGame();

            return new EmptyResult();
        }
    }
}
