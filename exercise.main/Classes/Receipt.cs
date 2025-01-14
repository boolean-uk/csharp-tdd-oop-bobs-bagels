using exercise.main.Classes;

public class Receipt
{
    private int receiptWidth = 32;
    private string storeName = "Bob's Bagels";
    private string dateTime;
    private List<Tuple<string, string, string, decimal?>> receiptItems = new List<Tuple<string, string, string, decimal?>>();
    private char lineChar = '-';
    private char currency = '£';

    public Receipt(Basket basket, Inventory inventory)
    {
        dateTime = DateTime.Now.ToString();

        List<string> uniqueSkus = new List<string>();
        basket.GetProducts().ForEach(p => { if (!uniqueSkus.Contains(p.Sku)) { uniqueSkus.Add(p.Sku); } });

        foreach (string sku in uniqueSkus)
        {
            int skuCount = 0;
            basket.GetProducts().ForEach(p => { if (p.Sku == sku) { skuCount++; } });
            Tuple<string, string, string, decimal?> item = skuToItem(sku, skuCount, inventory);
            addItem(item.Item1, item.Item2, item.Item3, item.Item4);
        }
    }

    public decimal CalculateDiscount(string sku, int quantity)
    {
        if (sku == null || quantity == 0) return 0;

        decimal discount = 0;

        if (sku == "BGLP")
        {
            if (quantity >= 12)
            {
                int full12Sets = quantity / 12;
                discount += 0.69M * full12Sets;
            }

            int remainingAfter12 = quantity % 12;
            // 6 plain bagels will be more expensive for 2.49.
            /*if (remainingAfter12 >= 6)
            {
                int full6Sets = remainingAfter12 / 6;
                discount += 0.45M * full6Sets;
            }*/
        }
        else if (sku.StartsWith("BGL"))
        {
            if (quantity >= 12)
            {
                int full12Sets = quantity / 12;
                discount += 1.89M * full12Sets;
            }

            int remainingAfter12 = quantity % 12;
            if (remainingAfter12 >= 6)
            {
                int full6Sets = remainingAfter12 / 6;
                discount += 0.45M * full6Sets;
            }
        }

        return discount;
    }

    public Tuple<string, string, string, decimal?> skuToItem(string sku, int quantity, Inventory inventory)
    {
        string itemName = $"{inventory.GetProductVariant(sku)} {inventory.GetProductName(sku)}";
        string itemQuantity = quantity.ToString();
        decimal? originalPrice = inventory.GetProductPrice(sku) * quantity;
        decimal discount = CalculateDiscount(sku, quantity);
        decimal? finalPrice = originalPrice - discount;
        decimal? savings = originalPrice - finalPrice;

        string itemPrice = $"{currency}{finalPrice}";

        return new Tuple<string, string, string, decimal?>(itemName, itemQuantity, itemPrice, savings);
    }

    public void addItem(string itemName, string itemQuantity, string itemPrice, decimal? savings)
    {
        Tuple<string, string, string, decimal?> newItem = Tuple.Create(itemName, itemQuantity, itemPrice, savings);
        receiptItems.Add(newItem);
    }

    public string generateReceipt()
    {
        string receiptString = "";

        string banner = $"~~~ {storeName} ~~~";
        string dateTimeLine = dateTime;
        string line = new string(lineChar, receiptWidth);

        int sideSpacesLength = receiptWidth - banner.Length;
        string sideSpaces = new string(' ', sideSpacesLength / 2);

        receiptString += "\n";
        int bannerPadding = (receiptWidth - banner.Length) / 2;
        receiptString += $"{new string(' ', bannerPadding)}{banner}" + "\n\n";
        int dateTimePadding = (receiptWidth - dateTimeLine.Length) / 2;
        receiptString += $"{new string(' ', dateTimePadding)}{dateTimeLine}" + "\n";
        receiptString += line + "\n\n";

        foreach (var receiptItem in receiptItems)
        {
            string itemLine = $"{receiptItem.Item1,-16} {receiptItem.Item2,7} {receiptItem.Item3,7}";
            receiptString += itemLine + "\n";

            if (receiptItem.Item4 > 0)
            {
                string savingsAmount = $"{currency}{receiptItem.Item4:F2}";
                int paddingLength = 26 - savingsAmount.Length;
                string savingsLine = $"{new string(' ', paddingLength)}   (-{savingsAmount})";
                receiptString += savingsLine + "\n";
            }
        }

        receiptString += "\n" + line + "\n";

        decimal total = receiptItems.Sum(item => decimal.Parse(item.Item3.TrimStart(currency)));

        string totalAmount = $"{currency}{total:F2}";
        int paddingLength2 = 26 - totalAmount.Length;
        receiptString += $"Total{new string(' ', paddingLength2)} {totalAmount}\n\n";

        decimal totalSavings = receiptItems.Sum(item => item.Item4 ?? 0);

        string firstLine = "You saved a total of " + $"{currency}{totalSavings:F2}";
        int firstLinePadding = (receiptWidth - firstLine.Length) / 2;
        receiptString += $"{new string(' ', firstLinePadding)}{firstLine}" + "\n";

        string secondLine = "on this shop";
        int secondLinePadding = (receiptWidth - secondLine.Length) / 2;
        receiptString += $"{new string(' ', secondLinePadding)}{secondLine}" + "\n\n";

        string thirdLine = "Thank you";
        int thirdLinePadding = (receiptWidth - thirdLine.Length) / 2;
        receiptString += $"{new string(' ', thirdLinePadding)}{thirdLine}" + "\n";

        string fourthLine = "for your order!";
        int fourthLinePadding = (receiptWidth - fourthLine.Length) / 2;
        receiptString += $"{new string(' ', fourthLinePadding)}{fourthLine}" + "\n";

        return receiptString;
    }
}
