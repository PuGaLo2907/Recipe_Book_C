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
    /// Логика взаимодействия для sostav.xaml
    /// </summary>
    public partial class sostav : Page
    {
        private Book_Recipe.Recipe rp;
        public sostav(Book_Recipe.Recipe selectedRecipe)
        {
            InitializeComponent();
            this.rp = selectedRecipe;
            DataContext = selectedRecipe;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ls2.ItemsSource = MainWindow.Book_Recipe.Composition.ToList().Where(p => p.ID_Recipe == rp.ID_Recipe);
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
