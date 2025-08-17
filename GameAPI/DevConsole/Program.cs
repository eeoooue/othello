using LibOthello;

namespace DevConsole
{
    internal class Program
    {
        private static OthelloGame Game = new OthelloGame();

        static void Main(string[] args)
        {
            GamePresenter presenter = new GamePresenter();

            while (true)
            {
                Console.Clear();
                presenter.PresentGameState(Game.GetGameState());
                GetPlayerMove();
            }
        }

        static void GetPlayerMove()
        {
            Console.WriteLine("Make a move, e.g. 0 0");
            string? input = Console.ReadLine();
            if (input is string value)
            {
                try
                {
                    AttemptMove(value);
                }
                catch
                {
                    return;
                }
            }
        }

        static void AttemptMove(string moveString)
        {
            if (moveString == "pass")
            {
                Game.AttemptPass();
                return;
            }

            string[] arr = moveString.Split(" ");

            int i = int.Parse(arr[0]);
            int j = int.Parse(arr[1]);
            OthelloPiece player = Game.TurnPlayer;
            OthelloMove move = new OthelloMove(player, i, j);
            Game.AttemptMove(move);
        }
    }
}
