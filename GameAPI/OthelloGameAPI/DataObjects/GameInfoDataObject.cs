namespace OthelloGameAPI.DataObjects
{
    public class GameInfoDataObject
    {
        public int TurnPlayer { get; set; }

        public int ScoreBlack { get; set; }

        public int ScoreWhite { get; set; }

        public bool PlayerMustPass { get; set; }

        public bool GameOver { get; set; }
    }
}
