using lab2_00P_Osad.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
            Console.ReadKey();
        }
        public static void StartGame()
        {
            int level = Start();
            Game game = Game.getInstance();
            IObserver<bool> finobs = new finishObserver();
            (game as IObservable<bool>).Subscribe(finobs);
            IObserver<TurnInfo> botobs = new Bot_Observer();
            (game as IObservable<TurnInfo>).Subscribe(botobs);
            Builders.Director director = new Builders.Director();
            Builders.BoardBuilder BB;
            Builders.BoardBuilder UB;
            if (level == 0)
            {
                BB = new Builders.EasyBB();
                UB = new Builders.EasyUB();
            }
            else
            {
                BB = new Builders.MiddleBB();
                UB = new Builders.MiddleUB();
            }
            Builders.Board BotBoard = director.Create(BB, "BotBoard");
            Builders.Board UserBoard = director.Create(UB, "UserBoard");
            Builders.Board UserBoardPlay = director.Create(UB, "UserBoardPlay");
            Builders.Board BotBoardPlay = director.Create(UB, "BotBoardPlay");

            //Console.WriteLine(BotBoard.ToString());
            //Console.WriteLine(level);
            FillBoard(UserBoard);

            Console.WriteLine("SO NOW LET'S PLAY!");
            game.User_Turn();

        }
        private static int Start()
        {
            Console.WriteLine("Выберите уровень: Легий (0), Средний (1) ");
            try
            {
                int level = Convert.ToInt32(Console.ReadLine());
                if (level != 0 && level != 1)
                    return Start();
                else
                    return level;
            }
            catch
            {
                Console.WriteLine("Это ж вроде как не число -_- ");
                return Start();
            }
        }
        private static void FillBoard(Builders.Board UserBoard)
        {
            int x, y;
            Console.WriteLine("Fill your board:");
            Console.WriteLine("Enter x, than y");
            try
            {

                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                while (x != 101 || y != 101)
                {
                    Fill(UserBoard, UserBoard.Count, x, y);
                    Console.WriteLine("Enter x, than y, if you want to delete type -x and -y, enter 101 and 101 to finish");
                    x = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Это ж вроде как не число -_- ");
                FillBoard(UserBoard);
            }
        }

        private static int Check(Builders.Board UserBoard)
        {
            int x, n = UserBoard.Count;
            try
            {
                x = Convert.ToInt32(Console.ReadLine());
                if (x < 0 || x >= n)
                {
                    Console.WriteLine("Vne granizi");
                    FillBoard(UserBoard);
                }
                return x;

            }
            catch (FormatException)
            {
                Console.WriteLine("Это ж вроде как не число -_- ");
                FillBoard(UserBoard);
            }
            return -1;
        }

        private static void Fill(Builders.Board b, int count, int x, int y)
        {

            if ((x < 0 && y > 0) || (x > 0 && y < 0) || x < -count + 1 || y < -count + 1 || x > count - 1 || y > count - 1)
                Console.WriteLine("error to big number!");
            else if (x >= 0 && y >= 0)
                b.points[x, y] = Point.ALive;
            else
                b.points[Math.Abs(x), Math.Abs(y)] = Point.Empty;
            Console.WriteLine(b.ToString());
        }
    }
}