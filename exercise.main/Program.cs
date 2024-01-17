using exercise.main;
using exercise.main.Foods;
using exercise.main.Variants;

Customer customer = new();
customer.Order(new Bagel(BagelVariant.Sesame));
for (int i = 0; i < 10; i++)
{
    customer.Order(new Bagel(BagelVariant.Onion));
}
for (int i = 0; i < 12; i++)
{
    customer.Order(new Bagel(BagelVariant.Plain));
}
Receipt receipt = new(customer.Basket);
receipt.Print();