using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BagelStore
    {
        private Manager _manager = new Manager("Joseph", "Bagelsson");

        public Manager getManager()
        {
            return _manager;
        }
    }
}
