using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class HeaderViewModel
    {
        private Header model = new Header();

        public void AddTitle(string title)
        {
            this.model.Add(title);
        }

        public void RemoveTitle(string title)
        {
            this.model.Remove(title);
        }
    }
}
