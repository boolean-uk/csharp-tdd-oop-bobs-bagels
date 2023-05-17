using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;
using tdd_oop_bobs_bagels.CSharp.Main.Products;

namespace Users
{
    public interface Userr
    {
        string name { get; set; }
        List<Items> items { get; set; }
    }
}
