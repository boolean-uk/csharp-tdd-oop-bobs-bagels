using exercise.main.Classes;
using exercise.main.Classes.Products;

public class Receipt
{
    private int receiptWidth = 32;
    private string storeName = "Bob's Bagels";
    private string dateTime;
    private List<OrderItem> receiptItems = new List<OrderItem>();
    private char lineChar = '-';
    private char currency = '£';

    public Receipt(Order order)
    {
        dateTime = DateTime.Now.ToString();

        receiptItems = order.GetItems();
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
            if (receiptItem.Savings > 0)
            {
                string itemLine = $"{receiptItem.ItemName,-16} {receiptItem.Quantity,6} {$"{currency}{(receiptItem.Price - receiptItem.Savings)}",8:F2}";
                receiptString += itemLine + "\n";
                string savingsAmount = $"{currency}{receiptItem.Savings:F2}";
                int paddingLength = 26 - savingsAmount.Length;
                string savingsLine = $"{new string(' ', paddingLength)}   (-{savingsAmount})";
                receiptString += savingsLine + "\n";
            }
            else
            {
                string itemLine = $"{receiptItem.ItemName,-16} {receiptItem.Quantity,6} {$"{currency}{(receiptItem.Price)}",8:F2}";
                receiptString += itemLine + "\n";
            }
        }

        receiptString += "\n" + line + "\n";

        decimal? total = receiptItems.Sum(item => item.Price);
        string totalAmount = $"{currency}{total:F2}";
        int paddingLength2 = 26 - totalAmount.Length;
        receiptString += $"Total{new string(' ', paddingLength2)} {totalAmount}\n\n";

        decimal totalSavings = receiptItems.Sum(item => item.Savings ?? 0);
        string firstLine = $"You saved a total of {currency}{totalSavings:F2}";
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
