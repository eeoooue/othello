namespace LibOthello
{
    public class OthelloGame
    {
        public List<OthelloMove> AvailableMoves { get { return _availableMoves; } }
        public List<OthelloMove> MoveHistory { get { return _moveHistory; } }

        public const int BoardWidth = 8;
        public int[,] Board { get { return _board; } }

        public OthelloPiece TurnPlayer = OthelloPiece.Black;

        private List<OthelloMove> _availableMoves = new List<OthelloMove>();
        private List<OthelloMove> _moveHistory = new List<OthelloMove>();
        private int[,] _board = new int[BoardWidth, BoardWidth];

        private CaptureAnalyst _captureAnalyst = new CaptureAnalyst();

        public OthelloGame()
        {
            InitializeBoard();
            RefreshListOfAvailableMoves();
        }

        public OthelloGameState GetGameState()
        {
            return new OthelloGameState(this);
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

            _board[3, 3] = -1;
            _board[3, 4] = 1;
            _board[4, 3] = 1;
            _board[4, 4] = -1;
        }

        private void RefreshListOfAvailableMoves()
        {
            _availableMoves.Clear();
            int ally = ParsePieceColour(TurnPlayer);

            for (int i=0; i<BoardWidth; i++)
            {
                for(int j=0; j<BoardWidth; j++)
                {
                    int capturesAvailable = _captureAnalyst.CountCapturesForMove(ally, _board, i, j);
                    if (capturesAvailable > 0)
                    {
                        OthelloMove move = new OthelloMove(TurnPlayer, i, j);
                        _availableMoves.Add(move);
                    }
                }
            }
        }

        public bool TurnPlayerMustPass()
        {
            return AvailableMoves.Count == 0;
        }

        public bool AttemptMove(OthelloMove move)
        {
            if (MoveIsByTurnPlayer(move) && MoveIsValid(move))
            {
                PerformMove(move);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AttemptPass()
        {
            if (TurnPlayerMustPass())
            {
                EndTurn();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PerformMove(OthelloMove move)
        {
            int ally = ParsePieceColour(move.Colour);
            int i = move.Row;
            int j = move.Col;
            List<Tuple<int, int>> captures = _captureAnalyst.CollectCapturesForMove(ally, _board, i, j);
            foreach(Tuple<int, int> capture in captures)
            {
                FlipPieceAtPosition(capture.Item1, capture.Item2);
            }

            PlaceNewPiece(ally, i, j);
            EndTurn();
        }

        private void PlaceNewPiece(int colour, int i, int j)
        {
            _board[i, j] = colour;
        }

        private void EndTurn()
        {
            ChangeTurnPlayer();
            RefreshListOfAvailableMoves();
        }

        private void ChangeTurnPlayer()
        {
            if (TurnPlayer == OthelloPiece.Black)
            {
                TurnPlayer = OthelloPiece.White;
            }
            else
            {
                TurnPlayer = OthelloPiece.Black;
            }
        }

        private void FlipPieceAtPosition(int i, int j)
        {
            Board[i, j] *= -1;
        }

        private bool MoveIsValid(OthelloMove move)
        {
            return AvailableMoves.Contains(move);
        }

        private bool MoveIsByTurnPlayer(OthelloMove move)
        {
            return move.Colour == TurnPlayer;
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
