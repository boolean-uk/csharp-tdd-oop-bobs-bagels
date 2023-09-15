using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Filling
    {
        private string _type;

        public Filling(string type)
        {
            _type = type;
        }

        public string Type { get => _type; }
    }
}