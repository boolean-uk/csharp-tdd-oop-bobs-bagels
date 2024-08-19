using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private int _bagelstock;
        private int _fillingstock { get; set; }
        private int _coffestock { get; set; }

        public int BagelStock { get => _bagelstock; set => _bagelstock = value; }
        public int FillingStock { get => _fillingstock; set => _fillingstock = value; }
        public int CoffeeStock { get => _coffestock; set => _coffestock = value; }


    }
}
