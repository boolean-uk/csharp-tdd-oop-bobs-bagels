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

        public Drink(drinkType dtype)
        {
            switch (dtype)
            {
                case drinkType.COFB:
                    this.cost = 0.99f;
                    this.name = "Black Coffe";
                    break;
                case drinkType.COFW:
                    this.cost = 1.19f;
                    this.name = "White Coffe";
                    break;
                case drinkType.COFC:
                    this.cost = 1.29f;
                    this.name = "Capuccino";
                    break;
                case drinkType.COFL:
                    this.cost = 1.29f;
                    this.name = "Latte";
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");

            }
        }
    }
