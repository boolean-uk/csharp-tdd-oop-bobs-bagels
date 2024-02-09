using exercise.main;

namespace exercise.tests;

[TestFixture]
public class ReceiptTests
{
    Inventory inventory;
    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
    }


    [Test]
    public void TestPrintReceipt()
    {
        List<string> expectedReturn =
        [
            "~~~ Bob's Bagels ~~~",
            $"{DateTime.Now}",
            "----------------------------",
            "Onion Bagel 2 £0,98",
            "Plain Bagel 12 £3,99",
            "(-£0,69)",
            "Everything Bagel 6 £2,49",
            "(-£0,45)",
            "Black Coffee 3 £2,51",
            "(-£0,46)",
            "----------------------------",
            "Total £9,97",
            "",
            "You saved a total of £1,60",
            "",
            "Thank you for your order!",
        ];

        Basket basket = new Basket(inventory);
        basket.ChangeCapacity(40);

        for (int i = 0; i < 2; i++)
        {
            basket.AddProduct("BGLO");
        }
        for (int i = 0; i < 12; i++)
        {
            basket.AddProduct("BGLP");
        }
        for (int i = 0; i < 6; i++)
        {
            basket.AddProduct("BGLE");
        }
        for (int i = 0; i < 3; i++)
        {
            basket.AddProduct("COFB");
        }

        Receipt receipt = new Receipt(basket);

        Assert.That(receipt.PrintRecipt(), Is.EqualTo(expectedReturn));
    }

    [Test]
    public void TestPrintReceipt2()
    {
        List<string> expectedReturn =
        [
            "~~~ Bob's Bagels ~~~",
            $"{DateTime.Now}",
            "----------------------------",
            "Plain Bagel 16 £5,55",
            "(-£0,69)",
            "----------------------------",
            "Total £5,55",
            "",
            "You saved a total of £0,69",
            "",
            "Thank you for your order!",
        ];

        Basket basket = new Basket(inventory);
        basket.ChangeCapacity(20);


        for (int i = 0; i < 16; i++)
        {
            basket.AddProduct("BGLP");
        }

        Receipt receipt = new Receipt(basket);

        Assert.That(receipt.PrintRecipt(), Is.EqualTo(expectedReturn));
    }
    [Test]
    public void TestPrintReceiptWithFilling()
    {
        List<string> expectedReturn =
        [
            "~~~ Bob's Bagels ~~~",
            $"{DateTime.Now}",
            "----------------------------",
            "Onion Bagel 3 £2,07",
            "Bacon (£0,12)",
            "Egg (£0,12)",
            "Ham (£0,12)",
            "Cheese (£0,12)",
            "Bacon (£0,12)",
            "----------------------------",
            "Total £2,07",
            "",
            "You saved a total of £0",
            "",
            "Thank you for your order!",
        ];

        Basket basket = new Basket(inventory);
        basket.ChangeCapacity(20);


        for (int i = 0; i < 3; i++)
        {
            basket.AddProduct("BGLO");
        }
        basket.AddFilling(0, "FILB");
        basket.AddFilling(0, "FILE");
        basket.AddFilling(1, "FILH");
        basket.AddFilling(1, "FILC");
        basket.AddFilling(2, "FILB");

        Receipt receipt = new Receipt(basket);

        Assert.That(receipt.PrintRecipt(), Is.EqualTo(expectedReturn));
    }
}