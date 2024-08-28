using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class DecimalRow
    {
        public Dictionary<string, decimal> _data;

        public DecimalRow(Dictionary<string, decimal> data)
        {
            _data = data;
        }

        public decimal GetAtColumn(string key)
        {
            return _data[key];
        }
    }
}
