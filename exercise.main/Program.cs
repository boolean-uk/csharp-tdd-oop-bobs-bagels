// See https://aka.ms/new-console-template for more information
using exercise.main.Core;
using exercise.main.Objects.Containers;
using exercise.main.Objects.People;
using exercise.main.Objects.Products;
using System.ComponentModel;



Store bobsBagelsStore = new Store();
Customer customer = new Customer();
List<Ware> wares = new List<Ware>();


Filling filling = (Filling)bobsBagelsStore.GetProduct("FLIB");
Bagel menuBagel = (Bagel)bobsBagelsStore.GetProduct("BGLS");
Bagel bagel = new Bagel(menuBagel.SKU, menuBagel.GetPrice(), menuBagel.Variant, filling);
wares.Add(bagel);

wares.Add((Ware)bobsBagelsStore.GetProduct("BGLS"));
wares.Add((Ware)bobsBagelsStore.GetProduct("BGLE"));
for (int i = 0; i < 30; i++)
    wares.Add((Ware)bobsBagelsStore.GetProduct("BGLO"));
wares.Add((Ware)bobsBagelsStore.GetProduct("COFB"));


customer.AddToBasket(wares);
bobsBagelsStore.BuyWares(customer);