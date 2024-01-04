using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    [Serializable]
    public class TableViewModel
    {
        public TableViewModel(ObservableCollection<string> columnHeaders, ObservableCollection<RowViewModel> rows)
        {
            ObservableCollection<Row> rowModels = new ObservableCollection<Row>();
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Cells.Count != columnHeaders.Count)
                {
                    throw new ArgumentException(nameof(rows));
                }
                else
                {
                    Row row = new Row(rows[i].Cells);
                    rowModels.Add(row);
                    rows[i].Model = row;
                }
            }
            ColumnHeaders = columnHeaders;
            Rows = rows;
            this.model = new Table(columnHeaders, rowModels);
        }

        private Table model;

        public TableViewModel()
        {

        }

        public ObservableCollection<string> ColumnHeaders { get; } = new ObservableCollection<string>();
        public ObservableCollection<RowViewModel> Rows { get; } = new ObservableCollection<RowViewModel>();

        public void AddColumn(string title)
        {
            this.ColumnHeaders.Add(title);
            foreach (var row in this.Rows)
            {
                row.Add("");
            }
        }

        public void RemoveColumn()
        {
            this.ColumnHeaders.RemoveAt(this.ColumnHeaders.Count - 1);
            foreach (var row in this.Rows)
            {
                row.RemoveCell();
            }
        }

        public void AddRow()
        {
            ObservableCollection<string> stringList = new ObservableCollection<string>();
            foreach (var header in ColumnHeaders)
            {
                stringList.Add("");
            }
            var row = new RowViewModel(stringList, new Row(stringList));
            Rows.Add(row);
        }

        public void RemoveRow()
        {
            Rows.RemoveAt(Rows.Count - 1);
        }

        public void ClearTable()
        {
            this.Rows.Clear();
            this.ColumnHeaders.Clear();
        }
    }
}

