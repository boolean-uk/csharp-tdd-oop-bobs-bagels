using exercise.main.Discount;

namespace exercise.main
{
    public interface IStoreFront
    {
        
        Inventory inventory{ get; set; }
        DiscountManager discountManager{ get; set; }
        Basket basket { get; set; }
        void presentProducts();
        void presentDeals();
        void addToBasket(string skuu, int amount = 1);
        void removeFromBasket(string sku, int amount = 1);
        void changeCap(int amount);
        void showBasket();
        void run();
        void exit();
    }

}
