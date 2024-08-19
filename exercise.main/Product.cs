using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public enum productType
    {
        BGLO,
        BGLP,
        BGLE,
        BGLS,
        COFB,
        COFW,
        COFC,
        COFL,
        FILB,
        FILE,
        FILC,
        FILX,
        FILS,
        FILH,
    }
    public class Product
    {
        private float cost;
        private string name;
        private productType type;
        public Product(productType ptype)
        {
            switch (ptype)
            {
                case productType.BGLO:
                    this.cost = 0.49f;
                    this.name = "Onion Bagle";
                    this.type = productType.BGLO;
                    break;
                case productType.BGLP:
                    this.cost = 0.39f;
                    this.name = "Plain Bagle";
                    this.type = productType.BGLP;
                    break;
                case productType.BGLE:
                    this.cost = 0.49f;
                    this.name = "Everything Bagle";
                    this.type = productType.BGLE;
                    break;
                case productType.BGLS:
                    this.cost = 0.49f;
                    this.name = "Sesame Bagle";
                    this.type = productType.BGLS;
                    break;
                case productType.COFB:
                    this.cost = 0.99f;
                    this.name = "Black Coffe";
                    this.type = productType.COFB;
                    break;
                case productType.COFW:
                    this.cost = 1.19f;
                    this.name = "White Coffe";
                    this.type = productType.COFW;
                    break;
                case productType.COFC:
                    this.cost = 1.29f;
                    this.name = "Capuccino";
                    this.type = productType.COFC;
                    break;
                case productType.COFL:
                    this.cost = 1.29f;
                    this.name = "Latte";
                    this.type = productType.COFL;
                    break;
                case productType.FILB:
                    this.cost = 0.12f;
                    this.name = "Bacon";
                    this.type = productType.FILB;
                    break;
                case productType.FILE:
                    this.cost = 0.12f;
                    this.name = "Egg";
                    this.type = productType.FILE;
                    break;
                case productType.FILC:
                    this.cost = 0.12f;
                    this.name = "Cheese";
                    this.type = productType.FILC;
                    break;
                case productType.FILX:
                    this.cost = 0.12f;
                    this.name = "Cream Cheese";
                    this.type = productType.FILX;
                    break;
                case productType.FILS:
                    this.cost = 0.12f;
                    this.name = "Smoked Salmon";
                    this.type = productType.FILS;
                    break;
                case productType.FILH:
                    this.cost = 0.12f;
                    this.name = "Ham";
                    this.type = productType.FILH;
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");
            }
        }

        public string Name { get { return name; } }
        public float Cost { get { return cost; } }

        public productType Type { get { return type; } }
    }
}
