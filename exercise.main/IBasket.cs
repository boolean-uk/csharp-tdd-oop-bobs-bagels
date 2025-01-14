using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal interface IBasket
    {
        bool AddBagelVariantToBasket(Bagel bagel);
        bool RemoveBagelVariantFromBasket(Bagel bagel);
        string BagelBasketIsFull();
        string ChangeBasketCapacity(int newCapacity);
        string CanRemoveItemInBasket(Inventory item);
        double TotalCostOfItems();
        double ReturnCostOfBagel(Bagel bagel);
        string ChooseBagelFilling(Filling filling);
        double CostOfEachFilling(Filling filling);
        bool MustBeInInventory(string sku);


    }
}
