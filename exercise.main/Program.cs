using exercise.main;
using exercise.main.Foods;
using exercise.main.Variants;

Customer customer = new();
customer.Order(new Bagel(BagelVariant.Sesame));
Receipt receipt = new(customer.Basket);
receipt.Print();