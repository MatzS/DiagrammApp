using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects
{
    public class Table
    {
        private ObservableCollection<string> columnHeaders;
        private ObservableCollection<Row> rows;
        public Table(ObservableCollection<string> columnHeaders, ObservableCollection<Row> rows)
        {
            this.columnHeaders = columnHeaders;
            this.rows = rows;
        }

        public ObservableCollection<string> ColumnHeaders
        {
            get { return this.columnHeaders; }
            set { this.columnHeaders = value; }
        }

        public ObservableCollection<Row> Rows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }
    }
}
