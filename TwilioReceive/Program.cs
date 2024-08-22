
using exercise.main;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwilioReceive
{
    public class TwilioApp : ISMSSender
    {
        private static BagelShop _bagelShop = new BagelShop();

        // Store user messages here
        private static Dictionary<string, MessageHistory> _messageHistories = new Dictionary<string, MessageHistory>();


        public static void Main(string[] args)
        {
            var task = RunSMSReceiver(args);
            task.Wait();
        }

        public static async Task RunSMSReceiver(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        // Credentials and phone numbers removed, need to fill in the blanks
        // if you want to use this method...
        public static async Task SendSMS(string orderMessage)
        {
            string accountSid = "";
            string authToken = "";
            string fromPhone = "";
            string toPhone = "";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: orderMessage,
                from: new Twilio.Types.PhoneNumber(fromPhone),
                to: new Twilio.Types.PhoneNumber(toPhone));

            AddMessageHistory(fromPhone, orderMessage, "Outgoing");
            Console.WriteLine(message);
        }

        public static string SMSBuilder(Basket basket)
        {
            var sb = new StringBuilder();
            Dictionary<string, ProductOrder> orders = basket.ProductOrders;

            sb.AppendLine("Thank you for order at Bob's Bagels");

            DateTime currentTime = DateTime.Now;
            DateTime x20MinsLater = currentTime.AddMinutes(20);

            sb.AppendLine($"Delivery time (est. 20 mins): {x20MinsLater}\n");

            sb.AppendLine("Order summary:");
            foreach (var (sku, po) in orders)
            {
                sb.AppendLine($"x{po.Amount} {po.Product.ToString()}: £{Math.Round(po.Cost - po.Discount, 2)}");
                if (po.Coffee != null)
                {
                    sb.AppendLine(" ~" + po.Coffee.ToString());
                }
                foreach (var filling in po.Fillings)
                {
                    sb.AppendLine(" ~" + filling.ToString());
                }
            }

            string total = $"\nTotal: £{basket.SumOfItems}";
            sb.AppendLine(total);

            return sb.ToString();
        }

        public static void AddMessageHistory(string phoneNr, string msg, string type)
        {
            if (!MessageHistories.ContainsKey(phoneNr)) MessageHistories.Add(phoneNr, new MessageHistory(phoneNr));

            if (type.Equals("Incoming")) MessageHistories[phoneNr].IncomingMessages.Add(msg);
            if (type.Equals("Outgoing")) MessageHistories[phoneNr].OutgoingMessages.Add(msg);
        }

        public static BagelShop BagelShop { get => _bagelShop; }
        public static Dictionary<string, MessageHistory> MessageHistories { get => _messageHistories; }
    }
}