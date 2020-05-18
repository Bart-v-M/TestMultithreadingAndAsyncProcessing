using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TestMultithreadingAndAsyncProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ExcelFile excelFile;
        Stopwatch stopwatch;
        public List<string> listOfCellContent = null;

        public MainWindow()
        {
            InitializeComponent();
            //excelFile = new ExcelFile(@"C:\Users\bartv\OneDrive\Bureaublad\Test4", 1);
            stopwatch = new Stopwatch();

            CreateListButton.Visibility = Visibility.Collapsed;
            Button1.Content = "Run algorithm non-parallel";
            Button2.Content = "Run algorithm parallel";
            Button3.Visibility = Visibility.Collapsed;

            Label1.Content = string.Empty;
            Label2.Content = string.Empty;
            Label3.Content = string.Empty;
            Label4.Content = string.Empty;
        }

        private async void CreateListButton_Click(object sender, RoutedEventArgs e)
        {
            //listOfCellContent = new List<string>();
            //Label1.Content = "List loading...";
            //await Task.Run(() => excelFile.CreateListFromColumn(excelFile, listOfCellContent, 2, 100, 6));
            //Label1.Content = "List completed";
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            Algorithm algorithm = new Algorithm();
            Label2.Content = $"Calculation running...";

            var items = Enumerable.Range(0, 100000);
            await Task.Run(() => {
                foreach (var item in items)
                {
                    algorithm.computeAverages(item);
                }
            });

            stopwatch.Stop();
            Label2.Content = $"Time needed: {stopwatch.Elapsed.TotalSeconds} seconds";
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            Algorithm algorithm = new Algorithm();
            Label3.Content = $"Calculation running...";

            var items = Enumerable.Range(0, 100000);
            await Task.Run(() =>
                      Parallel.ForEach(items, item =>
                      {
                          algorithm.computeAverages(item);
                      })
                      );

            stopwatch.Stop();
            Label3.Content = $"Time needed: {stopwatch.Elapsed.TotalSeconds} seconds";

            //if (listOfCellContent != null)
            //{
            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    Query query = new Query();
            //    Label3.Content = $"Query running...";

            //    await Task.Run(() => query.UseForceParallelism(listOfCellContent));

            //    stopwatch.Stop();
            //    Label3.Content = $"Query time: {stopwatch.Elapsed.TotalSeconds} seconds";
            //}
            //else
            //{
            //    Label3.Content = "Create list from Excel file first";
            //}
        }

        private async void Button3_Click(object sender, RoutedEventArgs e)
        {
            

            //if (listOfCellContent != null)
            //{
            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    Query query = new Query();
            //    Label4.Content = $"Query running...";

            //    await Task.Run(() => query.UseAsSequential(listOfCellContent));

            //    stopwatch.Stop();
            //    Label4.Content = $"Query time: {stopwatch.Elapsed.TotalSeconds} seconds";
            //}
            //else
            //{
            //    Label4.Content = "Create list from Excel file first";
            //}
        }      
    }
}
