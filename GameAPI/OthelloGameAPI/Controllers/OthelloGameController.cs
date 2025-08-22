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

        public OthelloGameController(OthelloGameService service)
        {
            Service = service;
        }

        [HttpGet("GameInfo")]
        public IActionResult GetGameInfo()
        {
            return Ok();
        }

        [HttpGet("Board")]
        public IActionResult GetBoard()
        {
            int[][] matrix = Service.GetGameBoard();
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

        [HttpPost("NewGame")]
        public IActionResult StartNewGame()
        {
            Service.NewGame();
            return Ok();
        }
    }
}
