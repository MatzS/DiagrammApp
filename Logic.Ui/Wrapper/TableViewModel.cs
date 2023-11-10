using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
           
        }
        

        public void AddRow(RowViewModel rowModel)
        {
            this.Add(rowModel);
            this.model.Add(rowModel.Model);
        }
    }
}
