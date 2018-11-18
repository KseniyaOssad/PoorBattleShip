using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2_00P_Osad.Builders;
using lab2_00P_Osad.Observer;

namespace lab2_00P_Osad.Strategy
{
    public class NoWoundStrategy : IStrategy
    {
        public  TurnInfo Shoot(Board board)
        {
            Random r = new Random();
            while (true) {
                int x = r.Next(board.Count);
                int y = r.Next(board.Count);
                if ((board.points[x, y] != Point.Missed) && (board.points[x, y] != Point.Dead) && (board.points[x, y] != Point.DoNotPush))
                    return new TurnInfo() { X = x, Y = y };
            }
        }
    }
}
