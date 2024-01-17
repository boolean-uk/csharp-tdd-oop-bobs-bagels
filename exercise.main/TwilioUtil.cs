using Twilio.Rest.Api.V2010.Account;

namespace exercise.main
{
    public static class TwilioUtil
    {
        private static Dictionary<string, Item> skuMap = new() {
            { "BGLO", new Bagel(BagelType.Onion) },
            { "BGLP", new Bagel(BagelType.Plain) },
            { "BGLE", new Bagel(BagelType.Everything) },
            { "BGLS", new Bagel(BagelType.Sesame) },
            { "COFB", new Coffee(CoffeeType.Black) },
            { "COFW", new Coffee(CoffeeType.White) },
            { "COFC", new Coffee(CoffeeType.Capuccino)},
            { "COFL", new Coffee(CoffeeType.Latte)},
            { "FILB", new Filling (FillingType.Bacon) },
            { "FILE", new Filling (FillingType.Egg) },
            { "FILC", new Filling (FillingType.Cheese) },
            { "FILX", new Filling(FillingType.CreamCheese) },
            { "FILS", new Filling(FillingType.SmokedSalmon) },
            { "FILH", new Filling(FillingType.Ham) },
        };
        public static string HandleNewOrder(string message)
        {
            Basket basket = new();
            foreach (string sku in message.Replace(" ", "").Split(',').ToList())
            {
                if (!skuMap.ContainsKey(sku)) { continue; }
                basket.AddItem(skuMap[sku]);
            }
            return basket.ReturnReceipt();
        }

        public static void SendSMS(string message)
        {
            MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+1234567890"),
                to: new Twilio.Types.PhoneNumber("+0987654321")
            );
        }
    }
}
