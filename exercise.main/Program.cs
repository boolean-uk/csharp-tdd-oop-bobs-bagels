

using System.Reflection.Emit;
using System.Reflection.Metadata;
using exercise.main.Classes;
using exercise.main.Classes.Products;
using Microsoft.VisualBasic;

namespace exercise.main;

public class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();
        Inventory inventory = new Inventory();
        Person person = new("Jone");
        Basket basket = person.GetBasket();

        #region Core

        /*1.
        As a member of the public,
        So I can order a bagel before work,
        I'd like to add a specific type of bagel to my basket.*/

        basket.AddProduct("BGLO", inventory);

        /*2.
        As a member of the public,
        So I can change my order,
        I'd like to remove a bagel from my basket.*/

        basket.RemoveProduct("BGLO");

        /*3.
        As a member of the public,
        So that I can not overfill my small bagel basket
        I'd like to know when my basket is full when I try adding an item beyond my basket capacity.*/

        for (int i = 0; i < 6; i++)
        {
            basket.AddProduct("BGLO", inventory);
        }

        /*4.
        As a Bob's Bagels manager,
        So that I can expand my business,
        I’d like to change the capacity of baskets.*/

        basket.ChangeCapacity(512);

        /*5.
        As a member of the public
        So that I can maintain my sanity
        I'd like to know if I try to remove an item that doesn't exist in my basket.*/

        basket.RemoveProduct("BGLP");

        /*6.
        As a customer,
        So I know how much money I need,
        I'd like to know the total cost of items in my basket.*/

        basket.TotalCost();

        /*7.
        As a customer,
        So I know what the damage will be,
        I'd like to know the cost of a bagel before I add it to my basket.*/

        shop.AskPrice("BGLO");

        /*8.
        As a customer,
        So I can shake things up a bit,
        I'd like to be able to choose fillings for my bagel.*/

        Bagel currentBagel = (Bagel) basket.GetProducts().First();
        currentBagel.AddFilling("FILB", inventory);

        /*9.
        As a customer,
        So I don't over-spend,
        I'd like to know the cost of each filling before I add it to my bagel order.*/

        shop.AskPrice("FILB");
        shop.AskPrice("FILE");
        shop.AskPrice("FILC");
        shop.AskPrice("FILX");
        shop.AskPrice("FILS");
        shop.AskPrice("FILH");

        /*10.
        As the manager,
        So we don't get any weird requests,
        I want customers to only be able to order things that we stock in our inventory.*/

        basket.AddProduct("Gold plated chicken nuggets", inventory);

        basket.Clear();
        // return;
        #endregion

        #region Extension 1: Discounts

        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);

        Order order1 = new Order(basket, inventory);
        Console.WriteLine($"Order total: {order1.GetOrderTotal()}");
        order1.ApplyDiscounts();
        Console.WriteLine("Applied discounts!");
        Console.WriteLine($"Order total: {order1.GetOrderTotal()}");

        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);


        Order order2 = new Order(basket, inventory);
        Console.WriteLine($"Order total: {order2.GetOrderTotal()}");
        order2.ApplyDiscounts();
        Console.WriteLine("Applied discounts!");
        Console.WriteLine($"Order total: {order2.GetOrderTotal()}");
        basket.Clear();
        // return;
        #endregion

        #region Extension 2: Receipts && Extension 3: Discount Receipts

        basket.ChangeCapacity(256);

        for (int i = 0; i < 128; i++)
        {
            basket.AddProduct("BGLO", inventory);
        }

        for (int i = 0; i < 64; i++)
        {
            basket.AddProduct("COFB", inventory);
        }

        for (int i = 0; i < 32; i++)
        {
            basket.AddProduct("FILB", inventory);
        }

        Order receiptOrder = new Order(basket, inventory);
        decimal? orderTotal = receiptOrder.GetOrderTotal();

        Receipt receipt = new Receipt(receiptOrder);
        string receiptOutput = receipt.generateReceipt();
        Console.WriteLine("\nReceipt:\n" + receiptOutput);

        #endregion
    }
}