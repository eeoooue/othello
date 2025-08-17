using LibOthello;
using Microsoft.AspNetCore.Mvc;
using OthelloGameAPI.Services;

namespace OthelloGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OthelloGameController : ControllerBase
    {
        private OthelloGameService Service;
        private OthelloGame Game { get { return Service.Game; } }
        private OthelloGameState GameState { get { return Game.GetGameState(); } }

        public OthelloGameController(OthelloGameService service)
        {
            Service = service;
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
            Service.NewGame();
            return new EmptyResult();
        }
    }
}
