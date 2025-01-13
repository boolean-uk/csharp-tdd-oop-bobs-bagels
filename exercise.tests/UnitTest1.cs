using exercise.main;
namespace exercise.tests;


public class Tests
{


    [Test]
    public void AddToBasket()
    {

        Basket basket = new Basket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.Add(bagel);
        Assert.That(basket.Items.Count(), Is.EqualTo(1));
    }
    [Test]
    public void RemoveFromBasket()
    {
        Basket basket = new Basket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.AddBagel(bagel);
        basket.AddBagel(bagel);
        basket.RemoveBagel(bagel);
        basket.RemoveBagel(bagel);
        Assert.That(basket.Items.Count(), Is.EqualTo(0));
    }
}