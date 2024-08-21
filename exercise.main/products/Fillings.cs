using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.products
{


    public class Fillings : Product
    {
        private readonly float cost;
        private string name;
        private productType type;

        public Fillings(productType ft)
        {

            if (ft == productType.FILB)
            {
                cost = 0.12f;
                name = "Bacon";
                type = productType.FILB;
            }
            else if (ft == productType.FILE)
            {
                cost = 0.12f;
                name = "Egg";
                type = productType.FILE;
            }
            else if (ft == productType.FILC)
            {
                cost = 0.12f;
                name = "Cheese";
                type = productType.FILC;
            }
            else if (ft == productType.FILX)
            {
                cost = 0.12f;
                name = "Cream Cheese";
                type = productType.FILX;
            }
            else if (ft == productType.FILS)
            {
                cost = 0.12f;
                name = "Smoked Salmon";
                type = productType.FILS;
            }
            else if (ft == productType.FILH)
            {
                cost = 0.12f;
                name = "Ham";
                type = productType.FILH;
            }
            else
            {
                throw new NotSupportedException("Incorrect input");
            }



        }

        public override string Name { get { return name; } }
        public override productType Type { get { return type; } }
        public override float Cost { get { return cost; } }
    }
}
