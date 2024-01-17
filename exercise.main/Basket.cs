namespace exercise.main
{
    public class Basket
    {
        public BasketManager.Order Order;

        public Basket()
        {
            Order = new BasketManager.Order();
        }

        public int Capacity
        {
            get { return Order.Capacity; }
            set { Order.ChangeCapacity(value); }
        }

        public void ChangeCapacity(int capacity)
        {
            Order.ChangeCapacity(capacity);
        }

        public int Add(string sku)
        {
            // Implementation to add an item to the order
            throw new NotImplementedException();
        }

        public void AddFilling(int id, string sku)
        {
            // Implementation to add filling to a bagel in the order
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            // Implementation to remove an item from the order
            throw new NotImplementedException();
        }

        public double Cost()
        {
            return Order.Cost();
        }

        public double ProductCost(string sku)
        {
            // Implementation to get the cost of a product by sku
            throw new NotImplementedException();
        }
    }
}
