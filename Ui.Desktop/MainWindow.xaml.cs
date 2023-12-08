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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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


            //DataTable table = new DataTable();
            //for (int i = 0; i < vm.Table.ColumnHeaders.Count; i++)
            //{
            //    DataColumn col = new DataColumn();
            //    col.ColumnName = vm.Table.ColumnHeaders[i];
            //    table.Columns.Add(col);
            //}
            //for (int i = 0; i < vm.Table.Rows.Count; i++)
            //{
            //    DataRow dataRow = table.NewRow();
            //    var data = vm.Table.Rows[i];
            //    var dataArray = new object[vm.Table.ColumnHeaders.Count];
            //    for (int j = 0; j < data.Cells.Count; j++)
            //    {
            //        dataArray[j] = data.Cells[j].ToString();
            //    }
            //    dataRow.ItemArray = dataArray;
            //    table.Rows.Add(dataRow);
            //}
            //dataGrid.ItemsSource = table.DefaultView;



            //for (int columnIndex = 0; columnIndex < vm.Table.ColumnHeaders.Count; columnIndex++)
            //{
            //    var templateColumn = new DataGridTemplateColumn
            //    {
            //        Header = vm.Table.ColumnHeaders[columnIndex]
            //    };

            //    // Erstellen Sie eine DataTemplate mit einem TextBox und binden Sie es an Ihre Eigenschaft
            //    var dataTemplate = new DataTemplate();
            //    var textBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            //    textBoxFactory.SetBinding(TextBox.TextProperty, new Binding($"Cells[{columnIndex}]") { Mode = BindingMode.TwoWay });

            //    dataTemplate.VisualTree = textBoxFactory;

            //    // Setzen Sie das DataTemplate für die Zelle
            //    templateColumn.CellTemplate = dataTemplate;

            //    // Erstellen Sie eine DataTemplate mit einem TextBox für die Bearbeitungsansicht
            //    var editTemplate = new DataTemplate();
            //    var textBoxFactoryEdit = new FrameworkElementFactory(typeof(TextBox));
            //    textBoxFactoryEdit.SetBinding(TextBox.TextProperty, new Binding($"Cells[{columnIndex}]") { Mode = BindingMode.TwoWay });

            //    editTemplate.VisualTree = textBoxFactoryEdit;

            //    // Setzen Sie das DataTemplate für die bearbeitende Zelle
            //    templateColumn.CellEditingTemplate = editTemplate;

            //    // Fügen Sie die Spalte zum DataGrid hinzu
            //    dataGrid.Columns.Add(templateColumn);
            //}

            //// Setzen Sie die ItemsSource auf Ihre Daten
            //dataGrid.ItemsSource = vm.Table.Rows;




            //dataGrid.Columns.Clear();
            //dataGrid.Items.Clear();
            //for (int i = 0; i < vm.Table.Header.Count; i++ )
            //{
            //    var column = new System.Windows.Controls.DataGridTextColumn
            //    {
            //        Header = vm.Table.Header[i],
            //        Binding = new System.Windows.Data.Binding($"Fields[{i}]")
            //    };
            //    dataGrid.Columns.Add(column);
            //}
            //foreach (var title in vm.Table.Header)
            //{
            //    var column = new System.Windows.Controls.DataGridTextColumn
            //    {
            //        Header = title,
            //    };
            //    dataGrid.Columns.Add(column);
            //}
            //foreach (var row in vm.Table)
            //{
            //    var dataGridRow = new System.Windows.Controls.DataGridRow();
            //    dataGridRow.Item = row;
            //    dataGrid.Items.Add(dataGridRow);

            //    foreach (var field in row)
            //    {
            //        dataGrid.Columns[
            //            var cell = new System.Windows.Controls.DataGridCell();
            //            cell.Content = field.Model.Value;
            //            Console.WriteLine(field.Model.Value);
            //            dataGrid.Items.Add(cell);
            //    }


            //}
            //dataGrid.ItemsSource = vm.Table.Rows;
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
