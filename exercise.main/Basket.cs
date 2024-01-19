using static exercise.main.Inventory;
using static exercise.main.BasketManager;
using static exercise.main.ReceiptManager;

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
            InventoryItem? item = inventory.GetItem(sku);

            if (item == null)
                return 0;

            Product product = new Product(item);

            CustomerOrder.Add(product);

            return product.ID;
        }

        public void AddFilling(int id, string sku)
        {
            Bagel? bagel = CustomerOrder.Products.FirstOrDefault(x => x.ID == id) as Bagel;
            if (bagel == null) 
                throw new Exception("No bagel with the specified ID.");

            Inventory inventory = new Inventory();
            InventoryItem? item = inventory.GetItem(sku);

            if (item == null)
                throw new Exception("No item with the specified SKU.");

            if (item.Type == "Filling")
                bagel.AddFilling(item);
            else
                throw new Exception("Specified SKU is not a Bagel Filling.");
        }

        public void Remove(int id)
        {
            Product? product = CustomerOrder.Products.FirstOrDefault(x => x.ID == id);
            if(product != null)
                CustomerOrder.Products.Remove(product);
            else 
                throw new Exception("No product with specified ID.");
        }

        public double Cost()
        {
            return CustomerOrder.Cost();
        }

        public double MenyItemCost(string sku)
        {
            Inventory inventory = new Inventory();
            InventoryItem? item = inventory.GetItem(sku);

            if (item == null)
                throw new Exception("No item with the specified SKU.");

            return item.Price;
        }

        public Receipt Receipt()
        {
            ReceiptManager receiptManager = new ReceiptManager();
            return receiptManager.CreateReceipt(CustomerOrder);
        }
    }
}
