using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.Bagel;

namespace exercise.main
{
    public class Coffee : Item
    {
        public Coffee(string id, string name, string variant, double price) : base(id, name, variant, price) { }

        public override double getPrice()
        {
            return base.Price;
        }

        public override void addFilling(string order)
        {
            throw new Exception("Currently no filling for coffee");
        }
        public override void removeFilling(string order)
        {
            throw new Exception("Currently no filling for coffee");
        }

        public override List<Filling> getFillings()
        {
            throw new Exception("Currently no filling for coffee");
        }
    }
}
