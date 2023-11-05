using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class TableViewModel
    {
        private Table table;

        public TableViewModel ()
        {
            table = new Table();
            table.AddColumn("TestSpalte");
        }

        public Table Table
        {
            get { return table; }
        }

        public ArrayList Columns
        {
            get { return table.Columns; }
        }

        public void AddColumn (String title = "New Column")
        {
            table.Columns.Add (new ColumnViewModel(title));
        }
    }
}
