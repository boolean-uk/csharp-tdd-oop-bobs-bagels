// See https://aka.ms/new-console-template for more information
using exercise.main.Class_Items;

Console.WriteLine("Hello, World!");

 Bakery _bakery = new Bakery();
//  Arrange - set up test values
_bakery.ChangeCapacity(30);
_bakery.AddToBasket("BGLO");
_bakery.AddToBasket("BGLO");
for (int i = 0; i < 12; i++)
{
    _bakery.AddToBasket("BGLS");
}
for (int i = 0; i < 6; i++)
{
    _bakery.AddToBasket("BGLE");
}
_bakery.AddToBasket("COFB");
_bakery.AddToBasket("COFB");
_bakery.AddToBasket("COFB");

double result = _bakery.CheckOut();