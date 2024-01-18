using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : IProduct
    {
        List<Filling> filling = new List<Filling>();
        string _SKUName;
        float _basePrice;
        public Bagel(string SKU, float price)
        {
            _SKUName = SKU;
            _basePrice = price;
        }

        /// <summary>
        /// Return the total price of the Bagel object including all attached fillings
        /// </summary>
        /// <returns> <float> The total object price as a float </float></returns>

        public float GetPrice()
        {
            return _basePrice + filling.Sum(fill => fill.GetPrice());
        }

        /// <summary>
        /// Return the base price, i.e. excluding any subobjects like filling etc., of the Bagel object
        /// </summary>
        /// <returns><float>The base price of the object as a float</float></returns>

        public float GetBasePrice()
        { 
            return _basePrice;
        }

        /// <summary>
        /// Return the SKU tag for the Bagel object
        /// </summary>
        /// <returns><string>A string of a 4-character item identifier</string></returns>

        public string GetSKUName()
        {
            return _SKUName;
        }
        
        /// <summary>
        /// Retrieve a List of all Filling objects attached to the Bagel object.
        /// </summary>
        /// <returns><list type="Filling"> List of fillings </list></returns>
        public List<Filling> GetFilling() 
        {
            return filling;
        }

        /// <summary>
        /// Attempt to attach a provided filling object to the Bagel. 
        /// </summary>
        /// <param name="fill"> The filling object to be attached</param>
        /// <returns><bool>True if the filling was valid (non-zero price) and was successfully attached, otherwise return false</bool></returns>
        public bool AddFilling(Filling fill)
        {
            if (fill.GetPrice() > 0f)
            {
                int count1 = filling.Count;
                filling.Add(fill);
                int count2 = filling.Count;


                return count2 > count1;
            }
            else 
            {
                return false;
            }
        }
    }
}
