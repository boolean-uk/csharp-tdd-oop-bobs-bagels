namespace exercise.core;

public class Receipt
{
    private List<StoreItem> _purchasedItems = new List<StoreItem>();

    public Receipt(List<StoreItem> items)
    {
        this._purchasedItems = items;
    }

    public string GetReceiptText()
    {
        var rb = new System.Text.StringBuilder();
        rb.AppendLine("    ~~~ Bob's Bagels ~~~");
        rb.AppendLine();
        rb.AppendLine(DateTime.Now.ToString());
        rb.AppendLine();
        rb.AppendLine("----------------------------");
        rb.AppendLine();
        this._purchasedItems.ForEach(item => rb.AppendLine(item.ToString()));
        rb.AppendLine();
        rb.AppendLine("----------------------------");
        rb.AppendLine(
            $"      Total cost £{this._purchasedItems.Select(i => i.GetPrice()).Sum():F2}"
        );
        rb.AppendLine();

        var savedAmount = 0.0;
        foreach (StoreItem storeItem in this._purchasedItems)
        {
            if (storeItem is DiscountBundle discounted)
            {
                savedAmount += discounted.GetSavedAmount();
            }
        }
        rb.AppendLine($"You saved a total of {savedAmount:F2}");
        rb.AppendLine("on this trip");

        rb.AppendLine("Thank you");
        rb.AppendLine("for your order!");
        return rb.ToString();
    }

    public void PrintReceipt()
    {
        System.Console.Write(this.GetReceiptText());
    }
}
