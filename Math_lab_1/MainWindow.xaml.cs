using System;
using System.Collections.Generic;
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

namespace Math_lab_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string[] input = new string[6];
            input[0] = X.Text;
            input[1] = X1.Text;
            input[2] = X2.Text;
            input[3] = X3.Text;
            input[4] = LOWER.Text;
            input[5] = UPPER.Text;
            Solve.Text ="Ответ метод горнера:" + Convert.ToString(GornerTable.Solve(input));
            BisectionMethodSolver solver = new BisectionMethodSolver(input);
            Solve.Text = "\n" + "Решение в процессе";
            double result = solver.Solve();
            Solve.Text += "\n"+ " " + result;

            // Assume you already have a canvas named graphCanvas in your XAML file

            List<Tuple<double, double>> points = solver.GetXYPoints();

// Calculate the minimum and maximum x and y values to determine scaling
            double minX = double.MaxValue, minY = double.MaxValue, maxX = double.MinValue, maxY = double.MinValue;
            foreach (Tuple<double, double> point in points) {
                if (point.Item1 < minX) {
                    minX = point.Item1;
                }
                if (point.Item1 > maxX) {
                    maxX = point.Item1;
                }
                if (point.Item2 < minY) {
                    minY = point.Item2;
                }
                if (point.Item2 > maxY) {
                    maxY = point.Item2;
                }
            }

// Scale the points to fit in the canvas
            double canvasWidth = graphCanvas.ActualWidth;
            double canvasHeight = graphCanvas.ActualHeight;
            double scaleX = canvasWidth / (maxX - minX);
            double scaleY = canvasHeight / (maxY - minY);

// Draw the points as circles in the canvas
            foreach (Tuple<double, double> point in points) {
                double x = (point.Item1 - minX) * scaleX;
                double y = canvasHeight - (point.Item2 - minY) * scaleY;
                Ellipse circle = new Ellipse() {
                    Width = 5,
                    Height = 5,
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };
                Canvas.SetLeft(circle, x - 2.5);
                Canvas.SetTop(circle, y - 2.5);
                graphCanvas.Children.Add(circle);
            }

        }
    }
}