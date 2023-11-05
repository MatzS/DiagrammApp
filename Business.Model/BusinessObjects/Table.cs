using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects
{
    public class Table
    {
        private ArrayList columns;
        public ArrayList  Columns
        {
            get { return columns; }
        }

        public Table()
        {
            columns = new ArrayList();
        }

        public void AddColumn(String title = "New Column")
        {
            this.columns.Add(new Column(title));
        }
    }
}
