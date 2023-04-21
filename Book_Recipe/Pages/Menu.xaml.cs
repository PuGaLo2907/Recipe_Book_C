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

namespace Book_Recipe.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void Button_Recipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Recipe());
        }

        private void Button_Ingredient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ingridient());
        }

        private void Button_Category_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.category());
        }

        private void Button_Kitchen_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Kitchen());
        }

        private void Book_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Book());
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.spravka());
        }
    }
}
