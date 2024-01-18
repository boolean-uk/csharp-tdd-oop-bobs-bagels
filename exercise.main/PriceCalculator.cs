using exercise.main.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class PriceCalculator
    {
        /// <summary>
        /// Calculates the total sum of discounts based on Bob's Bagels' discount offers
        /// </summary>
        /// <param name="foods">A list of food items to calculate the total discount of</param>
        /// <returns>The total discount of the given list of food</returns>
        public static float CalculateDiscounts(List<IFood> foods)
        {
            float total = 0f;
            int bgloCount = foods.Count(x => x.Sku.Equals("BGLO"));
            int bglpCount = foods.Count(x => x.Sku.Equals("BGLP"));
            int bgleCount = foods.Count(x => x.Sku.Equals("BGLE"));

            total += MathF.Floor(bgloCount / 6) * 0.45f;
            total += MathF.Floor(bglpCount / 12) * 0.69f;
            total += MathF.Floor(bgleCount / 6) * 0.45f;
            if (foods.Count == 2 && foods.All(x => x is Bagel || x.Sku.Equals("COFB")))
            {
                total += 0.49f + 0.99f - 1.25f;
            }
            return total;
        }

        /// <summary>
        /// Calculates the total price of IFood items in a list, including discounts
        /// </summary>
        /// <param name="foods">A list of food items to sum</param>
        /// <returns>The sum of item prices with discounts subtracted</returns>
        public static float GetTotalPrice(List<IFood> foods)
        {
            return foods.Sum(x => x.Price) - CalculateDiscounts(foods);
        }
    }
}
