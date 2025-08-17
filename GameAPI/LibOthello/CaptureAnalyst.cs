using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOthello
{
    internal class CaptureAnalyst
    {
        public int CountCapturesForMove(int ally, in int[,] board, int i, int j)
        {
            List<Tuple<int, int>> captures = CollectCapturesForMove(ally, board, i, j);
            return captures.Count;
        }

        public List<Tuple<int, int>> CollectCapturesForMove(int ally, in int[,] board, int i, int j)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            if (board[i, j] != 0)
            {
                return result;
            }

            for(int di=-1; di<=1; di++)
            {
                for(int dj=-1; dj<=1; dj++)
                {
                    if (di == 0 && dj == 0)
                    {
                        continue;
                    }
                    else
                    {
                        List<Tuple<int, int>> captures = CollectCapturesAlongDelta(ally, board, i, j, di, dj);
                        foreach(Tuple<int, int> capture in captures)
                        {
                            result.Add(capture);
                        }
                    }
                }
            }

            return result;
        }

        private bool ValidCoords(int i, int j)
        {
            if (0 <= i && i < 8)
            {
                if (0 <= j && j < 8)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Tuple<int, int>> CollectCapturesAlongDelta(int ally, in int[,] board, int i, int j, int di, int dj)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            i += di;
            j += dj;

            while (ValidCoords(i, j))
            {
                if (board[i, j] == 0)
                {
                    break;
                }
                else if (board[i,j] == ally)
                {
                    return result;
                }
                else
                {
                    Tuple<int, int> capture = Tuple.Create(i, j);
                    result.Add(capture);
                }

                i += di;
                j += dj;
            }

            result.Clear();
            return result;
        }
    }
}
