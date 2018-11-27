using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    public class EasyBB : BoardBuilder
    {
        public override void SetName(string n)
        {
            Board.Name = n;
        }
        public override void SetCount()
        {
            Board.Count = 5;
        }
        public override void SetPoints()
        {
            Board.points = new Point[5, 5];
            Fill(Board.points);
        }
        public override void SetIsBot()
        {
            Board.is_bot = true;
        }
        public void Fill(Point[,] points)
        {
            Random a = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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
        }
    }
}
