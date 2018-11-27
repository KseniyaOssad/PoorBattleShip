using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    public class MiddleBB : BoardBuilder
    {
        public override void SetName(string n)
        {
            Board.Name = n;
        }
        public override void SetCount()
        {
            Board.Count = 10;
        }
        public override void SetPoints()
        {
            Board.points = new Point[10, 10];
            Fill(Board.points);
        }
        public override void SetIsBot()
        {
            Board.is_bot = true;
        }
        public void Fill(Point[,] points)
        {
            Random a = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    points[i, j] = Point.Empty;
                }
            }
            points[0, 0] = Point.ALive;
            points[3, 4] = Point.ALive;
            points[2, 1] = Point.ALive;
            points[3, 1] = Point.ALive;
            points[0, 3] = Point.ALive;
            points[0, 4] = Point.ALive;
            points[5, 7] = Point.ALive;
            points[6, 7] = Point.ALive;
            for (int q = 1; q < 4; q++)
            {
                points[q, 9] = Point.ALive;
                points[8, q] = Point.ALive;

            }
            for (int q = 0; q < 4; q++)
            {
                points[6, q] = Point.ALive;
            }
        }
    }
}
