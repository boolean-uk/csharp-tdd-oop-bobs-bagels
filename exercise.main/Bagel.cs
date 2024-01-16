using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum BagelType { Onion, Plain, Everything, Sesame };
    public class Bagel : Product
    {
        Dictionary<BagelType, (double price, string SKU)> bagelToInfo = new Dictionary<BagelType, (double price, string SKU)>() 
        {
            { BagelType.Onion, ( 0.49d, "BGLO") },
            { BagelType.Plain, ( 0.39d, "BGLP") },
            { BagelType.Everything, (0.49d, "BGLE") },
            { BagelType.Sesame, (0.49d, "BGLS") }
        };

        private List<Filling> filling = new List<Filling>();
        BagelType _bagelType;

        public Bagel(BagelType bagel)
        {
            _bagelType = bagel;
        }
    }
    /*
    public class Onion : Bagel { public Onion() { SKU = "BGLO"; price = 0.49d; } }
    public class Plain : Bagel { public Plain() { SKU = "BGLP"; price = 0.39d; } }
    public class Everything : Bagel { public Everything() { SKU = "BGLE"; price = 0.49d; } }
    public class Sesame : Bagel { public Sesame() { SKU = "BGLS"; price = 0.49d; } } */
}