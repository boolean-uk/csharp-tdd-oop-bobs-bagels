

using exercise.main;
using exercise.main.Items;

Shop shop = new Shop(new Role(Role.GetAccessLevel("customer")));

shop.DoShopping();