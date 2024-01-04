using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class RowViewModel
    {
        private Row model;
        public RowViewModel(ObservableCollection<string> cells, Row model)
        {
            this.model = model;
            this.model.Cells = cells;
        }

        public ObservableCollection<string> Cells
        {
            get { return model.Cells; }
            set { model.Cells = value; }
        }

        public Row Model
        {
            get { return model; }
            set { this.model = value; }
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