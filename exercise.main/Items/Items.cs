using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public abstract class Items
    {
        // Define fields:
        private string _SKU;
        private double _price;
        private string _name = "Bagel"; // "Bagel" by default
        private string _variant;

        /*   public Items(string variant)
           {
               if (variant == "Onion")
               {
                   set(0.49, "BGLO");
                   this._variant = variant;
               }
               else if (variant == "Plain")
               {
                   set(0.39, "BGLP");
                   this._variant = variant;
               }
               else if (variant == "Eveything")
               {
                   set(0.49, "BGLE");
                   this._variant = variant;
               }
               else if (variant == "Sesame")
               {
                   set(0.49, "BGLS");
                   this._variant = variant;
               }
               else
               {
                   set(0, "Invalid");
               };
           }*/

        public abstract void Set(double price, string SKU);
    }
}
