namespace exercise.tests;
using exercise.main;

[TestFixture]
public class BagelTest
{
  

    [Test]
    public void AddFillingTest()
    {

        Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");

        string filling1 = "Bacon";
        string filling2 = "Egg";
        string filling3 = "Tuna";

        string added1 = bagel.AddFilling(filling1);
        string added2 = bagel.AddFilling(filling2);
        string added3 = bagel.AddFilling(filling3);
        

        Assert.That(added1, Is.EqualTo("Filling added"));
        Assert.That(added2, Is.EqualTo("Filling added"));
        Assert.That(added3, Is.EqualTo("Filling not in inventory"));
    }

    [Test]
    public void RemoveFillingTest()
    {
        Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");

        string filling1 = "Bacon";
        string filling2 = "Egg";
        string filling3 = "Cheese";
        string filling4 = "Tuna";

        string added1 = bagel.AddFilling(filling1);
        string added2 = bagel.AddFilling(filling2);
        string added3 = bagel.AddFilling(filling3);

        bool removed1 = bagel.RemoveFilling(filling1);
        bool removed2 = bagel.RemoveFilling(filling2);
        bool removed3 = bagel.RemoveFilling(filling3);
        bool removed4 = bagel.RemoveFilling(filling4);

        Assert.That(removed1, Is.True);
        Assert.That(removed2, Is.True);
        Assert.That(removed3, Is.True);
        Assert.That(removed4, Is.False);


    }

}