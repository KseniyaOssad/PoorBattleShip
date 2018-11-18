using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    class EasyBB : BoardBuilder
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

            /*int x = a.Next(0, 4);
            int y = a.Next(0, 4);
            points[1, 0] = Point.ALive;
            points[4, 4] = Point.ALive;
            Iter(points, x, y, a, false, 0);*/
        }
       /* public void Iter(Enum[,] points, int x, int y, Random a, bool b, int i)
        {
            if (i < 2)
            {
                Fil_2(points, x, y, a, false);
                Iter(points, x, y, a, false, i++);
            }
        }
        public void Fil_2(Enum[,] points, int x, int y, Random a, bool b)
        {
            if (b)
            {
                    if (Try(points, x++, y, x, y))
                        points[x++, y] = Point.ALive;
                    else if (Try(points, x--, y, x, y))
                        points[x--, y] = Point.ALive;
                    else if (Try(points, x, y++, x, y))
                        points[x--, y] = Point.ALive;
                    else if (Try(points, x, y--, x, y))
                        points[x--, y] = Point.ALive;
                    else
                    {
                        points[x, y] = Point.Empty;
                        x = a.Next(0, 4);
                        y = a.Next(0, 4);
                        Fil_2(points, x, y, a, false);
                    }  
            }
            else
            {
                if (points[x, y] == (Enum)Point.ALive)
                {
                    x = a.Next(0, 4);
                    y = a.Next(0, 4);
                    Fil_2(points, x, y, a, false);
                }
                else if ((x++ < 5 && points[x++, y] == (Enum)Point.ALive) || (x-- > -1 && points[x--, y] == (Enum)Point.ALive) || (y++ < 5 && points[x, y++] == (Enum)Point.ALive) || (y-- > -1 && points[x, y--] == (Enum)Point.ALive) || (y++ < 5 && x++ < 5 && points[x++, y++] == (Enum)Point.ALive) || (y-- > -1 && x-- > -1 && points[x--, y--] == (Enum)Point.ALive) || (y-- > -1 && x++ < 5 && points[x++, y--] == (Enum)Point.ALive) || (y++ < 5 && x-- > -1 && points[x--, y++] == (Enum)Point.ALive))
                {
                    x = a.Next(0, 4);
                    y = a.Next(0, 4);
                    Fil_2(points, x, y, a, false);
                }
                else
                {
                    points[x, y] = Point.ALive;
                    Fil_2(points, x, y, a, true);
                }
            }
        }
        public bool Try(Enum[,] points, int x, int y, int xx, int yy)
        {
            if ((x != -1 || y != -1) || (x++ < 5 && x != xx && points[x++, y] != (Enum)Point.ALive) || (x-- > -1 && x != xx && points[x--, y] != (Enum)Point.ALive) || (y++ < 5 && y != yy && points[x, y++] != (Enum)Point.ALive) || (y-- > -1 && y != yy && points[x, y--] != (Enum)Point.ALive) || (y++ < 5 && x++ < 5 && points[x++, y++] != (Enum)Point.ALive) || (y-- > -1 && x-- > -1 && points[x--, y--] != (Enum)Point.ALive) || (y-- > -1 && x++ < 5 && points[x++, y--] != (Enum)Point.ALive))
                return true;
            else
                return false;
        }*/
    }
}
