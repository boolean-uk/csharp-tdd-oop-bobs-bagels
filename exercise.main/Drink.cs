using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{


        public enum drinkType
        {
            COFB,
            COFW,
            COFC,
            COFL,
        }
        public class Drink : Product
        {
            private float cost;
            private string name;
            private drinkType type;
            public Drink(drinkType dt)
            {
                switch (dt)
                {
                    case drinkType.COFB:
                        this.cost = 0.99f;
                        this.name = "Black Coffe";
                        this.type = drinkType.COFB;
                        break;
                    case drinkType.COFW:
                        this.cost = 1.19f;
                        this.name = "White Coffe";
                        this.type = drinkType.COFW;
                        break;
                    case drinkType.COFC:
                        this.cost = 1.29f;
                        this.name = "Capuccino";
                        this.type = drinkType.COFC;
                        break;
                    case drinkType.COFL:
                        this.cost = 1.29f;
                        this.name = "Latte";
                        this.type = drinkType.COFL;
                        break;
                    default:
                        throw new NotSupportedException("Incorrect input");
                }
            }
            public drinkType Type { get { return type; } }

            public override string Name { get { return name; } }
            public override float Cost { get { return cost; } }
        }
    
}
