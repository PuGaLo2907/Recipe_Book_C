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
    /// Логика взаимодействия для Glav.xaml
    /// </summary>
    public partial class Glav : Page
    {
        public Glav()
        {
            InitializeComponent();
        }
        private void Button_voyti_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Registr());
        }

        private void button_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
