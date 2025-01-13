using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal interface IBasket
    {
        bool AddBagelVariantToBasket(Bagel bagelVariant);
        bool RemoveBagelVariantFromBasket(Bagel bagelVariant);
        string BagelBasketIsFull();
        string ChangeBasketCapacity(int newCapacity);
        string CanRemoveItemInBasket(Inventory item);
        double TotalCostOfItems();
        double ReturnCostOfBagel(Bagel bagelVariant);
        string ChooseBagelFilling(Filling bagelFilling);
        double CostOfEachFilling(Filling bagelFilling);
        bool MustBeInInventory(string sku);


    }
}
