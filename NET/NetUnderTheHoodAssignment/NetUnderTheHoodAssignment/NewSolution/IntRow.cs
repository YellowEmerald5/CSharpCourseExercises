using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class IntRow
    {
        public Dictionary<string, int> _data;

        public IntRow(Dictionary<string, int> data)
        {
            _data = data;
        }

        public int GetAtColumn(string key)
        {
            return _data[key];
        }
    }
}
