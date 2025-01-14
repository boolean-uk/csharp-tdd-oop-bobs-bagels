using exercise.main.Classes.Products;
using exercise.main.Classes;

public class Inventory
{
    public Inventory() {}

    public Product? GetProduct(string sku)
    {
        switch (sku.ToUpper())
        {
            case "BGLO":
                return new Bagel() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" };
            case "BGLP":
                return new Bagel() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" };
            case "BGLE":
                return new Bagel() { Sku = "BGLE", Price = 0.49M, Name = "Bagel", Variant = "Everything" };
            case "BGLS":
                return new Bagel() { Sku = "BGLS", Price = 0.49M, Name = "Bagel", Variant = "Sesame" };

            case "COFB":
                return new Coffe() { Sku = "COFB", Price = 0.99M, Name = "Coffe", Variant = "Black" };
            case "COFW":
                return new Coffe() { Sku = "COFW", Price = 1.19M, Name = "Coffe", Variant = "White" };
            case "COFC":
                return new Coffe() { Sku = "COFC", Price = 1.29M, Name = "Coffe", Variant = "Capuccino" };
            case "COFL":
                return new Coffe() { Sku = "COFL", Price = 1.29M, Name = "Coffe", Variant = "Latte" };

            case "FILB":
                return new Filling() { Sku = "FILB", Price = 0.12M, Name = "Filling", Variant = "Bacon" };
            case "FILE":
                return new Filling() { Sku = "FILE", Price = 0.12M, Name = "Filling", Variant = "Egg" };
            case "FILC":
                return new Filling() { Sku = "FILC", Price = 0.12M, Name = "Filling", Variant = "Cheese" };
            case "FILX":
                return new Filling() { Sku = "FILX", Price = 0.12M, Name = "Filling", Variant = "Cream Cheese" };
            case "FILS":
                return new Filling() { Sku = "FILS", Price = 0.12M, Name = "Filling", Variant = "Smoked Salmon" };
            case "FILH":
                return new Filling() { Sku = "FILH", Price = 0.12M, Name = "Filling", Variant = "Ham" };

            default:
                return null;
        }
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
