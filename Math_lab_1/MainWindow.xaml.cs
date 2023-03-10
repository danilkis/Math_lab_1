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
            Solve.Text = "\n" + "Решение в процессе\n";
            List<string> result = solver.Solve();
            foreach (var step in result)
            {
                Solve.Text += step;
            }
        }
    }
}