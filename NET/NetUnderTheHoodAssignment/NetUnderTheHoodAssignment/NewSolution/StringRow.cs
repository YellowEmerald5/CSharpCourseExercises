using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class StringRow
    {
        public Dictionary<string, string> _data;

        public StringRow(Dictionary<string, string> data)
        {
            _data = data;
        }

        public string GetAtColumn(string key)
        {
            return _data[key];
        }
    }
}
