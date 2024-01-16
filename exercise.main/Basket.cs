using exercise.main.Foods;

namespace exercise.main
{
    public class Basket
    {
        private List<IFood> _contents = new();
        private int _capacity = 10;
        public Basket() {}
        public Basket(int capacity)
        {
            _capacity = capacity;
        }

        public int Capacity { get { return _capacity; } set { _capacity = value; } }
        public List<IFood> GetContents() { return _contents; }
        public void Add(IFood food) 
        {
            if(_contents.Count >= _capacity)
            {
                throw new Exception("Your basket is overflowing!");
            }
            _contents.Add(food); 
        }
        public void Remove(IFood food) { _contents.Remove(food); }
        public int Count { get { return _contents.Count; } }
        public void Clear() {  _contents.Clear(); }

        public float GetTotalPrice()
        {
            return _contents.Sum(x => x.Price);
        }
    }
}
