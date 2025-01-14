using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Users
{
    public class CouldNotSelectProductExeption : Exception
    {
        public CouldNotSelectProductExeption()
        {
            
        }

        public CouldNotSelectProductExeption(string message) : base(message) 
        {
            
        }
    }
}
