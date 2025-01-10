namespace exercise.main
{
    public abstract class Item
    {
        
        public abstract Dictionary<string, double> prices { get; }
        public abstract string name { get; }
        public abstract double totalcost { get; }
        

        
    }
}