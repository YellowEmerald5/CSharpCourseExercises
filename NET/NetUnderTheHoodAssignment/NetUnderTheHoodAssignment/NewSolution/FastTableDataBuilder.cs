using CsvDataAccess.CsvReading;using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;
using NetUnderTheHoodAssignment.NewSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<NewRow>();

        foreach (var row in csvData.Rows)
        {
            var newRowData = new Dictionary<string, object>();
            var notNull = false;
            var newRow = new NewRow();
            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                if(row[columnIndex] != null && row[columnIndex] != "")
                {
                    var column = csvData.Columns[columnIndex];
                    string valueAsString = row[columnIndex];
                    if (valueAsString == "TRUE")
                    {
                        newRow.AssignBoolCell(column, true);
                    }
                    else if (valueAsString == "FALSE")
                    {
                        newRow.AssignBoolCell(column, false);
                    }
                    else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                    {
                        newRow.AssignDecimalCell(column, valueAsDecimal);
                    }
                    else if (int.TryParse(valueAsString, out var valueAsInt))
                    {
                        newRow.AssignIntCell(column, valueAsInt);
                    }
                    else
                    {
                        newRow.AssignStringCell(column, valueAsString);
                    }
                    notNull = true;
                }
                else
                {
                    notNull = false;
                }
            }

            if(notNull)
            resultRows.Add(newRow);
        }

        return new NewTableData(csvData.Columns, resultRows);
    }
}
