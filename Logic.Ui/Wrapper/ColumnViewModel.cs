using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class ColumnViewModel
    {
        private Column model;
        public String Title
        {
            get { return model.Title; }
            set { model.Title = value; }
        }

        public ObservableCollection<string> Values
        {
            get { return model.Values; }
        }

        public ColumnViewModel(String title)
        {
            this.model = new Column(title);
            this.model.AddValue("Value1");
            this.model.AddValue("Value2");
            this.model.AddValue("Value3");
            this.model.AddValue("Value4");
        }

        public ColumnViewModel()
        {
            this.model = new Column();
        }

        public void AddValue(String value)
        {
            model.Values.Add(value);
        }

        public void RemoveValue(String value)
        {
            model.Values.Remove(value);
        }
    }
}
