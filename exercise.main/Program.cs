// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;
using exercise.main;

Console.WriteLine("Hello, World!");

Bagel bagel = new Bagel();

bagel.AddBagel("BGLO");
bagel.AddBagel("BGLP");
bagel.AddBagel("BGLP");

Console.WriteLine(bagel.TotalCost());