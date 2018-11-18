using lab2_00P_Osad.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    public abstract class BoardBuilder
    {
        public Board Board { get; private set; }
        public void CreateBoard()
        {
            Board = new Board();
            Game game = Game.getInstance();
            game.Boards.Add(Board);
        }
        public abstract void SetPoints();
        public abstract void SetName(string name);
        public abstract void SetCount();
        public abstract void SetIsBot();
    }
}
