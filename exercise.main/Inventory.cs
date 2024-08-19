using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        private static int _bagelstock;
        private static int _fillingstock { get; set; }
        private static int _coffestock { get; set; }

        public static int BagelStock { get => _bagelstock; set => _bagelstock = value; }
        public static int FillingStock { get => _fillingstock; set => _fillingstock = value; }
        public static int CoffeeStock { get => _coffestock; set => _coffestock = value; }

    }
}
