using RickAndMortyAPI.Models;
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

namespace RickAndMortyAPI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int id = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FindPerson(object sender, RoutedEventArgs e)
        {
            id = int.Parse(Txtboxid.Text);
            CharacterModel character = await CartoonProcessor.LoadCharacter(id);
            await LoadImage(id);
            lblname.Content = "Name: "+ character.Name;
            lblspeies.Content ="Species: "+ character.Species;
            lbllocation.Content ="Location: "+ character.Location.Name;
        }


        private async Task LoadImage(int num = 0)
        {
            CharacterModel character = await CartoonProcessor.LoadCharacter(id);
            Uri uri = new Uri(character.Image);
            ImageCharacter.Source = new BitmapImage(uri);
        }
    }
}
