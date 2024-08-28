using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class BoolRow
    {
        public Dictionary<string, bool> _data;

        public BoolRow(Dictionary<string, bool> data)
        {
            _data = data;
        }

        public bool GetAtColumn(string key)
        {
            return _data[key];
        }
    }
}
