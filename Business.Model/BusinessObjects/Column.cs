using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects
{
    public class Column
    {
        private String title;

        public Column(String title)
        {
            this.title = title;
        }
        public Column()
        {
            this.title = "New Column";
            this.values = new ObservableCollection<string>();
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private ObservableCollection<string> values;
        public ObservableCollection<string> Values
        {
            get { return values; }
            set { values = value; }
        }

        public void AddValue(String value)
        {
            values.Add(value);
        }

        public void RemoveValue(String value)
        {
            values.Remove(value);
        }
    }
}
