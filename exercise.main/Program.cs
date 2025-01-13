using System.Net.Mail;
using System.Reflection;
using exercise.main;

Shop s = new Shop();
Person customer = new Person("Customer");
Person manager = new Person("Manager");

ActionMessage cAdd = s.AddItem("BGLO", customer);
ActionMessage mAdd = s.AddItem("BGLO", manager);

Console.WriteLine(s.GetCart(customer).Count);
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
