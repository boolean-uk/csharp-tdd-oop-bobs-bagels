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
        Receipt receipt = new Receipt(items);
        Assert.That(receipt, Is.Not.Null);
        Assert.That(receipt.ItemList, Has.Exactly(6).Items);
    }


    [Test]
    public void TestGetTotalPriceWithoutDiscounts()
    {
        float price = items.SelectMany(a => a.GetItems()).Sum(a => a.Price);
        Receipt receipt = new Receipt(items);
        Assert.That(receipt, Is.Not.Null);
        Assert.That(receipt.GetTotalPriceWithoutDiscounts(), Is.EqualTo(price).Within(0.0001f));
    }

    [Test]
    public void TestGetTotalPrice()
    {
        float price = 1.25f * 2 + .49f + .12f;
        Receipt receipt = new Receipt(items);
        Assert.That(receipt.GetTotalPrice(), Is.EqualTo(price).Within(0.0001f));

        List<Item> basket = [];
        AddNItem(basket, new Bagel("Everything", .49f), 12);
        AddNItem(basket, new Bagel("Plain", .39f), 7);
        AddNItem(basket, new Coffee("Black", .99f), 3);

        price = 3.99f + 2.49f + 1.25f + 2 * .99f;
        receipt = new Receipt(basket);

        Assert.That(receipt.ItemList.Sum(a => a.Value.Count), Is.EqualTo(basket.Count));
        Assert.That(receipt.GetTotalPrice(), Is.EqualTo(price).Within(.0001f));
    }

    private void AddNItem(List<Item> items, Item item, int n)
    {
        for (int i = 0; i < n; i++)
        {
            items.Add(item);
        }
    }
}
