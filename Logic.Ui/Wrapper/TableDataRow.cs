using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class TableDataRow
    {
        public TableDataRow(ObservableCollection<string> cells)
        {
            Cells = cells;
        }

        public ObservableCollection<string> Cells { get; }

        public void Add(string text)
        {
            this.Cells.Add(text);
        }

        public void RemoveCell()
        {
            this.Cells.RemoveAt(this.Cells.Count - 1);
        }
    }
}
