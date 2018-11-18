using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Observer
{
    class Bot_Observer : IObserver<TurnInfo>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(TurnInfo value)
        {
            Console.WriteLine($"Shot into ({value.X},{value.Y}) resulted in {value.Result}");
        }
    }
}
