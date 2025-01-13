using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Communication
{
    public class ConsoleCommunicator : ICommunicator
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
