using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class NewRow
    {
        private Dictionary<string, int> _intData = new();
        private Dictionary<string, string> _stringData = new();
        private Dictionary<string, decimal> _decimalData = new();
        private Dictionary<string, bool> _boolData = new();

        public void AssignStringCell(string key,string value)
        {
            _stringData[key] = value;
        }

        public void AssignIntCell(string key, int value)
        {
            _intData[key] = value;
        }

        public void AssignDecimalCell(string key, decimal value)
        {
            _decimalData[key] = value;
        }

        public void AssignBoolCell(string key, bool value)
        {
            _boolData[key] = value;
        }

        public object GetAtColumn(string columnName)
        {
            if (_intData.ContainsKey(columnName) ) return _intData[columnName];
            if (_stringData.ContainsKey(columnName) ) return _stringData[columnName];
            if (_decimalData.ContainsKey(columnName) ) return _decimalData[columnName];
            if (_boolData.ContainsKey(columnName) ) return _boolData[columnName];
            return null;
        }
    }
}
