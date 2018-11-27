using lab2_00P_Osad.Builders;
using lab2_00P_Osad.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Strategy
{
    public class Bot
    {
        private static Bot instance;
        private Bot() { }
        public IStrategy strategy { private get; set; }
        public static Bot getInstance()
        {
            if (instance == null)
                instance = new Bot();
            return instance;
        }
        public TurnInfo Shoot(Board board)
        {
            bool is_w = false;
            foreach (Point p in board.points)
            {
                if (p == Point.Wounded)
                {
                    is_w = true;
                    break;
                }
            }
            if (is_w)
                strategy = new TryToKill();
            else
                strategy = new NoWoundStrategy();

            return Start(board);
        }
        private TurnInfo Start(Board board)
        {
            return strategy.Shoot(board);
        }
    }
}