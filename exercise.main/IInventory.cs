using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IInventory
    {
        public Dictionary<string, Item> getInventory();
        public List<Item> listContents();
    }
    
}
