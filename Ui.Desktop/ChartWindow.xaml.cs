using De.HsFlensburg.DiagrammApp.Logic.Ui;
using De.HsFlensburg.DiagrammApp.Logic.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace De.HsFlensburg.DiagrammApp.Ui.Desktop
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        private ChartViewModel vm;

        private double CanvasWidth = 800;
        private double CanvasHeight = 500;
        private List<List<double>> cols;
        private double xMin;
        private double xMax;
        private double xDiff;
        private double xStep;
        private double yMin;
        private double yMax;
        private double yDiff;
        private double yStep;
        private double xZeroCord;
        private double yZeroCord;
        private int skalaCount = 4;
        private double xSkalaThreshold;
        private double ySkalaThreshold;
        private double xSkalaDiff;
        private double ySkalaDiff;
        private SolidColorBrush[] lineColors = { Brushes.Red, Brushes.Green, Brushes.Blue };
        public ChartWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.vm = (ChartViewModel)DataContext;
            PrepareData();
            DrawGridLines();
            DrawLines();
        }

        private void PrepareData()
        {
            var data = vm.Table;
            Dispatcher.Invoke(() => CanvasHeight = canvas.ActualHeight);
            Dispatcher.Invoke(() => CanvasWidth = canvas.ActualWidth);
            if (data.Rows.Count < 2 || data.ColumnHeaders.Count < 2)
                return;

            var cols = new double[data.ColumnHeaders.Count, data.Rows.Count];

            for (var i = 0; i < data.ColumnHeaders.Count; i++)
            {
                for (var j = 0; j < data.Rows.Count; j++)
                {
                    double parsedValue;
                    if (double.TryParse(data.Rows[j].Cells[i], out parsedValue))
                    {
                        cols[i, j] = parsedValue;
                    }
                    else
                    {
                        cols[i, j] = 0.0;
                    }
                }
            }
            this.cols = ConvertArrayToList(cols);
        }

        public List<List<double>> ConvertArrayToList(double[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            this.yMin = this.yMax = array[0, 0];
            this.xMin = this.xMax = array[1, 0];
            var result = new List<List<double>>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                var row = new List<double>();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(i == 0)
                    {
                        this.xMin = Math.Min(this.xMin, array[i, j]);
                        this.xMax = Math.Max(this.xMax, array[i, j]);
                    } else
                    {
                        this.yMin = Math.Min(this.yMin, array[i, j]);
                        this.yMax = Math.Max(this.yMax, array[i, j]);
                    }
                    row.Add(array[i, j]);
                }
                result.Add(row);
            }
            return result;
        }

        private void DrawGridLines()
        {
            //Berechnung des X- und Y-Nullpunkts
            this.xDiff =  Math.Abs(xMin - xMax);
            this.xStep = (CanvasWidth - 2*(CanvasWidth/10)) / xDiff;
            this.xSkalaThreshold = (CanvasWidth - 2 * (CanvasWidth / 10)) / (double)this.skalaCount;
            this.xSkalaDiff = 0.0;
            this.yDiff = Math.Abs(yMin - yMax);
            this.yStep = (CanvasHeight - 2 * (CanvasHeight / 10)) / yDiff;
            this.ySkalaThreshold = (CanvasHeight - 2 * (CanvasHeight / 10)) / (double)this.skalaCount;
            this.xSkalaDiff = 0.0;
            if(xMin < 0)
            {
                this.xZeroCord = Math.Abs(xMin) * xStep;
            } 
            else
            {
                this.xZeroCord = CanvasWidth / 10;
            }

            if(yMin < 0)
            {
                this.yZeroCord = CanvasHeight - (Math.Abs(yMin) * yStep);
            } 
            else
            {
                this.yZeroCord = CanvasHeight - (CanvasHeight / 10);
            }
            // Einzeichnen des Koordinatenkreuzes
            Line xZeroLine = new Line
            {
                X1 = xZeroCord,
                X2 = xZeroCord,
                Y1 = 0,
                Y2 = CanvasHeight,
                Stroke = Brushes.Black
            };
            canvas.Children.Add(xZeroLine);

            Line yZeroLine = new Line
            {
                X1 = 0,
                X2 = CanvasWidth,
                Y1 = this.yZeroCord,
                Y2 = this.yZeroCord,
                Stroke = Brushes.Black
            };
            canvas.Children.Add(yZeroLine);

            // Beschriftung Nullpunkt
            TextBlock zeroLabel = new TextBlock
            {
                Text = "0",
                Foreground = Brushes.Black,
                Margin = new Thickness(xZeroCord - 5, this.yZeroCord + 5, 0, 0)
            };
            canvas.Children.Add(zeroLabel);

            // Skala der X-Achse
            for (double x = xStep; x <= CanvasWidth - (CanvasWidth/10); x += xStep)
            {
                if(this.xSkalaDiff < this.xSkalaThreshold)
                {
                    this.xSkalaDiff += xStep;
                }else
                {
                    Line tickMarkX = new Line
                    {
                        X1 = x + xZeroCord,
                        X2 = x + xZeroCord,
                        Y1 = yZeroCord - 5,
                        Y2 = yZeroCord + 5,
                        Stroke = Brushes.Black
                    };
                    canvas.Children.Add(tickMarkX);

                    TextBlock xLabel = new TextBlock
                    {
                        Text = (x / xStep).ToString(),
                        Foreground = Brushes.Black,
                        Margin = new Thickness((x + xZeroCord) - 5, yZeroCord + 5, 0, 0)
                    };
                    canvas.Children.Add(xLabel);
                    this.xSkalaDiff -= this.xSkalaThreshold;
                }
            }

            // Skala der Y-Achse
            for (double y = yZeroCord - yStep; y >= 0; y -= yStep)
            {
                if (this.ySkalaDiff < this.ySkalaThreshold)
                {
                    this.ySkalaDiff += yStep;
                }
                else
                {
                    Line tickMarkY = new Line
                    {
                        X1 = xZeroCord - 5,
                        X2 = xZeroCord + 5,
                        Y1 = y,
                        Y2 = y,
                        Stroke = Brushes.Black
                    };
                    canvas.Children.Add(tickMarkY);

                    TextBlock yLabel = new TextBlock
                    {
                        Text = ((yZeroCord - y) / yStep).ToString("F0"),
                        Foreground = Brushes.Black,
                        Margin = new Thickness(xZeroCord - 30, y, 0, 0)
                    };
                    canvas.Children.Add(yLabel);
                    this.ySkalaDiff -= this.ySkalaThreshold;
                }
            }
        }

        private void DrawLines()
        {
            for(int j = 1; j < this.cols.Count; j++)
            {
                SolidColorBrush lineColor = lineColors[j % lineColors.Length];
                for (int i = 0; i < this.cols[j].Count - 1; i++)
                {
                    double xStart = this.xZeroCord + ((this.cols[0][i] -1 ) * this.xStep);
                    double xEnd = this.xZeroCord + ((this.cols[0][i+1] - 1) * this.xStep);
                    double yStart = this.yZeroCord - (this.cols[j][i] * this.yStep);
                    double yEnd = this.yZeroCord - (this.cols[j][i + 1] * this.yStep);
                    Line line = new Line
                    {
                        X1 = xStart,
                        X2 = xEnd,
                        Y1 = yStart,
                        Y2 = yEnd,
                        Stroke = lineColor,
                        StrokeThickness = 2
                    };
                    canvas.Children.Add(line);

                    Polygon polygon = new Polygon
                    {
                        Fill = new SolidColorBrush(Color.FromArgb(50, lineColor.Color.R, lineColor.Color.G, lineColor.Color.B)),
                        Points = new PointCollection
                        {
                            new Point(xStart, this.yZeroCord),
                            new Point(xEnd, this.yZeroCord),
                            new Point(xEnd, yEnd),
                            new Point(xStart, yStart)
                        }
                    };
                    canvas.Children.Add(polygon);
                }
            }
        }
    }
}
