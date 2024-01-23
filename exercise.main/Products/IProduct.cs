using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public interface IProduct
    {
        /// <summary>
        /// Return the total price of the IProduct object
        /// </summary>
        /// <returns> <float> The total object price as a float </float></returns>
        float GetPrice();

        /// <summary>
        /// Return the base price, i.e. excluding any subobjects like filling etc., of the IProduct object
        /// </summary>
        /// <returns><float>The base price of the object as a float</float></returns>
        float GetBasePrice();

        /// <summary>
        /// Return the SKU tag for the IProduct object
        /// </summary>
        /// <returns><string>A string of a 4-character item identifier</string></returns>
        string GetSKUName();
    }
}
