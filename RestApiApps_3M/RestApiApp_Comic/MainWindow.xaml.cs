using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace RestApiApp_Comic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentNumber = 0;
        private int maxNumber = 0;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private async void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber>1)
            {
                currentNumber--;
                await LoadImage(currentNumber);
                
            }
            if (currentNumber==1)
            {
                btnPrev.IsEnabled = true;

            }
        }

        private async void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber <maxNumber)
            {
                currentNumber++;
                await LoadImage(currentNumber);
                if (currentNumber == maxNumber)
                {
                 //   btnNext.IsEnabled = false;
                }
                
                   
                
            }
           
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComicModel comicModel = await ComicProcessor.LoadComic();
            currentNumber = comicModel.Num;
            maxNumber = currentNumber;
            Uri uri = new Uri(comicModel.Img);
            ImageComic.Source = new BitmapImage(uri);
            Title_Comic.Content = comicModel.Title;
            Date_Comic.Content = $"{comicModel.Day}.{comicModel.Month}.{comicModel.Year}";
            
        }

        private async Task LoadImage(int num = 0)
        {
            ComicModel comicModel = await ComicProcessor.LoadComic(num);

            if (num <= 0)
            {
                currentNumber = comicModel.Num;
                maxNumber = currentNumber;
            }
            Uri uri = new Uri(comicModel.Img);
            ImageComic.Source = new BitmapImage(uri);
            Title_Comic.Content = comicModel.Title;
            Date_Comic.Content = $"{comicModel.Day}.{comicModel.Month}.{comicModel.Year}";
        }

        private async void ButtonR_Click(object sender, RoutedEventArgs e)
        {
           await LoadImage(random.Next(0, maxNumber + 1));
          
        }

        private async void Find_Comic(object sender, RoutedEventArgs e)
        {
           await LoadImage(int.Parse(TextBox.Text));
            
        }
    }
}
