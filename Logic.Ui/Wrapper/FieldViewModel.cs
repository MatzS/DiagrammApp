using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class FieldViewModel
    {
        private Field model;

        public FieldViewModel(string value)
        {
            this.model = new Field(value);
        }

        public Field Model
        {
            get { return this.model; }
        }
    }
}
