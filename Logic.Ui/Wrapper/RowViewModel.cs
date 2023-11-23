using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class RowViewModel: ObservableCollection<FieldViewModel>
    {
        private Row model = new Row();
        public Row Model 
        { 
            get 
            {
                return model;
            }
            set
            {
                this.model = value;
            }
        }

        public ObservableCollection<FieldViewModel> Fields
        {
            get { return this; }
        }
        
        public void AddField(FieldViewModel fieldModel)
        {
            this.Add(fieldModel);
        }

    }
}
