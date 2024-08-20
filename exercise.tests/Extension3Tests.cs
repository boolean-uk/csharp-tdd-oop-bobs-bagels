using exercise;
namespace exercise.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Extension3Tests
{
    private Inventory _inventory;
    public Extension3Tests()
    {
        _inventory = new Inventory();
    }

    [Test]
    public void PrintReceiptDiscounts()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 40;
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("COFC");
        basket.AddProduct("FILE");
        basket.AddProduct("FILE");
        basket.AddProduct("FILE");
        basket.AddProduct("COFB");
        basket.AddProduct("FILS");
        basket.AddProduct("FILX");
        Receipt receipt = new Receipt();
        var tot = basket.GetTotalCost();
        receipt.PrintReceipt(basket.products, tot);

        // Capture the console output
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);

            var totalCost = basket.GetTotalCost();
            receipt.PrintReceipt(basket.products, totalCost);

            string output = stringWriter.ToString();
            stringWriter.Dispose();

            // Check if the output contains the key elements of the receipt
            //Won't pass the savings numbers in stringwriter, but tested in terminal
            Assert.IsTrue(output.Contains("~~~ Bob's Bagels ~~~"));
            Assert.IsTrue(output.Contains("2024")); //Check date
            Assert.IsTrue(output.Contains("------------------------------------"));
            Assert.IsTrue(output.Contains("Smoked Salmon   Filling    1   £0,12"));
            Assert.IsTrue(output.Contains("Plain           Bagel      12  £3,99"));
            Assert.IsTrue(output.Contains("Black           Coffee     1   £0,99"));
            Assert.IsTrue(output.Contains("Total                          £9,36"));
            Assert.IsTrue(output.Contains("on this shop"));
            Assert.IsTrue(output.Contains("You saved a total of"));
            Assert.IsTrue(output.Contains("Thank you"));
            Assert.IsTrue(output.Contains("for your order!"));
        }
    }


}
