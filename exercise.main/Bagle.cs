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

        public Bagle(bagleType btype) 
        {
            switch (btype) {
                case bagleType.BGLO:
                    this.cost= 0.49f;
                    this.name = "Onion Bagle";
                    break;
                case bagleType.BGLP:
                    this.cost = 0.39f;
                    this.name = "Plain Bagle";
                    break;
                case bagleType.BGLE:
                    this.cost = 0.49f;
                    this.name = "Everything Bagle";
                    break;
                case bagleType.BGLS:
                    this.cost = 0.49f;;
                    this.name = "Sesame Bagle";
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");

            }
        }

    }
}
