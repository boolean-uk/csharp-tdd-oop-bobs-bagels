namespace tdd_bobs_bagels.Main
{
    public class Basket
{

        public int Capacity { get; private set; }
        public List<string> Items { get; private set; }

        public Basket(int capacity)
        {
            Capacity = capacity;
            Items = new List<string>();
        }

        public void AddItem(string item)
        {
            if (Items.Count < Capacity)
            {
                Items.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Basket is full");
            }
        }

        public void RemoveItem(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else
            {
                throw new ArgumentException("Item not found in basket");
            }
        }

        public bool IsFull()
        {
            return Items.Count >= Capacity;
        }


       

        public void ChangeCapacity(int newCapacity)
        {
            Capacity = newCapacity;
        }
    }
}
