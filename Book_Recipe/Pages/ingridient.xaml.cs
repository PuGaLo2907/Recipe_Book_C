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
    /// Логика взаимодействия для ingridient.xaml
    /// </summary>
    public partial class ingridient : Page
    {
        public static Book_RecipeEntities5 Book_Recipe;

        private int _currentPage = 1;
        private int _countAgents = 10;
        private int _maxPages;
        public ingridient()
        {
            InitializeComponent();
            Ingridient_panel.ItemsSource = MainWindow.Book_Recipe.Ingredient.ToList();
            UpdateIngridient();
            Refresh();

        }
        private void UpdateIngridient()
        {
            Ingridient_panel.ItemsSource = null;
            Ingridient_panel.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
        }
        List<Book_Recipe.Ingredient> listIngridient;
        private void Refresh()
        {
            listIngridient = MainWindow.Book_Recipe.Ingredient.ToList();
            _maxPages = (int)Math.Ceiling(listIngridient.Count * 1.0 / _countAgents);

            var listAgentPage = listIngridient.Skip((_currentPage - 1) * _countAgents).Take(_countAgents).ToList();
            TxtCurrentPage.Text = _currentPage.ToString();
            LblTotalPages.Content = "из " + _maxPages;

            Ingridient_panel.ItemsSource = listAgentPage;
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
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Dish_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Ingridient_panel.ItemsSource = x;

            }
        }
    }
}
