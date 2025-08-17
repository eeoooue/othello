using LibOthello;
using Microsoft.AspNetCore.Http.HttpResults;
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
            int[][] matrix = CreateJaggedMatrix(board);
            return Ok(matrix);
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

        [HttpGet("TurnPlayer")]
        public IActionResult GetTurnPlayer()
        {
            int turnPlayer = GameState.TurnPlayer;
            return Ok(turnPlayer);
        }


        public class MoveDataObject
        {
            public int Player { get; set; } 
            public int I { get; set; }
            public int J { get; set; }
        }

        [HttpPost("Move")]
        public IActionResult SubmitMove([FromBody] MoveDataObject dataObject)
        {
            OthelloPiece player = ParseTurnPlayer(dataObject.Player);
            int i = dataObject.I;
            int j = dataObject.J;
            OthelloMove move = new OthelloMove(player, i, j);
            Game.AttemptMove(move);
            return Ok();
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

        [HttpPost("NewGame")]
        public IActionResult StartNewGame()
        {
            Service.NewGame();
            return Ok();
        }
    }
}
