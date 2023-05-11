namespace csharp_tdd_oop_bobs_bagels_Csharp_Classes
{
    public class ShopItems
    {
        private string _name;
        private string _price;
        private string _variant;
        private string _SDK;

        public string Name { get =>  _name; set { _name = value;} }
        public string Price { get => _price; set { _price = value;} }
        public string Variant { get => _variant; set { _variant = value;} }
        public string SDK { get => _SDK; set { _SDK = value; } }


    }
}