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
    /// Логика взаимодействия для Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Page
    {
        public static Book_RecipeEntities5 Book_Recipe;

        private int _currentPage = 1;
        private int _countAgents = 6;
        private int _maxPages;
        public Kitchen()
        {
            InitializeComponent();
            Kitchen_panel.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
            UpdateKitchen();
            Refresh();
        }
        private void UpdateKitchen()
        {
            Kitchen_panel.ItemsSource = null;
            Kitchen_panel.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
        }
        List<Book_Recipe.Kitchen> listKitchen;
        private void Refresh()
        {
            listKitchen = MainWindow.Book_Recipe.Kitchen.ToList();
            _maxPages = (int)Math.Ceiling(listKitchen.Count * 1.0 / _countAgents);

            var listAgentPage = listKitchen.Skip((_currentPage - 1) * _countAgents).Take(_countAgents).ToList();
            TxtCurrentPage.Text = _currentPage.ToString();
            LblTotalPages.Content = "из " + _maxPages;

            Kitchen_panel.ItemsSource = listAgentPage;
        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            windows.Kitchen_window w1 = new windows.Kitchen_window();
            w1.Show();
        }

        private void textSearchClick(object sender, TextChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Kitchen.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Kitchen_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Kitchen_panel.ItemsSource = x;

            }
        }
        private void GoToFirstPage(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            Refresh();
        }
        private void GoToPreviousPage(object sender, RoutedEventArgs e)
        {
            if (_currentPage <= 1) _currentPage = 1;
            else _currentPage--;
            Refresh();
        }

        private void GoToNextPage(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= _maxPages)
                _currentPage = _maxPages;
            else _currentPage++;
            Refresh();
        }

        private void GoToLastPage(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPages;
            Refresh();
        }
    }
}
