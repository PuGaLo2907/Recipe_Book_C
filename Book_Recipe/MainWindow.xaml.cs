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

namespace Book_Recipe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Book_RecipeEntities5 Book_Recipe;
        public MainWindow()
        {
            InitializeComponent();
            Book_Recipe = new Book_RecipeEntities5();
            frame.Navigate(new Pages.Glav());
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack) frame.GoBack();
        }

        private void frameRender(object sender, EventArgs e)
        {
            if (frame.CanGoBack) btn_Back.Visibility = Visibility.Visible;
            else btn_Back.Visibility = Visibility.Hidden;
            
        }
        
    }
}
