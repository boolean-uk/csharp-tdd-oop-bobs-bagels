using System.Net.Mail;
using System.Reflection;
using exercise.main;

Shop s = new Shop();
Guid id = new Guid();
string SKU = "BGLO";


Console.WriteLine(s.GetInventory["BGLO"]);
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
