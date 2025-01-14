using System;

namespace exercise.main
{
    public class Item
    {
        public string Sku { get; }
        public string Name { get; }
        public double Price { get; }
        public string Variant { get; }
        public int Quantity { get; private set; }

        public Item(string sku, string name, double price, string variant)
        {
            Sku = sku;
            Name = name;
            Price = price;
            Variant = variant;
            Quantity = 1;
        }
        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"SKU: {Sku}, Name: {Name}, Price: {Price}, Variant: {Variant}, Quantity: {Quantity}";
        }
    }
}
