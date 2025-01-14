using System.Globalization;

namespace exercise.main
{
    public class Order
    {
        private Dictionary<string, OrderData> _orderDatas;
        public Order(Dictionary<string, OrderData> orderDatas)
        {
            _orderDatas = orderDatas;
        }

        private string centeredText(string text, int width)
        {
            int calcedPadd = (width - text.Length) / 2;
            string padding = $"0,{calcedPadd}";
            return string.Format(
                $"{{{padding}}}{text}","");

        }

        private string maxLenNewLine(string text, int maxSize)
        {
            int nrOfNewLines = text.Length / maxSize;
            string newText = "";
            for (int i = 0;i < text.Length; i++)
            {
                if (i % maxSize == 0)
                    newText += "\n";

                newText += text[i];
                
            }
            return newText;
        }
        public string createReciept(Inventory inventory, Basket basket)
        {
            string line = "----------------------------";
            int width = line.Length;

            string title = centeredText("~~~ Bob's Bagels ~~~", width);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);

            string pline = centeredText(line, width);

            string ret = $"{title}\n\n{centeredText(DateTime.Now.ToString(), width)}\n\n{pline}";
            
            foreach (var x in _orderDatas.ToList())
            {
                if (x.Value.UsedDiscount == null)
                {
                    ret += "\n" + string.Format(
                        "{0,-20} {1,5} {2,8:c}", 
                        inventory.getProductType(x.Value.name)+" "+ inventory.getName(x.Value.name), 
                        x.Value.amount, 
                        "£"+x.Value.total_price
                    );
                }
                else
                {

                    int dealWidth = 22;
                    string dealText = maxLenNewLine(x.Value.UsedDiscount.stringify(), dealWidth);
                    int dealpad = dealText.Split("\n").Last().Length;

                    ret += "\n" + string.Format($"{{0,-20}} ",
                        dealText
                        );
                    ret +=  string.Format($"{{0,{(-20 + dealpad) }}}{{1,5}}{{2,8:c}}",
                        "",
                        x.Value.amount, 
                        x.Value.total_price
                        )+ "\n";
     
                    ret += string.Format($"{{0,-20}}{{1,5}}({{2,8:c}})", "", "", MathF.Round(x.Value.saving, 2)); 
   
                }
            }

            ret += string.Format("\n\n{0}\n\nTotal: {1,20:c}", pline, basket.getTotal());
            ret += string.Format("\n\n{0}\n{1}", centeredText("Thank you", width), centeredText("for your order!",width));
            return ret; 
        }
    }




}
