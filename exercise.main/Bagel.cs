﻿using exercise.main;

namespace csharp_tdd_bobs_bagels.tests
{
    public class Bagel : Merchandise
    {
        private float _price;
        private string _currentFlavor;
        private Dictionary<string, float> _allowedFlavor = new Dictionary<string, float>()  
        {
            {"onion",0.49f},
            {"plain",0.39f},
            {"everything",0.49f},
            {"sesame",0.49f}            
        };
        private string _sku; 
        private List<Filling> _fillings = new();
        bool _falseOrder = false;
        


        public Bagel(string breadType) 
        {
            if (Flavors.Contains(breadType.ToLower().Trim()))
            {
                breadType = breadType.ToLower().Trim();
                this._currentFlavor = breadType;
                this._price = _allowedFlavor[breadType];
                this._sku = "BGL" + breadType.ToUpper().Substring(0, 1);
                
            }

            else
            {
                this._falseOrder = true;
            }

        }


        public float GetPrice()
        {
            return Price;
        }

        public void AddFilling(string v)
        {
            Filling filling = new Filling(v);
            _fillings.Add(filling);
            _price += filling.Price;
        }

        public void Discount()
        {
            throw new NotImplementedException();
        }

        #region
        public List<string> Flavors { get => _allowedFlavor.Keys.ToList(); }
        public string CurrentFlavor { get => _currentFlavor; set => _currentFlavor = value; }
        public string SKU { get => _sku;  }
        public float Price { get => _price; }
        public bool FalseOrder { get => _falseOrder; }



        #endregion

    }
}