using RestApi_Sun.Models;
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

namespace RestApi_Sun
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private async Task<SunResultModel> LoadSunInfo()
        {
           return await SunProccessor.LoadSunInfo(float.Parse(X.Text), float.Parse(Y.Text));
        }

       
        private async void Location(object sender, RoutedEventArgs e)
        {
            SunResultModel model = await LoadSunInfo();
            status.Content = "Status: " + model.Status;
            lblSunrise.Content = "Info SunRise: Info SunRise: " + model.Results.Sunrise.ToLocalTime();
            lblSunset.Content = "Info SunSet: " + model.Results.Sunset.ToLocalTime();
            lblDaylength.Content = "Info Day Length: " + model.Results.Day_length.ToShortTimeString();
        }
    }
}
