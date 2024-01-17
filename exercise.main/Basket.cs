using static exercise.main.Inventory;
using static exercise.main.BasketManager;

namespace exercise.main
{
    public class Basket
    {
        public Order CustomerOrder;

        public Basket()
        {
            CustomerOrder = new Order();
        }

        public int Capacity
        {
            get { return CustomerOrder.Capacity; }
            set { CustomerOrder.ChangeCapacity(value); }
        }

        public void ChangeCapacity(int capacity)
        {
            CustomerOrder.ChangeCapacity(capacity);
        }

        public int Add(string sku)
        {
            Inventory inventory = new Inventory();
            IInventoryItem? item = inventory.GetItem(sku);

            if (item == null)
                return 0;

            string first3Letters = item.SKU.Substring(0, 3);

            if (first3Letters == "BGL")
            {
                Bagel bagel = new Bagel((BagelVariant)item);
                CustomerOrder.Add(bagel);
                return bagel.ID;
            }
            else if (first3Letters == "COF")
            {
                Coffee coffee = new Coffee((CoffeeVariant)item);
                CustomerOrder.Add(coffee);
                return coffee.ID;
            }

            return 0;
        }

        public void AddFilling(int id, string sku)
        {
            Bagel? bagel = CustomerOrder.Bagels.FirstOrDefault(x => x.ID == id);
            if (bagel == null)  // This condition might be redundant since you've already checked if the bagel exists
                throw new Exception("No bagel with the specified ID.");

            Inventory inventory = new Inventory();
            IInventoryItem? item = inventory.GetItem(sku);

            if (item == null)
                throw new Exception("No item with the specified SKU.");

            if (item is BagelFilling filling)
                bagel.AddFilling(filling);
            else
                throw new Exception("Specified SKU is not a Bagel Filling.");
        }


        public void Remove(int id)
        {
            Bagel? bagel = CustomerOrder.Bagels.FirstOrDefault(x => x.ID == id);
            if(bagel != null)
                CustomerOrder.Bagels.Remove(bagel);

            Coffee? coffee = CustomerOrder.Coffees.FirstOrDefault(x => x.ID == id);
            if (coffee != null)
                CustomerOrder.Coffees.Remove(coffee);

            if (bagel == null && coffee == null)
                throw new Exception("No product with specified ID.");
        }

        public double Cost()
        {
            return CustomerOrder.Cost();
        }

        public double ProductCost(string sku)
        {
            Inventory inventory = new Inventory();
            IInventoryItem? item = inventory.GetItem(sku);

            if (item == null)
                throw new Exception("No item with the specified SKU.");

            return item.Price;
        }
    }
}
