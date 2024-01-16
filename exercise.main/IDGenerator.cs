using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal static class IDGenerator
    {
        private static int count = 0;
        public static int GetID()
        {
            count++;
            return count;
        }
        
    }
}
