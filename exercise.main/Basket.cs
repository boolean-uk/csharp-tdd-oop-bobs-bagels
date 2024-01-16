using exercise.main.Foods;

namespace exercise.main
{
    public class Basket
    {
        private List<IFood> _contents;
        public Basket()
        {
            _contents = new List<IFood>();
        }
        public List<IFood> GetContents() { return _contents; }
        public void Add(IFood food) { _contents.Add(food); }
        public void Remove(IFood food) { _contents.Remove(food); }
        public void Clear() {  _contents.Clear(); }

        public float GetTotalPrice()
        {
            return _contents.Sum(x => x.Price);
        }
    }
}
