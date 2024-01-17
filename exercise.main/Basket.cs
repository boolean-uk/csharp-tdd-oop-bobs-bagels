using exercise.main.Foods;

namespace exercise.main
{
    public class Basket
    {
        private List<IFood> _contents = new();
        private int _capacity = 25;
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
        public void Remove(IFood food) 
        {
            bool exists = _contents.Remove(food);
            if (!exists)
            {
                throw new Exception("That food item does not exist!");
            }
        }
        public int Count { get { return _contents.Count; } }
        public void Clear() {  _contents.Clear(); }
        public float CalculateDiscounts(List<IFood> foods)
        {
            float total = 0f;
            int bgloCount = foods.Count(x => x.Sku.Equals("BGLO"));
            int bglpCount = foods.Count(x => x.Sku.Equals("BGLP"));
            int bgleCount = foods.Count(x => x.Sku.Equals("BGLE"));
            total += MathF.Floor(bgloCount / 6) * 0.45f;
            total += MathF.Floor(bglpCount / 12) * 0.69f;
            total += MathF.Floor(bgleCount / 6) * 0.45f;
            return total;
        }
        private float CalculateDiscounts()
        {
            return CalculateDiscounts(_contents);
        }
        public float GetTotalPrice()
        {
            return _contents.Sum(x => x.Price) - CalculateDiscounts();
        }

        public float GetTotalPrice(List<IFood> foods)
        {
            return foods.Sum(x => x.Price) - CalculateDiscounts(foods);
        }
    }
}
