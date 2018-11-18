using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_00P_Osad.Observer
{
    class finishObserver : IObserver<bool>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(bool is_user)
        {
            if (is_user) Console.WriteLine("You win!");
            else Console.WriteLine("Bot win");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
