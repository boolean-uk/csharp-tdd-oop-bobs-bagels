using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    //public enum BagelType
    //{
    //    Onion,
    //    Plain,
    //    Everything,
    //    Sesame
    //}

    public class Bagel
    {
        public Bagel(string bagelType = "Plain", string bagelFilling = "")
        {
            BagelType = bagelType;
            BagelFilling = bagelFilling;
        }
        public string BagelType { get; set; }

        public string BagelFilling { get; set; }
    }
}
