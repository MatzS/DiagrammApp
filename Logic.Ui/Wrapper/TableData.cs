using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class TableData
    {
        public TableData(ObservableCollection<string> columnHeaders, ObservableCollection<TableDataRow> rows)
        {
            for (int i = 0; i < rows.Count; i++)
                if (rows[i].Cells.Count != columnHeaders.Count)
                    throw new ArgumentException(nameof(rows));

            ColumnHeaders = columnHeaders;
            Rows = rows;
        }

        public TableData()
        {
            this.ColumnHeaders.Add("Spalte 1");
            this.ColumnHeaders.Add("Spalte 2");
            this.ColumnHeaders.Add("Spalte 3");
            ObservableCollection<string> stringList1 = new ObservableCollection<string>();
            stringList1.Add("Element 1");
            stringList1.Add("Element 2");
            stringList1.Add("Element 3");
            this.Rows.Add(new TableDataRow(stringList1));
            ObservableCollection<string> stringList2 = new ObservableCollection<string>();
            stringList2.Add("Element 4");
            stringList2.Add("Element 5");
            stringList2.Add("Element 6");
            this.Rows.Add(new TableDataRow(stringList2));
            ObservableCollection<string> stringList3 = new ObservableCollection<string>();
            stringList3.Add("Element 7");
            stringList3.Add("Element 8");
            stringList3.Add("Element 9");
            this.Rows.Add(new TableDataRow(stringList3));
        }

        public ObservableCollection<string> ColumnHeaders { get; } = new ObservableCollection<string>();
        public ObservableCollection<TableDataRow> Rows { get; } = new ObservableCollection<TableDataRow>();

        public void AddColumn(string title)
        {
            this.ColumnHeaders.Add(title);
            foreach(var row in this.Rows)
            {
                row.Add("");
            }
        }

        public void RemoveColumn()
        {
            this.ColumnHeaders.RemoveAt(this.ColumnHeaders.Count -1);
            foreach (var row in this.Rows)
            {
                row.RemoveCell();
            }
        }

        public void AddRow()
        {
            ObservableCollection<string> stringList = new ObservableCollection<string>();
            foreach(var header in ColumnHeaders)
            {
                stringList.Add("");
            }
            var row = new TableDataRow(stringList);
            Rows.Add(row);
        }

        public void RemoveRow()
        {
            Rows.RemoveAt(Rows.Count -1);
        }
    }
}
