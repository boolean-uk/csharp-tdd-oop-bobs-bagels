
namespace csharp_tdd_bobs_bagels.tests
{
    public class Bagel
    {
        private List<string> _allowedFlavor = new List<string> 
        {
            "Onion",
            "Plain",
            "Everything",
            "Sesame"
        };
        private string _currentFlavor;

        public List<string> Flavor { get => _allowedFlavor; set => _allowedFlavor = value; }
        public string CurrentFlavor { get => _currentFlavor; set => _currentFlavor = value; }

        public Bagel(string filling) 
        {
            if (_allowedFlavor.Contains(filling))
                this.CurrentFlavor = filling;
            else
                this.CurrentFlavor = "TheFlavor does not exsist";
        }

        public string GetAssignedFlavor()
        {
            throw new NotImplementedException();
        }
    }
}