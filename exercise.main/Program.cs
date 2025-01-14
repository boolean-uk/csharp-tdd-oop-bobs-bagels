// See https://aka.ms/new-console-template for more information
using exercise.main;


Person person = new Person() { role = "customer" };
Bagel bagel = new Bagel("BGLO");
Bagel bagel1 = new Bagel("BGLO");
Bagel bagel2= new Bagel("BGLO");
Bagel bagel3 = new Bagel("BGLO");
Bagel bagel4 = new Bagel("BGLO");
Bagel bagel5 = new Bagel("BGLO");
Bagel bagel6 = new Bagel("BGLO");
Bagel bagel7 = new Bagel("BGLO");
Bagel bagel8 = new Bagel("BGLO");
Bagel bagel9 = new Bagel("BGLO");
Bagel bagel10 = new Bagel("BGLO");
Bagel bagel11 = new Bagel("BGLO");
Coffee coffee = new Coffee("COFB");
Bagel newBagel = new Bagel("BGLP");
Filling fill = new Filling("FILX");
person.AddItem(newBagel);
bagel.AddFilling(fill);
person.AddItem(coffee);
person.AddItem(bagel);
person.AddItem(bagel1);
person.AddItem(bagel2);
person.AddItem(bagel3);
person.AddItem(bagel4);
person.AddItem(bagel5);
person.AddItem(bagel6);
person.AddItem(bagel7);
person.AddItem(bagel8);
person.AddItem(bagel9);
person.AddItem(bagel10);
person.AddItem(bagel11);
Filling pill = new Filling("FILB");
Filling pill1 = new Filling("FILB");
bagel.AddFilling(pill);

Receipt receipt = new Receipt(person);


receipt.PrintReceipt();
