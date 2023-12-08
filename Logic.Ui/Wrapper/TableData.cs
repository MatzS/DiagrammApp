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
            this.ColumnHeaders.Add("Zeit");
            this.ColumnHeaders.Add("Spalte 1");
            this.ColumnHeaders.Add("Spalte 2");
            this.ColumnHeaders.Add("Spalte 3");
            ObservableCollection<string> stringList1 = new ObservableCollection<string>();
            for(var i = 1; i<11; i++)
            {
                stringList1.Add(i.ToString());
            }
            ObservableCollection<string> stringList2 = new ObservableCollection<string>();
            for (var i = 10; i >= 1; i--)
            {
                stringList2.Add(i.ToString());
            }
            ObservableCollection<string> stringList3 = new ObservableCollection<string>();
            Random random = new Random();
            for (var i = 1; i < 11; i++)
            {
                string rndNumber = random.Next(1,11).ToString();
                stringList3.Add(rndNumber);
            }
            ObservableCollection<string> stringList4 = new ObservableCollection<string>();
            for (var i = 1; i < 11; i++)
            {
                string rndNumber = random.Next(3, 7).ToString();
                stringList4.Add(rndNumber);
            }
            for (var i = 0; i < 10; i++)
            {
                ObservableCollection<string> row = new ObservableCollection<string>();
                row.Add(stringList1[i]);
                row.Add(stringList2[i]);
                row.Add(stringList3[i]);
                row.Add(stringList4[i]);
                this.Rows.Add(new TableDataRow(row));
            }
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

        public void ClearTable()
        {
            this.Rows.Clear();
            this.ColumnHeaders.Clear();
        }
    }
}
