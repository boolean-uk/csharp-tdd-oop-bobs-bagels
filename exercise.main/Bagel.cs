using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {

        private List<Filling> _fillings;

        public Bagel(string sku, double price, string name, string variant) : base(sku, price, name, variant)
        {
            this._fillings = new List<Filling>();

        }

        public override double CheckItemCost()
        {
            double fillingsSum = _fillings.Select((a) => a.CheckItemCost()).Sum();
            return Math.Round(fillingsSum + Price, 2);
        }

        public bool AddFilling(string sku)
        {
            Filling f = (Filling) Inventory.InventoryItems.Find(i => i.Sku == sku);
            if (f != null && f.GetType() == typeof(Filling))
            {
                this._fillings.Add(f);
                return true;

            }
            return false;
        }
        public bool RemoveFilling(string sku)
        {
            Filling f = this._fillings.First(i => i.Sku == sku);

            if (f!=null)
            {
                this._fillings.Remove(f);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string output = "";
            output += $"{Sku} - {Variant} {Name} : {Price}\n";
            foreach (Filling f in _fillings) 
            {
                output += $"{f.Variant} : {f.Price}\n";

            }
            return output;
        }

        public List<Filling> Fillings { get => _fillings; set => _fillings = value; }
    }
}
