using exercise.main.Foods;

namespace exercise.main
{
    public class Basket
    {
        private List<IFood> _contents = new();
        private int _capacity = 90;
        public Basket() {}
        public Basket(int capacity)
        {
            _capacity = capacity;
        }

        public int Capacity { get { return _capacity; } set { _capacity = value; } }
        public int Count { get { return _contents.Count; } }
        public List<IFood> GetContents() { return _contents; }
        public void Add(IFood food) 
        {
            if(_contents.Count >= _capacity)
            {
                throw new Exception("Your basket is overflowing!");
            }
            _contents.Add(food); 
        }
        public void Remove(IFood food) 
        {
            bool exists = _contents.Remove(food);
            if (!exists)
            {
                throw new Exception("That food item does not exist!");
            }
        }
        public void Clear() { _contents.Clear(); }

        public float GetTotalDiscount()
        {
            return PriceCalculator.CalculateDiscounts(_contents);
        }

        public float GetTotalPrice()
        {
            return _contents.Sum(x => x.Price) - GetTotalDiscount();
        }
    }
}
