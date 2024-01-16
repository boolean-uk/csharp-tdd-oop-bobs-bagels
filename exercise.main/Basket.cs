using exercise.main.Foods;

namespace exercise.main
{
    public class Basket
    {
        private List<IFood> contents;
        public Basket()
        {
            contents = new List<IFood>();
        }
        public List<IFood> GetContents() { return contents; }
        public void Add(IFood food) { contents.Add(food); }
        public void Remove(IFood food) { contents.Remove(food); }
        public void Clear() {  contents.Clear(); }
    }
}
