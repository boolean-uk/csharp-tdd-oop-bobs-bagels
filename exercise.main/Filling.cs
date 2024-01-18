using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Item
    {
        //private Inventory inventory = new Inventory();
        public string Variant { get; private set; }


        public Filling(string variant) : base(0, "", "", "")
        {
            this.Variant = variant;
        }


    }

}