using LibOthello;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OthelloGameAPI.DataObjects;
using OthelloGameAPI.Services;

namespace OthelloGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OthelloGameController : ControllerBase
    {
        private OthelloGameService Service;
        private OpponentService Opponent;

        public OthelloGameController(OthelloGameService service, OpponentService opponent)
        {
            Service = service;
            Opponent = opponent;
        }

        [HttpGet("GameInfo")]
        public IActionResult GetGameInfo()
        {
            GameInfoDataObject data = Service.GetGameInfo();
            return Ok(data);
        }

        [HttpGet("Board")]
        public IActionResult GetBoard([FromQuery] bool indicateMoveOptions = false)
        {
            int[][] matrix = Service.GetGameBoard(indicateMoveOptions);
            return Ok(matrix);
        }

        [HttpGet("TurnPlayer")]
        public IActionResult GetTurnPlayer()
        {
            int turnPlayer = Service.GetTurnPlayer();
            return Ok(turnPlayer);
        }

        [HttpPost("Move")]
        public IActionResult SubmitMove([FromBody] MoveDataObject move)
        {
            Service.AttemptMove(move);
            return Ok();
        }

        [HttpPost("Pass")]
        public IActionResult SubmitPass([FromQuery] int player)
        {
            Service.AttemptPass(player);
            return Ok();
        }

        [HttpPost("NewGame")]
        public IActionResult StartNewGame()
        {
            Service.NewGame();
            return Ok();
        }
    }
}
