namespace exercise.core;

public class DiscountContainer
{
    public List<Discount> discounts = new List<Discount>();

    public void AddDiscount(Discount discount)
    {
        this.discounts.Add(discount);
        this.discounts = this.discounts.OrderByDescending(disc => disc.priority).ToList();
    }

    public List<StoreItem> ApplyDiscounts(List<StoreItem> items)
    {
        List<StoreItem> discounted = new List<StoreItem>();
        List<StoreItem> nonDiscounted = new List<StoreItem>(items);

        foreach (Discount disc in this.discounts)
        {
            bool applicable = true;
            foreach ((Predicate<StoreItem> pred, int amount) in disc.DiscountRequirement)
            {
                if (nonDiscounted.Where(it => pred(it)).Count() < amount)
                {
                    applicable = false;
                    break;
                }
            }

            if (applicable)
            {
                List<StoreItem> toBundle = new List<StoreItem>();
                foreach ((Predicate<StoreItem> pred, int amount) in disc.DiscountRequirement)
                {
                    for (int i = 0; i < amount; i++)
                    {
                        var toDiscount = nonDiscounted.Find(pred);
                        if (toDiscount == null)
                        {
                            throw new Exception("oops");
                        }
                        nonDiscounted.Remove(toDiscount);
                        toBundle.Add(toDiscount);
                    }
                }
                discounted.Add(new DiscountBundle(toBundle, disc.newPrice));
            }
        }
        return nonDiscounted.Concat(discounted).ToList();
    }
}

public class Discount
{
    public required List<(
        Predicate<StoreItem> requiredItem,
        int requiredAmount
    )> DiscountRequirement { get; init; }
    public required double newPrice { get; init; }
    public required int priority { get; init; }
}

public class DiscountBundle : StoreItem
{
    private List<StoreItem> _storeItems;
    private double _oldPrice;

    public DiscountBundle(
        string code,
        string name,
        string variant,
        double newPrice,
        double oldPrice
    )
        : base(code, name, variant, newPrice)
    {
        this._storeItems = new List<StoreItem>();
        this._oldPrice = oldPrice;
    }

    public DiscountBundle(List<StoreItem> items, double newPrice)
        : base("DISC", "Discount", "", newPrice)
    {
        this._storeItems = items;
        this._oldPrice = items.Sum(it => it.GetPrice());
    }

    public override double GetPrice()
    {
        var nonDiscounted = 0.0;
        foreach (StoreItem item in this._storeItems)
        {
            foreach (StoreItem flat in item.GetItemsFlattened())
            {
                if (flat is NonDiscountable)
                {
                    nonDiscounted += flat.GetPrice();
                }
            }
        }
        return this._price + nonDiscounted;
    }

    public void AddItem(StoreItem storeItem)
    {
        this._storeItems.Add(storeItem);
    }

    public void SetNewPrice(double newPrice)
    {
        this._price = newPrice;
    }

    public override IReadOnlyCollection<StoreItem> GetItemsFlattened()
    {
        return base.GetItemsFlattened();
    }

    public double GetSavedAmount()
    {
        return this._oldPrice - this._price;
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine();

        foreach (StoreItem discounted in this._storeItems)
        {
            sb.Append(discounted.ToString());
        }
        sb.AppendLine($"             - £({this.GetSavedAmount():F2})");
        sb.AppendLine();
        return sb.ToString();
    }
}
