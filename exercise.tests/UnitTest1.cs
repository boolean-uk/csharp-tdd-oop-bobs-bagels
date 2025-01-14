using exercise.core;

namespace exercise.tests;

public class TestUtils
{
    public static List<StoreItem> testItems()
    {
        return new List<StoreItem>
        {
            new StoreItem("COFB", "Coffee", "Black", 0.99),
            new StoreItem("COFW", "Coffee", "White", 1.19),
            new StoreItem("COFC", "Coffee", "Capuccino", 1.29),
            new StoreItem("COFL", "Coffee", "Latte", 1.29),
        };
    }

    public static List<Bagel> testBagels()
    {
        return new List<Bagel>
        {
            new Bagel("BGLO", "Bagel", "Onion", 0.49),
            new Bagel("BGLP", "Bagel", "Plain", 0.39),
            new Bagel("BGLE", "Bagel", "Everything", 0.49),
            new Bagel("BGLS", "Bagel", "Sesame", 0.49),
        };
    }

    public static List<BagelFilling> testFillings()
    {
        return new List<BagelFilling>
        {
            new BagelFilling("FILB", "Filling", "Bacon", 0.12),
            new BagelFilling("FILE", "Filling", "Egg", 0.12),
            new BagelFilling("FILC", "Filling", "Cheese", 0.12),
            new BagelFilling("FILX", "Filling", "Cream Cheese", 0.12),
            new BagelFilling("FILX", "Filling", "Smoked Salmon", 0.12),
            new BagelFilling("FILH", "Filling", "Ham", 0.12),
        };
    }
}
