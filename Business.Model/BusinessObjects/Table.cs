using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects
{
    public class Table: ObservableCollection<Row>
    {
        private Header header = new Header();
        public Table()
        {

        }

        public Header Header 
        {
            get 
            { 
                return header; 
            }
            set 
            {
                header = value;
            }
        }

        public void AddRow(String title = "New Column")
        {
            this.Add(new Row());
        }

        public void AddHeaderTile(string title)
        {
            this.header.Add(title);
        }

        public void RemoveHeaderTitle(string title)
        {
            this.header.Remove(title);
        }
    }
}
