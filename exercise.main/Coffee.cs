using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Coffee : Item
    {
        
        public Coffee(string name, string itemID, string variant, float cost) 
            : base(name, itemID, variant, cost) 
        { 
           

        }

        
    }
}
