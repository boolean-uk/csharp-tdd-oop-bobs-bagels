using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;
using exercise.main;

namespace exercise.tests;

public class ReceiptTest
{
    private List<Item> items = [
        new Bagel("Everything", .49f),
        new Bagel("Sesame", .49f),
        new Coffee("Black", .99f),
        new Coffee("White", 1.19f),
    ];

    public ReceiptTest() 
    {
        Bagel bagel = new Bagel("Onion", .49f);
        bagel.AddFilling(new Filling("Bacon", .12f));
        items.Add(bagel);
    }

    [Test]
    public void TestGetReceipt()
    {
        Receipt receipt = Receipt.GetReceipt(items);
        Assert.IsNotNull(receipt);
        Assert.That(receipt.ItemList.Select(a => a.Value.Right), Has.Exactly(5).Items);
        Assert.That(receipt.ItemList.Select(a => a.Value.Right), Is.All.EqualTo(1));
    }


    [Test]
    public void TestGetTotalPriceWithoutDiscounts()
    {
        float price = items.Select(a => a.Price).Sum();
        Receipt receipt = Receipt.GetReceipt(items);
        Assert.IsNotNull(receipt);
        Assert.That(receipt.GetTotalPriceWithoutDiscounts(), Is.EqualTo(price));
    }
}
