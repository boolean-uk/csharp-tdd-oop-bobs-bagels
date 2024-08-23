// See https://aka.ms/new-console-template for more information
using csharp_tdd_bobs_bagels.tests;
using exercise.main;
using System.ComponentModel.Design;
using System.Text;
using tdd_bobs_bagels.CSharp.Main;


Basket basket = new();
Bagel onionBagel1 = new("Onion");
Bagel onionBagel2 = new("Onion");
Bagel plainBagel = new("Plain");
Bagel everythingBagel = new("Everything");
Coffee coffee = new("black");

basket.ChangeCapacity(100);


basket.Add(onionBagel1);
onionBagel1.AddFilling("egg");
basket.Add(onionBagel2);

for (int i = 0; i < 12; i++)
{
    basket.Add(plainBagel);
}

for (int i = 0; i < 6;i++)
{
    basket.Add(everythingBagel);
}

for (int i = 0; i < 3; i++)
{
    basket.Add(coffee);
}

Console.WriteLine(basket.PrintBetterReceipt());
/*
foreach (KeyValuePair<string, int> entry in basket.CheckOut())
{
    foreach(KeyValuePair<string, float> dec in SkuHandler.SkuDecoder(entry.Key))
    {
        Console.WriteLine(dec.Key + dec.Value.ToString());
    }
} 
*/

//Console.WriteLine(basket.PrintReceipt());