using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum bagleType
    {
        BGLO,
        BGLP,
        BGLE,
        BGLS,

    }
    public class Bagle : Product
    {
        private float cost;
        private string name;
        private bagleType type;

        public Bagle(bagleType bt)
        {
            switch (bt)
            {
                case bagleType.BGLO:
                    this.cost = 0.49f;
                    this.name = "Onion Bagle";
                    this.type = bagleType.BGLO;
                    break;
                case bagleType.BGLP:
                    this.cost = 0.39f;
                    this.name = "Plain Bagle";
                    this.type = bagleType.BGLP;
                    break;
                case bagleType.BGLE:
                    this.cost = 0.49f;
                    this.name = "Everything Bagle";
                    this.type = bagleType.BGLE;
                    break;
                case bagleType.BGLS:
                    this.cost = 0.49f;
                    this.name = "Sesame Bagle";
                    this.type = bagleType.BGLS;
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");
            }
        }

        public override string Name { get { return name; } }
        public bagleType Type { get { return type; } }
        public override float Cost {  get { return cost; } }

        public override bool IsBagle { get { return true; } }

        public override bool IsDrink { get { return false; } }
    }
 }
   

