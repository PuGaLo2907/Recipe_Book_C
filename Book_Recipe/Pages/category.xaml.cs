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
    /// Логика взаимодействия для category.xaml
    /// </summary>
    public partial class category : Page
    {
        public static Book_RecipeEntities5 Book_Recipe;

        private int _currentPage = 1;
        private int _countAgents = 2;
        private int _maxPages;
        public category()
        {
            InitializeComponent();
            Category_panel.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
            UpdateCategory();
            Refresh();
        }
        private void UpdateCategory()
        {
            Category_panel.ItemsSource = null;
            Category_panel.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
        }
        List<Book_Recipe.Category> listCategory;
        private void Refresh()
        {
            listCategory = MainWindow.Book_Recipe.Category.ToList();
            _maxPages = (int)Math.Ceiling(listCategory.Count * 1.0 / _countAgents);

            var listAgentPage = listCategory.Skip((_currentPage - 1) * _countAgents).Take(_countAgents).ToList();
            TxtCurrentPage.Text = _currentPage.ToString();
            LblTotalPages.Content = "из " + _maxPages;

            Category_panel.ItemsSource = listAgentPage;
        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            windows.Category_window_tabl w1 = new windows.Category_window_tabl();
            w1.Show();
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

        private void textSearchClick(object sender, TextChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Category.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Category_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Category_panel.ItemsSource = x;

            }
        }
    }
}
