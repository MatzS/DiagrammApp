using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.ViewModels
{
    public  class MainWindowViewModel
    {
        private TableViewModel table;
        public ICommand DebugCommand { get; }

        public MainWindowViewModel()
        {
            this.table = new TableViewModel();
        }

        public TableViewModel Table
        {
            get { return this.table; }
        }

        public MainWindowViewModel(TableViewModel table)
        {
            this.table = table;
            DebugCommand = new RelayCommand(DebugModel);
        }

        private void DebugModel()
        {
            Console.WriteLine("DEBUG");
        }

    }
}
