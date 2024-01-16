
namespace exercise.main
{
    public class Basket
    {
        public List<Item> Items { get; set; }
        private int _capacity;

        public Basket()
        {
            Items = [];
            _capacity = 39; //Arbitrarily chosen default capacity
        }
        public Basket(int capacity)
        {
            Items = [];
            _capacity = capacity;
        }
        public void AddItem(Item item)
        {
            if (IsFull())
            {
                return;
            }
            Items.Add(item);
        }

        public void AddItems(List<Item> item)
        {
            if (IsFull())
            {
                return;
            }
            Items.AddRange(item);
        }

        public List<Item> GetBagels()
        {
            return Items;
        }

        public bool RemoveItem(Item item)
        {
            if (!Items.Contains(item))
            {
                Console.WriteLine("No such item");
                return false;
            }
            else
            {
                Items.Remove(item);
                return true;
            }
        }

        public bool IsFull()
        {
            return Items.Count >= _capacity;
        }

        public void ChangeBasketCapacity(int v)
        {
            _capacity = v;
        }

        public bool DoesItemExist(Item item)
        {
            return (Items.Contains(item));
        }

        public double GetBasketCost()
        {
            return Items.Sum(x => x.GetPrice());
        }

        public double GetDiscountBasketCost()
        {
            double total = 0;
            List<Bagel> bagels = Items.Where(x => x.Sku.StartsWith("BGL")).Select(x => (Bagel)x).ToList();
            List<Coffee> coffee = Items.Where(x => x.Sku.StartsWith("COF")).Select(x => (Coffee)x).ToList();
            while (bagels.Count >= 12)
            {
                total += 3.99;
                total += bagels.Take(12).Sum(x => x.GetFillingPrice());
                bagels.RemoveRange(0, 12);
            }
            while (bagels.Count >= 6)
            {
                total += 2.49;
                total += bagels.Take(6).Sum(x => x.GetFillingPrice());
                bagels.RemoveRange(0, 6);
            }
            while (coffee.Count >= 1 && bagels.Count >= 1)
            {
                total += 1.25;
                total += bagels[0].GetFillingPrice();
                coffee.RemoveRange(0, 1);
                bagels.RemoveRange(0, 1);
            }
            bagels.ForEach(x => { total += x.GetPrice(); });
            coffee.ForEach(x => { total += x.GetPrice(); });
            return total;
        }
    }
}
