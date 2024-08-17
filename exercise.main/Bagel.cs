
namespace csharp_tdd_bobs_bagels.tests
{
    public class Bagel
    {
        private string _currentFlavor;
        private float _price;
        private string _sku;
        private string _id;


        public Bagel(string filling) 
        {
            if (Flavors.Contains(filling.ToLower().Trim()))
            {
                filling = filling.ToLower().Trim();
                this.CurrentFlavor = filling;
                this.Price = _allowedFlavor[filling];
            }

            else
            {
                this.CurrentFlavor = "Plain";
                this._price = _allowedFlavor["Plain"];
            }

        }

        private Dictionary<string, float> _allowedFlavor = new Dictionary<string, float>()  
        {
            {"onion",0.49f},
            {"plain",0.39f},
            {"everything",0.49f},
            {"sesame",0.49f}            
        };

        #region
        public List<string> Flavors { get => _allowedFlavor.Keys.ToList(); }
        public string CurrentFlavor { get => _currentFlavor; set => _currentFlavor = value; }
        public float Price { get => _price; set => _price = value; }
        public string Id { get => _id; set => _id = value; }
        #endregion

    }
}