using exercise.main;

namespace exercise.tests;

public class Seed
{
    public static void AddData(out Inventory inventory)
    {
        inventory = new Inventory();
        inventory.AddProduct(new Product("BGLO", "Onion Bagel", 0.49), 10);
        inventory.AddProduct(new Product("BGLP", "Plain Bagel", 0.39), 10);
        inventory.AddProduct(new Product("BGLE", "Everything Bagel", 0.49), 10);
        inventory.AddProduct(new Product("BGLS", "Sesame Bagel", 0.49), 10);
        inventory.AddProduct(new Product("COFB", "Black Coffee", 	0.99), 10);
        inventory.AddProduct(new Product("COFW", "White Coffee", 1.19), 10);
        inventory.AddProduct(new Product("COFC", "Capuccino", 1.29), 10);
        inventory.AddProduct(new Product("COFL", "Latte", 1.29), 10);
        
        ProductModification filb = new ProductModification("FILB", "Bacon", 0.12);
        ProductModification file = new ProductModification("FILE", "Egg", 0.12);
        ProductModification filc = new ProductModification("FILC", "Cheese", 0.12);
        ProductModification filx = new ProductModification("FILX", "Cream Cheese", 0.12);
        ProductModification fils = new ProductModification("FILS", "Smoked Salmon", 0.12);
        ProductModification filh = new ProductModification("FILH", "Ham", 0.12);
        
        List<ProductModification> modifications = new List<ProductModification> { filb, file, filc, filx, fils, filh };

        foreach (KeyValuePair<Product, int> inventoryItem in inventory)
        {
            var product = inventoryItem.Key;
            if (product.Sku.StartsWith("BGL"))
            {
                product.AllowedModifications = modifications;
            }
        }
    }
}