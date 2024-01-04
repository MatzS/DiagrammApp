using De.HsFlensburg.DiagrammApp.Logic.Ui.ViewModels;
using De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic.FileIO;
using De.HsFlensburg.DiagrammApp.Logic.Ui;

namespace De.HsFlensburg.DiagrammApp.Ui.Desktop
{ 
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            this.vm = (MainWindowViewModel)DataContext;
            this.vm.ReloadRequired += ReloadMethod;
            this.vm.Reload();
        }

        private void ReloadMethod(object sender, EventArgs a)
        {
            dataGrid.Columns.Clear();
            for (int i = 0; i < vm.Table.ColumnHeaders.Count; i++)
            {
                var columnIndex = i;
                DataGridColumn column = new DataGridTextColumn
                {
                    Binding = new Binding($"Cells[{i}]"),
                    Header = vm.Table.ColumnHeaders[i]
                };
                dataGrid.Columns.Add(column);
            }
            dataGrid.ItemsSource = vm.Table.Rows;
        }

        private void ImportCSVClick(object sender, RoutedEventArgs e)
        {
            List<string[]> csvData = new List<string[]>();
            List<string> headers = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if(openFileDialog.ShowDialog() == true)
            {
                string filepath = openFileDialog.FileName;
                using (TextFieldParser textFieldParser = new TextFieldParser(filepath))
                {
                    textFieldParser.Delimiters = new string[] { "," };
                    while (!textFieldParser.EndOfData)
                    {
                        headers = textFieldParser.ReadFields().ToList<string>();
                        while(!textFieldParser.EndOfData)
                        {
                            var row = textFieldParser.ReadFields();
                            csvData.Add(row);
                        }
                    }
                    vm.ImportCSV(headers, csvData);
                }
            }
        }

        private void ShowChartWindow(object sender, RoutedEventArgs e)
        {
            var viewModelLocator = (ViewModelLocator)Application.Current.Resources["ViewModelLocator"];
            viewModelLocator.TheChartViewModel.Table = vm.Table;
            viewModelLocator.TheChartViewModel.SelectedChart = vm.SelectedDiagram;
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
        }
    }
}
