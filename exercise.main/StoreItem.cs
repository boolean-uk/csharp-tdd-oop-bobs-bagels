namespace exercise.core;

public class StoreItem
{
    public string ProductCode { get; init; }
    public string Name { get; init; }
    public string Variant { get; init; }
    protected double _price;

    public StoreItem(string code, string name, string variant, double price)
    {
        if (code.Length != 4)
        {
            throw new ArgumentException("Product code must have 4 characters");
        }
        this.ProductCode = code;
        this.Name = name;
        this.Variant = variant;
        this._price = price;
    }

    public virtual IReadOnlyCollection<StoreItem> GetItemsFlattened()
    {
        return new List<StoreItem> { this }.AsReadOnly();
    }

    public virtual double GetPrice()
    {
        return this._price;
    }

    public override string ToString()
    {
        return $"{Variant} {Name} £{_price:F2}";
    }
}

public class Bagel : StoreItem
{
    private List<BagelFilling> _fillings = new List<BagelFilling>();

    public Bagel(string code, string name, string variant, double price)
        : base(code, name, variant, price)
    {
        if (name != "Bagel")
        {
            throw new ArgumentException("bagel name must be bagel");
        }
        if (code.Substring(0, 3).ToLower() != "bgl")
        {
            throw new ArgumentException("Bagel SKU must start with bgl");
        }
    }

    public override double GetPrice()
    {
        return this._fillings.Select((filling) => filling.GetPrice()).Sum() + this._price;
    }

    public override IReadOnlyCollection<StoreItem> GetItemsFlattened()
    {
        return this._fillings.Concat(new List<StoreItem> { this }).ToList().AsReadOnly();
    }

    // Fillings shouldn't count towards basket capacity
    public void AddFilling(BagelFilling filling)
    {
        this._fillings.Add(filling);
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{Variant} {Name} £{_price:F2}");
        foreach (BagelFilling filling in this._fillings)
        {
            sb.AppendLine($"  {filling.ToString():F2}");
        }
        return sb.ToString();
    }
}

public interface NonDiscountable { }

public class BagelFilling : StoreItem, NonDiscountable
{
    public BagelFilling(string code, string name, string variant, double price)
        : base(code, name, variant, price)
    {
        if (name != "Filling")
        {
            throw new ArgumentException("Filling name must be filling");
        }
        if (code.Substring(0, 3).ToLower() != "fil")
        {
            throw new ArgumentException($"Bagel filling SKU must start with FIL, got {code}");
        }
    }
}
