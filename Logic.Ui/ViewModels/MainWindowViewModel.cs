using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.ViewModels
{
    public  class MainWindowViewModel: INotifyPropertyChanged
    {
        //private TableViewModel table;
        //private TestViewModel table;
        private TableData table;
        public ICommand DebugCommand { get; }

        public ICommand AddColumnCommand { get; }

        public ICommand RemoveColumnCommand { get; }

        public ICommand AddRowCommand { get; }

        public ICommand RemoveRowCommand { get; }


        public MainWindowViewModel()
        {
            //this.table = new TableViewModel();
            //this.table = new TestViewModel();
            this.table = new TableData();
            DebugCommand = new RelayCommand(DebugModel);
            AddColumnCommand = new RelayCommand(AddColumn);
            RemoveColumnCommand = new RelayCommand(RemoveColumn);
            AddRowCommand = new RelayCommand(AddRow);
            RemoveRowCommand = new RelayCommand(RemoveRow);
        }

        public TableData Table
        {
            get { return this.table; }
        }

        //public TableViewModel Table
        //{
        //    get { return this.table; }
        //}

        //public TableViewModel Table
        //{
        //    get { return this.table; }
        //}

        //public MainWindowViewModel(TableViewModel table)
        //{
        //    this.table = table;
        //    DebugCommand = new RelayCommand(DebugModel);
        //    AddHeaderCommand = new RelayCommand(AddHeader);
        //}

        //public MainWindowViewModel(TestViewModel table)
        //{
        //    this.table = table;
        //    DebugCommand = new RelayCommand(DebugModel);
        //    AddHeaderCommand = new RelayCommand(AddHeader);
        //}
        private void DebugModel()
        {
            Console.WriteLine("DEBUG");
            Reload();
        }

        private void AddColumn()
        {
            this.table.AddColumn("Test");
            Reload();
        }

        private void RemoveColumn()
        {
            this.table.RemoveColumn();
            Reload();
        }

        private void AddRow()
        {
            this.table.AddRow();
            Reload();
        }

        private void RemoveRow()
        {
            this.table.RemoveRow();
            Reload();
        }

        public void Reload()
        {
            this.ReloadRequired.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ReloadRequired;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
