using exercise.main.Classes.Products;
using exercise.main.Classes;

public class Inventory
{
    private List<Product> products = new List<Product>();

    public Inventory()
    {
        // Bagels
        products.Add(new Bagel() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" });
        products.Add(new Bagel() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" });
        products.Add(new Bagel() { Sku = "BGLE", Price = 0.49M, Name = "Bagel", Variant = "Everything" });
        products.Add(new Bagel() { Sku = "BGLS", Price = 0.49M, Name = "Bagel", Variant = "Sesame" });

        // Coffes
        products.Add(new Coffe() { Sku = "COFB", Price = 0.99M, Name = "Coffe", Variant = "Black" });
        products.Add(new Coffe() { Sku = "COFW", Price = 1.19M, Name = "Coffe", Variant = "White" });
        products.Add(new Coffe() { Sku = "COFC", Price = 1.29M, Name = "Coffe", Variant = "Capuccino" });
        products.Add(new Coffe() { Sku = "COFL", Price = 1.29M, Name = "Coffe", Variant = "Latte" });

        // Fillings
        products.Add(new Filling() { Sku = "FILB", Price = 0.12M, Name = "Filling", Variant = "Bacon" });
        products.Add(new Filling() { Sku = "FILE", Price = 0.12M, Name = "Filling", Variant = "Egg" });
        products.Add(new Filling() { Sku = "FILC", Price = 0.12M, Name = "Filling", Variant = "Cheese" });
        products.Add(new Filling() { Sku = "FILX", Price = 0.12M, Name = "Filling", Variant = "Cream Cheese" });
        products.Add(new Filling() { Sku = "FILS", Price = 0.12M, Name = "Filling", Variant = "Smoked Salmon" });
        products.Add(new Filling() { Sku = "FILH", Price = 0.12M, Name = "Filling", Variant = "Ham" });
    }

    public Product? GetProduct(string sku)
    {
        Product? foundProduct = products.FirstOrDefault(product => product.Sku == sku);
        return foundProduct;
    }

    public bool ValidProduct(string sku)
    {
        return GetProduct(sku) != null;
    }

    public decimal? GetProductPrice(string sku)
    {
        var product = GetProduct(sku);
        return product?.Price;
    }

    public string? GetProductName(string sku)
    {
        var product = GetProduct(sku);
        return product?.Name;
    }

    public string? GetProductVariant(string sku)
    {
        var product = GetProduct(sku);
        return product?.Variant;
    }
}
