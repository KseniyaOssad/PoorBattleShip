using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    public class EasyUB : BoardBuilder
    {
        public override void SetName(string n)
        {
            Board.Name = n;
        }
        public override void SetCount()
        {
            Board.Count = 5;
        }
        public override void SetIsBot()
        {
            Board.is_bot = false;
        }
        public override void SetPoints()
        {
            Board.points = new Point[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Board.points[i, j] = Point.Empty;
                }
            }
        }
    }
}
