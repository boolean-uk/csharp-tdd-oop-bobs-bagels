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

        public static float GetTotalPrice(List<IFood> foods)
        {
            return foods.Sum(x => x.Price) - CalculateDiscounts(foods);
        }
    }
}
