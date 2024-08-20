using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main
{
    public class Basket
    {

        private decimal _sum = 0;
        private int _maxCapacity = 15;
        private List<Item> _basketList = new List<Item>();
        public string DiscountReceipt()
        {
            StringBuilder sb = new StringBuilder();
            List<Item>bagelList = basketItems.FindAll(item => item.name == "Bagel");
            List<Item>coffeList = basketItems.FindAll(item => item.name == "Coffee");
            decimal totalSavings = 0;
            sb.AppendLine("   ~~~ Bob's Bagels ~~~\n");
            sb.AppendLine($"    {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            sb.AppendLine("----------------------------");
            if (basketItems.Count < 1)
            {
                sb.Append("Basket is empty");

            }
            foreach (var itemInBasket in basketItems)
            {
                
                if (itemInBasket.name=="Bagel" && bagelList.Count == 6)
                {
                    decimal oldPrice = itemInBasket.price;
                    decimal newPrice = 0.415m;
                    itemInBasket.price = (newPrice);
                    decimal savings = oldPrice - newPrice;
                    totalSavings = decimal.Add(totalSavings, savings);
                    sum = calcCurrentSum();
                    sb.AppendLine($"{itemInBasket.name,-16}{"",-4}£{itemInBasket.price,5:F2}");
                    sb.Append("You are eligible for a discount !! You have saved "+(savings)+" on this purchase"+ "\n");
                    break;
                }

              
            else if (itemInBasket.name == "Bagel" && bagelList.Count == 12)
                {

                    decimal oldPrice = itemInBasket.price;
                    decimal newPrice = 0.33m;
                    itemInBasket.price = (newPrice);
                    decimal savings = oldPrice - newPrice;
                    totalSavings = decimal.Add(totalSavings,savings);
                    sum = calcCurrentSum();
                    sb.AppendLine($"{itemInBasket.name,-16}{"",-4}£{itemInBasket.price,5:F2}");
                    sb.Append("You are eligible for a discount !! You have saved " + (savings) + " on this purchase" + "\n");
                    break;
                }


                    
    
                else if (itemInBasket.name =="Coffee" && bagelList.Count == coffeList.Count)
                {
                    decimal oldPrice = itemInBasket.price;
                    decimal newPrice = 0.75m;
                    itemInBasket.price = (newPrice);
                    decimal savings = oldPrice - newPrice;
                    totalSavings = decimal.Add(totalSavings,savings);
                    sum = calcCurrentSum();
                    sb.AppendLine($"{itemInBasket.name,-16}{"",-4}£{itemInBasket.price,5:F2}");
                    sb.Append("You are eligible for a discount !! You have saved " + (savings) + " on this purchase" + "\n");
                    break;
                }
                else
                {
                    sb.Append(itemInBasket.name + " " + itemInBasket.variant + " " + itemInBasket.price + basketItems.Count.ToString() + "\n");

                }


            }
            sb.AppendLine("----------------------------");
            sb.AppendLine($"Total{"",16}£{sum,5:F2}\n");
            sb.AppendLine($"Total Savings: {"",6}£{(totalSavings),5:F2}\n");
            sb.AppendLine("        Thank you");
            sb.AppendLine("      for your order!");

            return sb.ToString();
        }



        public string addItemToBasket(string itemName, string itemVariant)
        {
            StringBuilder sb = new StringBuilder();
            Item itemToAdd = inventory.itemList.FirstOrDefault(item => item.name == itemName && item.variant == itemVariant);
            if (!item_Exists(itemToAdd))
            {
                sb.Append("a " + itemName + " with this variant " + itemVariant + "does not exist");
            }
            if (basketItems.Count >= _maxCapacity)
            {
                sb.Append("basket currently full! consider changing its maximum capacity before adding order");
            }
            else
            {
                basketItems.Add(itemToAdd);
                sum += (itemToAdd.price);
                sb.Append("a " + itemName + " with a " + itemVariant + "has been added to basket !");
            }
            return sb.ToString();
        }



        public string removeItemFromBasket(string name, string itemVariant)
        {
            StringBuilder sb = new StringBuilder();
            Item itemToRemove = basketItems.FirstOrDefault(item => item.name == name && item.variant == itemVariant);
            if (itemToRemove == null)
            {
                sb.Append("item" + name + "that you want to remove does not exist");
            }

            if (basketItems.Count > 1)
            {
                basketItems.Remove(itemToRemove);
                sum -= (itemToRemove.price);
                sb.Append("item" + name + " has been removed successfully!");
            }
            else
            {
                sb.Append("basket is empty");
            }

            return sb.ToString();

        }

        public string printReceipt()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   ~~~ Bob's Bagels ~~~\n");
            sb.AppendLine($"    {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            sb.AppendLine("----------------------------");
            if (basketItems.Count < 1)
            {
                sb.Append("Basket is empty");
                
            }
            
            foreach (var item in basketItems)
            {
                sb.AppendLine($"{item.name,-16}{"",-4}£{item.price,5:F2}");
            }
            sb.AppendLine("----------------------------");
            sb.AppendLine($"Total{"",16}£{sum,5:F2}\n");
            return sb.ToString() ;


        }

        //public async Task sendReceiptAsSms()
        //{
        

        //    TwilioClient.Init(accountId, authToken);
        //    var message = await MessageResource.CreateAsync(
        //        body: DiscountReceipt(),
        //        from: new Twilio.Types.PhoneNumber("+"),
        //        to: new Twilio.Types.PhoneNumber("+")
        //    );
            


        //}

        //public string getLogs()
        //{
        //    StringBuilder sb = new StringBuilder();



        //    var messages = MessageResource.Read(dateSentAfter : DateTime.UtcNow.AddDays(-30));

        //    foreach (var message in messages)
        //    {
        //        sb.Append($"From: {message.From}, To: {message.To}, Body: {message.Body}, Date: {message.DateSent}");
        //    }
        //    return sb.ToString();
            
        //}

        //public async Task sendLogsinSms()
        //{


        //    TwilioClient.Init(accountId, authToken);
        //    var message = await MessageResource.CreateAsync(
        //        body: getLogs(),
        //        from: new Twilio.Types.PhoneNumber(""),
        //        to: new Twilio.Types.PhoneNumber("")
        //    );

        //}

        public string receiveSmsOrder(string fromNumber, string messageBody)
        {

            string[] message = messageBody.Split(" ");
            string itemName = message[0];
            string itemVariant = message[1];
            return addItemToBasket(itemName, itemVariant);
        }

        public void changeBasketCap(int newCap)
        {


            maxCapacity = newCap;

            if (basketItems.Count > maxCapacity)
            {
                basketItems.RemoveRange(maxCapacity, basketItems.Count - maxCapacity);
            }
        }


        public decimal getItemCost(string name, string variant)
        {
            Item item = inventory.itemList.FirstOrDefault(item => item.name == name && item.variant == variant);
            decimal price = item.price;
            return price;
        }

        public decimal calcCurrentSum()
        {

            decimal sum = 0;
            foreach (var item in basketItems)
            {
                sum = decimal.Add(item.price, sum);
            }

            return sum;




        }

        public bool item_Exists(Item item)
        {

            bool Itemexists = false;
            if (inventory.itemList.Contains(item))
            {
                Itemexists = true;
            }
            return Itemexists;
        }


        Inventory inventory = new Inventory();

        public List<Item> basketItems { get { return _basketList; } private set { _basketList = value; } }


        public int maxCapacity
        {
            get { return _maxCapacity; }
            private set { _maxCapacity = value; }
        }


        public decimal sum
        {
            get { return _sum; }
            private set { _sum = value; }
        }

        public Basket() { }


    }
}
