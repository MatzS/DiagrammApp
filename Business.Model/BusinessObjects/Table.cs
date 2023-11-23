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

        public void AddRow()
        {
            Row row = new Row();
            for(int i = 0; i> header.Count; i++)
            {
                row.Add(new Field("Test"));
            }
            this.Add(row);
        }

        public void AddField(Field field = null, int index = 0)
        {
            if(field == null)
            {
                field = new Field("test");
            }
            this[index].Add(field);
        }

        public void AddHeaderTitle(string title)
        {
            this.header.Add(title);
        }

        public void RemoveHeaderTitle(string title)
        {
            this.header.Remove(title);
        }
    }
}
