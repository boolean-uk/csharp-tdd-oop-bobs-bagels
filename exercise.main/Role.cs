using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Role
    {
        private static Dictionary<string, int> _accessLevels = new() { { "manager", 1 }, { "customer", 5 } };
        public static int GetAccessLevel(string level)
        {
            return _accessLevels.GetValueOrDefault(level, int.MaxValue);
        }

        private int _accessLevel;
        public int AccessLevel { get { return _accessLevel; } }
        public Role(int accessLevel) { _accessLevel = accessLevel; }
    }
}
