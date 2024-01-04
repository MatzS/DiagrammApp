using De.HsFlensburg.DiagrammApp.Logic.Ui.ViewModels;
using De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui
{
    public class ViewModelLocator
    {
        public TableViewModel TheTableViewModel { get; set; }

        public MainWindowViewModel TheMainWindowViewModel { get; set; }

        public ChartViewModel TheChartViewModel { get; set; }
        public ViewModelLocator()
        {
            TheTableViewModel = new TableViewModel();
            TheMainWindowViewModel = new MainWindowViewModel();
            TheChartViewModel = new ChartViewModel();
        }
    }
}
