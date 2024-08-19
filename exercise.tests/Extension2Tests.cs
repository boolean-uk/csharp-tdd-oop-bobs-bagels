using exercise;
namespace exercise.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Extension2Tests
{
    private Inventory _inventory;
    public Extension2Tests()
    {
        _inventory = new Inventory();
    }

    [Test]
    public void PrintReceipt()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 25;
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("COFC");
        basket.AddProduct("FILE");
        basket.AddProduct("FILE");
        basket.AddProduct("FILE");
        basket.AddProduct("COFB");
        basket.AddProduct("FILS");
        basket.AddProduct("FILX");
        Receipt receipt = new Receipt();

        var disc = basket.GetTotalCost();
        receipt.PrintReceipt(basket.products, disc);

        // Capture the console output
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);

            var totalCost = basket.GetTotalCost();
            receipt.PrintReceipt(basket.products, totalCost);

            string output = stringWriter.ToString();

            // Check if the output contains the key elements of the receipt
            Assert.IsTrue(output.Contains("~~~ Bob's Bagels ~~~"));
            Assert.IsTrue(output.Contains("2024")); //Check date
            Assert.IsTrue(output.Contains("------------------------------------"));
            Assert.IsTrue(output.Contains("Smoked Salmon   Filling    1   £0,12"));
            Assert.IsTrue(output.Contains("Plain           Bagel      6   £2,49"));
            Assert.IsTrue(output.Contains("Black           Coffee     1   £0,99"));
            Assert.IsTrue(output.Contains("Total                          £5,37"));
            Assert.IsTrue(output.Contains("for your order!"));
        }
    }
}
