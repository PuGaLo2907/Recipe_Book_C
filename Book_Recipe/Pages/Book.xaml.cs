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
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        private int _currentPage = 1;
        private int _countAgents = 2;
        private int _maxPages;
        public Book()
        {
            InitializeComponent();
            Book_panel.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
            UpdateKitchen();
            Refresh();
        }
        private void UpdateKitchen()
        {
            Book_panel.ItemsSource = null;
            Book_panel.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
        }
        List<Book_Recipe.Book> listBook;
        private void Refresh()
        {
            listBook = MainWindow.Book_Recipe.Book.ToList();
            _maxPages = (int)Math.Ceiling(listBook.Count * 1.0 / _countAgents);

            var listAgentPage = listBook.Skip((_currentPage - 1) * _countAgents).Take(_countAgents).ToList();
            TxtCurrentPage.Text = _currentPage.ToString();
            LblTotalPages.Content = "из " + _maxPages;

            Book_panel.ItemsSource = listAgentPage;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            windows.Book_window_table w1 = new windows.Book_window_table();
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
            var x = MainWindow.Book_Recipe.Book.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Book_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Book_panel.ItemsSource = x;

            }
        }
    }
}
