using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects
{
    public class Field
    {

        private string value;

        public Field(string value)
        {
            this.value = value;
        }

        public string Value {
            get 
            {
                return value; 
            }
            set
            {
                this.value = value;
            }
        }
    }
}
