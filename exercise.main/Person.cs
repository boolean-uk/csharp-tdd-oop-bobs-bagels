using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Person
    {
        private int _id;
        private bool _manager;
        private List<Basket> _basket = new List<Basket>();

        public bool Manager {

            get { return _manager; } set { _manager = value; }

            }


        public Person(int id, bool manager) {
            this._id = id;
            this._manager = manager;
        }
    }
}
