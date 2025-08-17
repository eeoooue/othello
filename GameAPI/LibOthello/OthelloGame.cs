namespace LibOthello
{
    public class OthelloGame
    {
        public List<OthelloMove> Moves { get { return _moves; } }
        public const int BoardWidth = 8;
        public int[,] Board { get { return _board; } }

        private List<OthelloMove> _moves = new List<OthelloMove>();
        private int[,] _board = new int[BoardWidth, BoardWidth];

        public OthelloGame()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for(int i=0; i< BoardWidth; i++)
            {
                for(int j=0; j<BoardWidth; j++)
                {
                    _board[i,j] = 0;
                }
            }

            _board[4, 3] = -1;
            _board[3, 4] = 1;
            _board[4, 3] = -1;
            _board[3, 4] = 1;
        }
    }
}
