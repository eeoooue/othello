using LibOthello;

namespace OthelloGameAPI.Services
{
    public class OthelloGameService
    {
        public OthelloGame Game = new OthelloGame();

        public void NewGame()
        {
            Game = new OthelloGame();
        }

        public void AttemptMove()
        {

        }
    }
}
