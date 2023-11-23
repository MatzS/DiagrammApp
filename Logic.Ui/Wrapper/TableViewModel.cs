using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class TableViewModel: ObservableCollection<RowViewModel>
    {
        private Table model = new Table();
        private HeaderViewModel headerModel = new HeaderViewModel();
        public TableViewModel() 
        {
            //this.AddHeaderTitle("Zeit");
            //this.AddHeaderTitle("Test1");
            //this.AddHeaderTitle("Test2");
            this.AddRow("Spalte1");
            this.AddRow("Spalte2");
            this.AddRow("Spalte3");
        }
        
        public HeaderViewModel Header
        {
            get { return this.headerModel; }
        }

        public ObservableCollection<RowViewModel> Rows
        {
            get { return this; }
        }

        public int RowCount
        {
            get { return this.Rows.Count;}
        }

        public void AddRow(string title)
        {
            RowViewModel rowViewModel = new RowViewModel();
            for (int i = 0; i < headerModel.Model.Count; i++)
            {
                rowViewModel.Add(new FieldViewModel(title+"Value"+i));
            }
            this.Add(rowViewModel);
            this.model.AddRow();
        }

        public void AddField(FieldViewModel fieldViewModel = null, int index = 0)
        {
            if(fieldViewModel == null)
            {
                fieldViewModel = new FieldViewModel("Test");
                this.model.AddField(null, index);
            }
            else
            {
                this.model.AddField(fieldViewModel.Model, index);
            }
            this[index].Add(fieldViewModel);
        }

        public void AddHeaderTitle(string title)
        {
            this.headerModel.Add(title);
            this.headerModel.Model.Add(title);
        }

        public void RemoveHeaderTitle(string title)
        {
            this.headerModel.Remove(title);
            this.headerModel.Model.Remove(title);
        }
    }
}
