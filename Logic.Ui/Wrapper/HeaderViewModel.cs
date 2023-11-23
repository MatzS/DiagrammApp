using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper
{
    public class HeaderViewModel: ObservableCollection<string>
    {
        private Header model = new Header();

        public Header Model { get { return model; } }

    }
}
