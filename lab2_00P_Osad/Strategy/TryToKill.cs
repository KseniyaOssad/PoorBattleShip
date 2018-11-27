using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2_00P_Osad.Builders;
using lab2_00P_Osad.Observer;

namespace lab2_00P_Osad.Strategy
{
    class TryToKill : IStrategy
    {
        public TurnInfo Shoot(Board board)
        {
            int x, y, x1 = -1, y1 = -1;
            bool is_one = true;
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board.Count; j++)
                {
                    if (board.points[i, j] == Point.Wounded)
                    {
                        if (j + 1 < board.Count && board.points[i, j + 1] == Point.Wounded)
                        {
                            x = i;
                            y = j;
                            x1 = i;
                            y1 = j + 1;
                            is_one = false;
                            return Killer(x, y, is_one, x1, y1, board);
                        }
                        else if (i + 1 < board.Count && board.points[i + 1, j] == Point.Wounded)
                        {
                            x = i;
                            y = j;
                            x1 = i + 1;
                            y1 = j;
                            is_one = false;
                            return Killer(x, y, is_one, x1, y1, board);

                        }
                        else
                        {
                            x = i;
                            y = j;
                            return Killer(x, y, is_one, x1, y1, board);
                        }
                    }
                }
            }
            return new TurnInfo();
        }
        private static TurnInfo Killer(int x, int y, bool is_one, int x1, int y1, Board board)
        {
            if (is_one)
            {
                if (x - 1 >= 0 && board.points[x - 1, y] == Point.Empty)
                    return new TurnInfo() { X = x - 1, Y = y };
                else if (y + 1 < board.Count && board.points[x, y + 1] == Point.Empty)
                    return new TurnInfo() { X = x, Y = y + 1 };
                else if (x + 1 < board.Count && board.points[x + 1, y] == Point.Empty)
                    return new TurnInfo() { X = x + 1, Y = y };
                else if (y - 1 >= 0 && board.points[x, y - 1] == Point.Empty)
                    return new TurnInfo() { X = x, Y = y - 1 };
            }
            else
            {
                if (x == x1)
                {
                    if (y - 1 >= 0 && board.points[x, y - 1] == Point.Empty)
                        return new TurnInfo() { X = x, Y = y - 1 };
                    else
                    {
                        for (int q = y1 + 1; q < board.Count; q++)
                        {
                            if (board.points[x, q] == Point.Empty)
                                return new TurnInfo() { X = x, Y = q };
                        }
                    }
                }
                else
                {
                    if (x - 1 >= 0 && board.points[x - 1, y] == Point.Empty)
                        return new TurnInfo() { X = x - 1, Y = y };
                    else
                    {
                        for (int q = x1 + 1; q < board.Count; q++)
                        {
                            if (board.points[q, y] == Point.Empty)
                                return new TurnInfo() { X = q, Y = y };
                        }
                    }
                }
            }
            return new TurnInfo();
        }
    }
}
