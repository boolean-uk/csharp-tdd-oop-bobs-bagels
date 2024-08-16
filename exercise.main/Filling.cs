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
        FILH
    }
    public class Filling : Product
    {
        private float cost;
        private string name;

        public Filling(fillingType ftype)
        {
            switch (ftype)
            {
                case fillingType.FILB:
                    this.cost = 0.12f;
                    this.name = "Bacon";
                    break;
                case fillingType.FILE:
                    this.cost = 0.12f;
                    this.name = "Egg";
                    break;
                case fillingType.FILC:
                    this.cost = 0.12f;
                    this.name = "Cheese";
                    break;
                case fillingType.FILX:
                    this.cost = 0.12f; 
                    this.name = "Cream Cheese";
                    break;
                case fillingType.FILS:
                    this.cost = 0.12f;
                    this.name = "Smoked Salmon";
                    break;
                case fillingType.FILH:
                    this.cost = 0.12f;
                    this.name = "Ham";
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");

            }


        }
    }
}
