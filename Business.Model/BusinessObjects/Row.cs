using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects
{
    public class Row
    {
        private ObservableCollection<string> cells;

        public Row(ObservableCollection<string> cells)
        {
            Cells = cells;
        }

        public ObservableCollection<string> Cells 
        { get 
            { 
                return cells;
            } 
          set
            {
                cells = value;
            }
        }

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
