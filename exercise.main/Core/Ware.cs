using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Core
{
    public abstract class Ware : Product
    {
        public virtual Product Attachment { get; protected set; } = null;

        public Ware(string sku, double price, string variant) : base(sku, price, variant)
        {

        }

        public override double GetPrice()
        {
            if (Attachment == null)
                return _price;

            return _price + Attachment.GetPrice();
        }
    }
}
