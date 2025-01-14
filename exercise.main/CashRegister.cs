using exercise.main;
using exercise.main.Discount;

namespace exercise.tests
{
    public class CashRegister
    {

        private Inventory _inventory ;
        private DiscountManager _dm;
        private Order currentOrder;
        private Basket currentBasket;
        public CashRegister(Inventory inventory,DiscountManager dm)
        {
            _inventory = inventory;
            _dm= dm;
            currentOrder = null;
            currentBasket = null;
        }
        public void registerBasket(Basket basket)
        {

            var cacledBasket = this._dm.calculateTotalWithDiscount(basket);
            currentBasket = basket; 

            string ret = $"Pay:\n\t Total: {basket.getTotal()}";

            currentOrder = new Order(cacledBasket);

            Console.WriteLine(ret);
        }
        private string createReciept()
        {
            return currentOrder.createReciept(_inventory, currentBasket);
        }
        public string finalizePurchase(bool successfulPayment)
        {
            // Function is called to confirm the payment
            // If payment failed, successPayment will be false
            // This is just to demonstrate... it's not applicable in real life situation...

            string returnMsg = "";

            if(successfulPayment)
            {
                // return Reciept
                returnMsg = createReciept();
            }
            else
            {
                // return error message
                returnMsg = "You failed paying for your bagels...";
            }

            this.currentOrder = null;
            this.currentBasket = null;

            return returnMsg;
            //basket.
        }
    }
}