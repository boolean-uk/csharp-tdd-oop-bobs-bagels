// See https://aka.ms/new-console-template for more information
using csharp_tdd_oop_bobs_bagels.Source;
using System.Collections.Generic;
using System.Reflection.Metadata;

Main main = new Main();

main.SeedData();

Random r = new Random();
int rInt = r.Next(0, 3);
int rInt1 = r.Next(4, main.Products.Count);
int rInt2 = r.Next(4, main.Products.Count);

int rAdd = r.Next(1, 6);
int rAdd1 = r.Next(1, 6);

string bagel = main.Products[rInt].SKU;
string item1 = main.Products[rInt1].SKU;
string item2 = main.Products[rInt2].SKU;

string role = "manager";
main.SelectRole(role);

for (int i = 0; i < 7; i++)
{
    main.AddItem(bagel);
}

for (int i = 0; i < rAdd; i++)
{
    main.AddItem(item1);
}

for (int i = 0; i < rAdd1; i++)
{
    main.AddItem(item2);
}

main.ItemCost(bagel);
main.ItemCost(item1);
main.ItemCost(item2);

main.TotalCostBasket();

/*
    ~~~Bob's Bagels ~~~

    2021 - 03 - 16 21:38:44

----------------------------

Onion Bagel        2   £0.98
Plain Bagel        12  £3.99
Everything Bagel   6   £2.49
Coffee             3   £2.97

----------------------------
Total                 £10.43

        Thank you
      for your order!
*/

// receipt
Console.WriteLine("~~~Bob's Bagels~~~");
Console.WriteLine("");
Console.WriteLine($"{DateTime.Now}");
Console.WriteLine("");
Console.WriteLine("----------------------------");
Console.WriteLine("");
foreach (IItem item in main.Basket)
{
    Console.WriteLine($"{item.Name} {item.Variant}   {item.Amount}   £{item.Cost}");
}
Console.WriteLine("");
Console.WriteLine("----------------------------");
Console.WriteLine($"Total   £{main.total}");
Console.WriteLine("");
Console.WriteLine("Thank you for your order!");

