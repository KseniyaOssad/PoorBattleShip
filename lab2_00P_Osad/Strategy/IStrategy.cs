using lab2_00P_Osad.Builders;
using lab2_00P_Osad.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Strategy
{
    public interface IStrategy
    {
        TurnInfo Shoot(Board board);
    }
}