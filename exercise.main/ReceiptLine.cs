using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class ReceiptLine
    {
        private string _name;
        private float _price;

        private Dictionary<List<Filling>, int> combinations = new Dictionary<List<Filling>, int>();
        public string Name { get { return _name; } }

        public ReceiptLine(string name, float price, List<Filling> fillings)
        {
            _name = name;
            combinations.Add(fillings, 1);
            _price = price;
        }

        public void AddProduct(List<Filling> fillings)
        {
            if (combinations.Any(x => x.Key.All(fillings.Contains) && fillings.All(x.Key.Contains)))
            {
                combinations[combinations.First(x => x.Key.All(fillings.Contains) && fillings.All(x.Key.Contains)).Key] ++;
            }
            else
            {
                combinations.Add(fillings, 1);
            }
        }

        public string Print()
        {
            string result = "";
            foreach (KeyValuePair<List<Filling>, int> combination in combinations)
            {
                result += PrintFilling(combination.Key, combination.Value);
                result += "\n";
            }
            return result;
        }

        private string PrintFilling(List<Filling> currentCombo, int amount)
        {
            string result = PrintProduct(amount);
            foreach (Filling filling in currentCombo)
            {
                result += "\n\t" + filling.Variant;
            }
            return result;

        }
        public string PrintProduct(int amount)
        {
            int letterAmount = _name.Count();
            string whiteSpace = "";
            for (int i = letterAmount; i < 20; i++)
                whiteSpace += " ";
            string secondWhiteSpace = "";
            for (int i = amount.ToString().Length; i < 4; i++)
                secondWhiteSpace += " ";
            return _name + whiteSpace + amount + secondWhiteSpace + "€" + (_price * amount);

        }
    }
}
