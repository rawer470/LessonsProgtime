using AsyncAwaitApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace AsyncAwaitApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnAsyncClick(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
           await RunAsyncLoad();
            stopwatch.Stop();
            textBlock.Text += $"Total time: {stopwatch.ElapsedMilliseconds} mc \n\n";
        }

        private void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            RunSyncLoad();
            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
            textBlock.Text += $"Total time: {time} mc \n\n";
        }

        private void ReportInfo(DataModel dataModel)
        {
            textBlock.Text += $"Site: {dataModel.Url}, Length: {dataModel.Data.Length}\n";
        }

        private List<string> PrepareData()
        {
            List<string> list = new List<string>()
            {
                "https://www.youtube.com/",
                "https://github.com/",
                "https://ya.ru/"
            };
            return list;

        }
        private void RunSyncLoad()
        {
            List<string> sites = PrepareData();
            foreach (string site in sites)
            {
                DataModel model = DownloadSite(site);
                ReportInfo(model);
            }
        }

        private async Task RunAsyncLoad()
        {
            List<string> sites = PrepareData();
            foreach (string site in sites)
            {
                DataModel model =await Task.Run(() => DownloadSite(site));
                ReportInfo(model);
            }
        }


        private DataModel DownloadSite(string url)
        {
            DataModel dataModel = new DataModel();
            dataModel.Url = url;
            WebClient client = new WebClient();
            dataModel.Data = client.DownloadString(url);

            return dataModel;
        }
    }
}
