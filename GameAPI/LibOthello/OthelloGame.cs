namespace LibOthello
{
    public class OthelloGame
    {
        public List<OthelloMove> Moves { get { return _moves; } }
        public const int BoardWidth = 8;
        public int[,] Board { get { return _board; } }

        public OthelloPiece TurnPlayer = OthelloPiece.Black;

        private List<OthelloMove> _moves = new List<OthelloMove>();
        private int[,] _board = new int[BoardWidth, BoardWidth];

        private CaptureAnalyst _captureAnalyst = new CaptureAnalyst();

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

        private void RefreshListOfAvailableMoves()
        {

        }

        public void AttemptMove(OthelloMove move)
        {
            if (MoveIsByTurnPlayer(move) && MoveIsValid(move))
            {
                PerformMove(move);
                RefreshListOfAvailableMoves();
            }
        }

        private void PerformMove(OthelloMove move)
        {
            return;
        }

        private bool MoveIsValid(OthelloMove move)
        {
            return false;
        }

        private bool MoveIsByTurnPlayer(OthelloMove move)
        {
            return false;
        }

        private int ParsePieceColour(OthelloPiece piece)
        {
            if (piece == OthelloPiece.Black)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
