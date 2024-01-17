using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public interface IFood
    {
        /// <summary>
        /// Gets the name of the type of food (E.g. Bagel, Coffee, Filling)
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the SKU of the food
        /// </summary>
        string Sku { get; }
        /// <summary>
        /// Gets the price of the food
        /// </summary>
        float Price { get; }
        /// <summary>
        /// Gets the name concatenated with the variant of the food
        /// </summary>
        string FullName { get; }
    }
}
