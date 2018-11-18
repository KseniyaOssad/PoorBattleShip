using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Builders
{
    public class Director
    {
        public Board Create(BoardBuilder builder, string name)
        {
            builder.CreateBoard();
            builder.SetPoints();
            builder.SetName(name);
            builder.SetCount();
            builder.SetIsBot();
            return builder.Board;
        }
    }
}
