using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BagelShop
    {
        private List<Basket> _baskets;

        public BagelShop() 
        {

            Basket basket = new Basket(20);
            basket.AddItem("BGLS");
            basket.AddItem("BGLS");
            basket.AddItem("BGLS");
            basket.AddItem("BGLS");
            basket.AddItem("BGLS");
            basket.AddItem("BGLO");
            basket.AddItem("BGLO");
            basket.AddItem("BGLO");
            basket.AddItem("BGLP");
            basket.AddItem("BGLP");
            basket.AddItem("BGLP");


            //basket.AddItem("COFC");
            Bagel b = (Bagel)basket.Items[0];
            b.AddFilling("FILB");
            b.AddFilling("FILB");
            Bagel b1 = (Bagel)basket.Items[6];
            b1.AddFilling("FILB");
            b1.AddFilling("FILA");
            b1.AddFilling("FILC");

            Receipt r = new Receipt(basket);
            r.PrintReceipt();


        }
    }
}
