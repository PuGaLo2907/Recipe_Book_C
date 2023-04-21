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
    /// Логика взаимодействия для Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        public static Book_RecipeEntities5 Book_Recipe;

        private int _currentPage = 1;
        private int _countAgents = 2;
        private int _maxPages;
        public Recipe()
        {
            InitializeComponent();
            Recipe_panel.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
            cb1.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
            cb2.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
            cb3.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
            Updaterecipe();
            Refresh();

        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            windows.Recipe_window_tabl w1 = new windows.Recipe_window_tabl();
            w1.Show();
        }
        private void Updaterecipe()
        {
            Recipe_panel.ItemsSource = null;
            Recipe_panel.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
        }
        List <Book_Recipe.Recipe> listRecipe;
        private void Refresh()
        {
            listRecipe = MainWindow.Book_Recipe.Recipe.ToList();
            _maxPages = (int)Math.Ceiling(listRecipe.Count * 1.0 / _countAgents);

            var listAgentPage = listRecipe.Skip((_currentPage - 1) * _countAgents).Take(_countAgents).ToList();
            TxtCurrentPage.Text = _currentPage.ToString();
            LblTotalPages.Content = "из " + _maxPages;
            Recipe_panel.ItemsSource = listAgentPage;
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

        private void comboBax_1_cb(object sender, SelectionChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            int searchInt = cb1.SelectedIndex;
            if (searchInt == cb1.SelectedIndex)
            {
                x = x.Where(line => (line.ID_Category == cb1.SelectedIndex + 1)).ToList();
                Recipe_panel.ItemsSource = x;
            }
            else
            {
                Recipe_panel.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
            }
        }
        private void textSearchClick(object sender, TextChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Dish_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Recipe_panel.ItemsSource = x;

            }
        }

        private void comboBax_2_cb(object sender, SelectionChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            int searchInt = cb2.SelectedIndex;
            if (searchInt == cb2.SelectedIndex)
            {
                x = x.Where(line => (line.ID_Kitchen == cb2.SelectedIndex + 1)).ToList();
                Recipe_panel.ItemsSource = x;
            }
            else
            {
                Recipe_panel.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
            }
        }

        private void comboBax_3_cb(object sender, SelectionChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            int searchInt = cb3.SelectedIndex;
            if (searchInt == cb3.SelectedIndex)
            {
                x = x.Where(line => (line.ID_Book == cb3.SelectedIndex + 7)).ToList();
                Recipe_panel.ItemsSource = x;
            }
            else
            {
                Recipe_panel.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
            }
        }

        private void sostav_click(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button; //Какая кнопка нажата
            var selectedRecipe = editButton.DataContext as Book_Recipe.Recipe; // какой рецепт выбран
            //sostav winNew = new WinRecipe(selectedRecipe);
            //winNew.ShowDialog();
            NavigationService.Navigate(new Pages.sostav(selectedRecipe));
        }
    }
}
