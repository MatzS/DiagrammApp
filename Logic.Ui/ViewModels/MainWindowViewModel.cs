using De.HsFlensburg.DiagrammApp.Business.Model.BusinessObjects;
using De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper;
using System.Collections.ObjectModel;
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
        private TableViewModel table;

        private string selectedDiagram;
        public ICommand DebugCommand { get; }

        public ICommand AddColumnCommand { get; }

        public ICommand RemoveColumnCommand { get; }

        public ICommand AddRowCommand { get; }

        public ICommand RemoveRowCommand { get; }

        public ICommand ShowChartCommand { get; }


        private string filepath = string.Empty;

        public MainWindowViewModel()
        {
            this.table = new TableViewModel();
            DebugCommand = new RelayCommand(DebugModel);
            AddColumnCommand = new RelayCommand(AddColumn);
            RemoveColumnCommand = new RelayCommand(RemoveColumn);
            AddRowCommand = new RelayCommand(AddRow);
            RemoveRowCommand = new RelayCommand(RemoveRow);
            ShowChartCommand = new RelayCommand(ShowChart);
        }

        public TableViewModel Table
        {
            get { return this.table; }
        }

        public string SelectedDiagram
        {
            get 
            {
                return this.selectedDiagram;
            }
            set
            {
                this.selectedDiagram = value;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filepath;
            }
            set
            {
                this.filepath = value;
            }
        }

        private void DebugModel()
        {
            Console.WriteLine("DEBUG");
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

        public void ImportCSV(List<string> headers, List<string[]> data)
        {
            this.table.ClearTable();
            foreach(var header in headers)
            {
                this.table.ColumnHeaders.Add(header);
            }
            foreach(var row in data)
            {
                this.table.Rows.Add(new RowViewModel(new ObservableCollection<string>(row), new Row(new ObservableCollection<string>(row))));
            }
            this.ReloadRequired.Invoke(this, EventArgs.Empty);
        }

        public void ShowChart()
        {
            
        }

        public void Reload()
        {
            this.ReloadRequired.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ReloadRequired;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
