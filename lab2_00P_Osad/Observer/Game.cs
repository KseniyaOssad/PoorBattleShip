using lab2_00P_Osad.Builders;
using lab2_00P_Osad.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Observer
{
    public class Game : IObservable<bool>, IObservable<TurnInfo>
    {
        public List<Board> Boards = new List<Board>();
        private static Game instance;
        private static List<IObserver<bool>> observers = new List<IObserver<bool>>();
        private static List<IObserver<TurnInfo>> shotObservers = new List<IObserver<TurnInfo>>();
        private Game() { }
        public static Game getInstance()
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }
        public void User_Turn()//ход юзера
        {
            Board usb = Boards.First(b => b.Name == "UserBoardPlay");
            Console.WriteLine(usb.ToString());
            Console.WriteLine("Ваш ход:");
            int x, y;
            Console.WriteLine("Введите х:");
            x = Fill_x(usb.Count);//проверка на нормальное хождение
            Console.WriteLine("Введите y:");
            y = Fill_x(usb.Count);//проверка на нормальное хождение
            if (usb.points[x, y] != Point.Empty)
            {
                Console.WriteLine("Туда нельзя");
                User_Turn();
            }
            string ti = Compare(x, y, true).Result;//смотрим результат хождения 
            if (ti == "Miss") Bot_Turn();
            else User_Turn();
        }
        public void Bot_Turn() //ход бота
        {
            Bot bot = Bot.getInstance();
            var ti = bot.Shoot(Boards.First(b => b.Name == "BotBoardPlay")); // даем боту походить
            string res = Compare(ti.X, ti.Y, false).Result;//смотрим результат хождения 
            if (res == "Miss") User_Turn();
            else Bot_Turn();
        }
        private TurnInfo Compare(int x, int y, bool is_user)
        {
            //берем нужные доски в зависимости от того кто ходит
            Board board;
            Board boardPlay;
            if (is_user)
            {
                board = Boards.First(b => b.Name == "BotBoard");
                boardPlay = Boards.First(b => b.Name == "UserBoardPlay");
            }
            else
            {
                board = Boards.First(b => b.Name == "UserBoard");
                boardPlay = Boards.First(b => b.Name == "BotBoardPlay");
            }
            TurnInfo ti = new TurnInfo();
            ti.X = x;
            ti.Y = y;
            if (board.points[x, y] == Point.Empty) //проверяем на промах
            {
                ti.Result = "Miss";
                boardPlay.points[x, y] = Point.Missed;
            }
            else
            {
                if (Is_alive(x, y, board, boardPlay)) //запускаем метод который проверяет на убитость
                {
                    ti.Result = "wound";
                    boardPlay.points[x, y] = Point.Wounded;
                }
                else
                {
                    ti.Result = "kill";
                }
            }
            foreach (var obs in shotObservers) //оповещаем подписчиков о результатах хода
            {
                obs.OnNext(ti);
            }
            Finish(board, boardPlay); //проверяем на окончание игры
            return ti;
        }
        private bool Is_alive(int x, int y, Board board, Board boardPlay)
        {
            //корабль горизонтальный?
            if ((x - 1 >= 0 && board.points[x - 1, y] != Point.Empty) || (x + 1 < board.Count && board.points[x + 1, y] != Point.Empty))
            {
                return Check(x, y, true, board, boardPlay);
            } //вертикальный?
            else if ((y - 1 >= 0 && board.points[x, y - 1] != Point.Empty) || (y + 1 < board.Count && board.points[x, y + 1] != Point.Empty))
            {
                return Check(x, y, false, board, boardPlay);
            }
            else //однопалубный
            {
                boardPlay.points[x, y] = Point.Dead; // значит он мертв
                DoNotPush(x, y, true, boardPlay, -1, -1); //ограждаем вокруг него чтоб не стреляли
                return false; //dead
            }
        }
        private bool Check(int x, int y, bool is_verticl, Board board, Board boardPlay)
        {
            int currxminus = x, curryminus = y;
            int currxplus = x, curryplus = y;
            if (is_verticl) //вертикальный
            {
                for (int i = x - 1; i >= 0; i--) //спускаемся вниз по кораблю
                {
                    if (board.points[i, y] == Point.ALive && boardPlay.points[i, y] == Point.Empty) //проверяем может он не убит
                    {
                        return true; //wound
                    }
                    else if (boardPlay.points[i, y] == Point.Wounded) // если он ранен записываем нижнюю точку корабля
                    {
                        currxminus = i;
                        curryminus = y;
                    }
                    else if (board.points[i, y] == Point.Empty) break; // он закончился тогда заканчиваем
                }
                for (int i = x + 1; i < board.Count; i++) // поднимаемся вверх по кораблю
                {
                    if (board.points[i, y] != Point.Empty && boardPlay.points[i, y] == Point.Empty)//проверяем может он не убит
                    {
                        return true; //wound
                    }
                    else if (boardPlay.points[i, y] == Point.Wounded)// если он ранен записываем верхнюю точку корабля
                    {
                        currxplus = i;
                        curryplus = y;
                    }
                    else if (board.points[i, y] == Point.Empty) break;// он закончился тогда заканчиваем
                }
            }
            else //все то же самое только он горизонтальный
            {
                for (int j = y - 1; j >= 0; j--)
                {
                    if (board.points[x, j] != Point.Empty && boardPlay.points[x, j] == Point.Empty)
                    {
                        return true; //wound
                    }
                    else if (boardPlay.points[x, j] == Point.Wounded)
                    {
                        currxminus = x;
                        curryminus = j;
                    }
                    else if (board.points[x, j] == Point.Empty) break;
                }
                for (int j = y + 1; j < board.Count; j++)
                {
                    if (board.points[x, j] != Point.Empty && boardPlay.points[x, j] == Point.Empty)
                    {
                        return true; //wound
                    }
                    else if (boardPlay.points[x, j] == Point.Wounded)
                    {
                        currxplus = x;
                        curryplus = j;
                    }
                    else if (board.points[x, j] == Point.Empty) break;
                }
            }
            //это все делалось для того чтоб отметить кораблик как мертвые (если он мертв)
            for (int i = currxminus; i <= currxplus; i++)// с его верхней (или левой) точки
            {
                for (int j = curryminus; j <= curryplus; j++) //по нижнюю (или правую)
                {
                    boardPlay.points[i, j] = Point.Dead;
                }
            }
            // выставляем точки в которые нелься пулить
            DoNotPush(currxminus, curryminus, false, boardPlay, currxplus, curryplus);
            return false; //корабль мертв
        }


        private static void DoNotPush(int x, int y, bool is_one, Board board, int x1, int y1)
        {
            //отмечаем места куда ходить нельзя вокруг метрвого корабля
            if (is_one)//однопалубный кораблик
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < board.Count && j >= 0 && j < board.Count && board.points[i, j] != Point.Dead)
                            board.points[i, j] = Point.DoNotPush;
                    }
                }
            }
            else
            {
                if (x == x1) //горизонтальный кораблик
                {
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y1 + 1; j++)
                        {
                            if (i >= 0 && i < board.Count && j >= 0 && j < board.Count && board.points[i, j] != Point.Dead)
                                board.points[i, j] = Point.DoNotPush;
                        }
                    }
                }
                else //вертикальный
                {
                    for (int i = x - 1; i <= x1 + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < board.Count && j >= 0 && j < board.Count && board.points[i, j] != Point.Dead)
                                board.points[i, j] = Point.DoNotPush;
                        }
                    }
                }
            }
        }
        private static int Fill_x(int n) //ход игрока
        {
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                if (x >= 0 && x < n) return x;
                else
                {
                    Console.WriteLine("Число вне доски, try again)");
                    return Fill_x(n);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Это ж вроде как не число -_- ");
                return Fill_x(n);
            }
        }

        IDisposable IObservable<bool>.Subscribe(IObserver<bool> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return null;
        }


        IDisposable IObservable<TurnInfo>.Subscribe(IObserver<TurnInfo> observer)
        {
            if (!shotObservers.Contains(observer))
                shotObservers.Add(observer);
            return null;
        }

        private void Finish(Board board, Board boardplay)
        {
            //окончание игры: если все живые клеточки у противника отмечены как мертвые на игральной доске тогда сообщаем подписчикам о конце игры
            for (int i = 0; i < board.Count; i++)
                for (int j = 0; j < board.Count; j++)
                {
                    if (board.points[i, j] == Point.ALive && boardplay.points[i, j] != Point.Dead)
                        return;
                }
            if (!board.is_bot)
                foreach (var obs in observers)
                    obs.OnNext(false);
            else
                foreach (var obs in observers)
                    obs.OnNext(true);
            Console.ReadLine();
        }
    }
}
