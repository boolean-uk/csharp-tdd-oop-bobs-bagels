using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum fillingType
    {
        FILB,
        FILE,
        FILC,
        FILX,
        FILS,
        FILH,
    }
    

    public class Fillings : Product
    {
        private readonly float cost;
        private string name;
        private fillingType type;

        public Fillings(fillingType ft) {
            switch (ft)
            {
                case fillingType.FILB:
                    this.cost = 0.12f;
                    this.name = "Bacon";
                    this.type = fillingType.FILB;
                    break;
                case fillingType.FILE:
                    this.cost = 0.12f;
                    this.name = "Egg";
                    this.type = fillingType.FILE;
                    break;
                case fillingType.FILC:
                    this.cost = 0.12f;
                    this.name = "Cheese";
                    this.type = fillingType.FILC;
                    break;
                case fillingType.FILX:
                    this.cost = 0.12f;
                    this.name = "Cream Cheese";
                    this.type = fillingType.FILX;
                    break;
                case fillingType.FILS:
                    this.cost = 0.12f;
                    this.name = "Smoked Salmon";
                    this.type = fillingType.FILS;
                    break;
                case fillingType.FILH:
                    this.cost = 0.12f;
                    this.name = "Ham";
                    this.type = fillingType.FILH;
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");
            }

        }

        public override string Name { get { return name; } }
        public fillingType Type { get { return type; } }
        public override float Cost { get { return cost; } }

        public override bool IsBagle { get { return false; } }
    }
}
