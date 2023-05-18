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

// turns out you pay more buying the 6 or 12 deal for the plain bagel than without the deal.
// coffee deal has not been implemented yet.
main.PrintReceipt();


