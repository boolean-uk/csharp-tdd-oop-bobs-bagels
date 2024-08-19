// See https://aka.ms/new-console-template for more information
using exercise.main;

Bagel bagel = new Bagel ("BGLO", 0.49, "Bagel", "Onion", "");
bagel.Filling = "Bacon";
Console.WriteLine(bagel.PrintItem());
if (bagel.Filling != "")
{
    Console.WriteLine(bagel.Filling);
}