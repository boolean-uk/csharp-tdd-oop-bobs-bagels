using exercise.main;
using exercise.main.Foods;
using exercise.main.Variants;

Customer customer = new();
customer.Order(new Bagel(BagelVariant.Sesame));
customer.Order(new Bagel(BagelVariant.Onion), 10);
customer.Order(new Bagel(BagelVariant.Plain), 25);
Receipt.Print(customer.Basket);

MessageService messageService = new MessageService();
messageService.SendOrderConfirmation(customer.Basket);