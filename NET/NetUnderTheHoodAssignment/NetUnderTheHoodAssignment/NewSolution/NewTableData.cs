using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class NewTableData : ITableData
    {
        private readonly List<NewRow> _rows;
        public int RowCount => _rows.Count;
        public IEnumerable<string> Columns { get; }

        public NewTableData(IEnumerable<string> columns, List<NewRow> rows)
        {
            _rows = rows;
            Columns = columns;
        }

        public object GetValue(string columnName, int rowIndex)
        {
            return _rows[rowIndex].GetAtColumn(columnName);
        }
    }
}
