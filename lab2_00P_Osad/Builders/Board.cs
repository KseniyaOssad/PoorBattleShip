using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    public class Board
    {
        public int Count { get; set; }
        public Point[,] points { get; set; }
        public string Name { get; set; }
        public bool is_bot { get; set; }
        public override string ToString()
        {
            string str = Name + "\n";
            for (int i = 0; i <= Count; i++)
            {
                for (int j = 0; j <= Count; j++)
                {
                    if (i == 0)
                        str += (Math.Abs(j - 1)) + " |     ";
                    else if (j == 0)
                        str += (i - 1) + " | ";
                    else
                        str += points[i - 1, j - 1] + " | ";
                }
                str += "\n";
                str += "\n";
            }
            return str;
        }
    }
}
