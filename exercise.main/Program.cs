using basket.main;

namespace exercise.main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Basket basket = new Basket();
            Receipt receipt = new Receipt(basket);

            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("COFB");
            basket.AddItemToBasket("COFB");
            basket.AddItemToBasket("COFB");
            basket.AddItemToBasket("COFL");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLP");
            basket.AddItemToBasket("BGLO");
            basket.AddItemToBasket("BGLO");
            basket.AddItemToBasket("FILH");
            
            

            receipt.PrintReceipt(); 
        }
    }
}
