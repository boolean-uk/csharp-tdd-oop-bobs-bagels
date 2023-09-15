using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Bagel
    {
        private string _type;
        private List<Filling> _fillings = new List<Filling>();

        public Bagel(string bagelType)
        {
            _type = bagelType;
        }

        public Bagel(string bagelType, List<string> fillingTypes)
        {
            _type = bagelType;
            fillingTypes.ForEach(t => _fillings.Add(new Filling(t)));
        }

        public string Type { get => _type; }

        public List<Filling> Fillings { get => _fillings; }
    }
}