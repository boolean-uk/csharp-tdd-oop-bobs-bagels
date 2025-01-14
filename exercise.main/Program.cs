using System.Net.Mail;
using System.Reflection;
using exercise.main;

string SKU1 = "BGLO";
string SKU2 = "COFB";
string SKU3 = "FILC";

Shop s = new Shop();
Person m = new Person("Manager");

Dictionary<string, int> discountItems = new Dictionary<string, int> 
            {{"BGLO", 1}, {"COFB", 1}, {"FILC", 1}};
double discountPrice = 1;

s.NewDiscount(discountItems, discountPrice, m);

s.AddItem(SKU1, m);
s.AddItem(SKU1, m);
s.AddItem(SKU1, m);
s.AddItem(SKU2, m);
s.AddItem(SKU2, m);
s.AddItem(SKU3, m);
s.AddItem(SKU3, m);

ActionMessage<double> calc = s.GetCartCost(m);
Console.WriteLine(calc.Message);
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
