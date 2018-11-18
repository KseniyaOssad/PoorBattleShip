using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    class MiddleBB : BoardBuilder
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
            //One(a, points);
        }
        /*public void One(Random a, Enum[,] points)
        {
            int x = a.Next(0, 9);
            int y = a.Next(0, 9);
            if (points[x, y] == (Enum)Point.ALive)
                One(a, points);
            if (IsAlive(points, x, y))
                points[x, y] = Point.ALive;
            else One(a, points);

        }
        public bool IsAlive(Enum[,] points, int x, int y)
        {

            return true;
        }*/

        /*   public void Fill(Enum[,] points)
           {
               Random a = new Random();
               for (int i = 0; i < 10; i++)
               {
                   for (int j = 0; j < 10; j++)
                   {
                       points[i, j] = Point.Empty;
                   }
               }
               int x = a.Next(0, 9);
               int y = a.Next(0, 9);
               points[0, 1] = Point.ALive;
               points[0, 5] = Point.ALive;
               points[7, 4] = Point.ALive;
               for (int q = 0; q < 3; q++)
               {
                   points[q, 9] = Point.ALive;
                   points[8, q] = Point.ALive;

               }
               Iter(points, x, y, a, false, 0);
           }
           public void Iter(Enum[,] points, int x, int y, Random a, bool b, int i)
           {
               if (i < 4)
               {
                   Fil_2(points, x, y, a, false);
                   Iter(points, x, y, a, false, i+1);
               }
           }
           public void Fil_2(Enum[,] points, int x, int y, Random a, bool b)
           {
               int z = x, c = y;
               if (b)
               {
                   if (Try(points, x+1, y, z, c))
                       points[x+1, y] = Point.ALive;
                   else if (Try(points, x-1, y, z, c))
                       points[x-1, y] = Point.ALive;
                   else if (Try(points, x, y+1, z, c))
                       points[x-1, y] = Point.ALive;
                   else if (Try(points, x, y-1, z, c))
                       points[x-1, y] = Point.ALive;
                   else
                   {
                       points[x, y] = Point.Empty;
                       x = a.Next(0, 9);
                       y = a.Next(0, 9);
                       Fil_2(points, x, y, a, false);
                   }
               }
               else
               {
                   if (points[x, y] == (Enum)Point.ALive)
                   {
                       x = a.Next(0, 9);
                       y = a.Next(0, 9);
                       Fil_2(points, x, y, a, false);
                   }
                   else if ((x+1 < 10 && points[x+1, y] == (Enum)Point.ALive) || (x-1 > -1 && points[x-1, y] == (Enum)Point.ALive) || (y+1 < 10 && points[x, y+1] == (Enum)Point.ALive) || (y-1 > -1 && points[x, y-1] == (Enum)Point.ALive) || (y+1 < 10 && x+1 < 10 && points[x+1, y+1] == (Enum)Point.ALive) || (y-1 > -1 && x-1 > -1 && points[x-1, y-1] == (Enum)Point.ALive) || (y-1 > -1 && x+1 < 10 && points[x+1, y-1] == (Enum)Point.ALive) || (y+1 < 10 && x-1 > -1 && points[x-1, y+1] == (Enum)Point.ALive))
                   {
                       x = a.Next(0, 9);
                       y = a.Next(0, 9);
                       Fil_2(points, x, y, a, false);
                   }
                   else
                   {
                       Point.ALive;
                       Fil_2(points, x, y, a, true);
                   }
               }
           }
           public bool Try(Enum[,] points, int x, int y, int xx, int yy)
           {
               if ((x != -1 || y != -1) || (x+1 < 10 && x+1 != xx && points[x+1, y] != (Enum)Point.ALive) || (x-1 > -1 && x-1 != xx && points[x-1, y] != (Enum)Point.ALive) || (y+1 < 10 && y+1 != yy && points[x, y+1] != (Enum)Point.ALive) || (y-1 > -1 && y-1 != yy && points[x, y-1] != (Enum)Point.ALive) || (y+1 < 10 && x+1 < 10 && points[x+1, y+1] != (Enum)Point.ALive) || (y-1 > -1 && x-1 > -1 && points[x-1, y-1] != (Enum)Point.ALive) || (y-1 > -1 && x+1 < 10 && points[x+1, y-1] != (Enum)Point.ALive))
                   return true;
               else
                   return false;
           }*/
    }
}
