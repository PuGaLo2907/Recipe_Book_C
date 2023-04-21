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
using System.Windows.Shapes;

namespace Book_Recipe.windows
{
    /// <summary>
    /// Логика взаимодействия для Recipe_window_tabl.xaml
    /// </summary>
    public partial class Recipe_window_tabl : Window
    {
        public static Book_RecipeEntities5 book_Recipe;
        public Recipe_window_tabl()
        {
            InitializeComponent();
            Recipe_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
            cb2.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
            UpdateRecipe();
            Refresh();
        }

        private void Button_Redact(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button; //Какая кнопка нажата
            var selectedRecipe = editButton.DataContext as Recipe; // какой рецепт выбран
            WinRecipe winNew = new WinRecipe(selectedRecipe);
            winNew.ShowDialog();
        }

        private void button_add_table(object sender, RoutedEventArgs e)
        {
            Recipe newRecipe = new Recipe();
            WinRecipe winRecipe = new WinRecipe(newRecipe);
            winRecipe.ShowDialog();
            UpdateRecipe();
        }
        private void UpdateRecipe()
        {
            Recipe_window_tabl_tabl.ItemsSource = null;
            Recipe_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
        }


        private void Refresh()
        {
            
        }

        private void button_Delete_table(object sender, RoutedEventArgs e)
        {
            var Button_Delet = Recipe_window_tabl_tabl.SelectedItem as Recipe;
            if (Button_Delet != null)
            {
                MainWindow.Book_Recipe.Recipe.Remove(Button_Delet);
                MainWindow.Book_Recipe.SaveChanges();
                UpdateRecipe();

            }
            else MessageBox.Show("Выберите запись для удаления!");
        }

        private void textSearchClick(object sender, TextChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Dish_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Recipe_window_tabl_tabl .ItemsSource = x;

            }
        }

        private void comboBax_2_cb(object sender, SelectionChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Recipe.ToList();
            int searchInt = cb2.SelectedIndex;
            if (searchInt == cb2.SelectedIndex)
            {
                x = x.Where(line => (line.ID_Category == cb2.SelectedIndex + 1)).ToList();
                Recipe_window_tabl_tabl.ItemsSource = x;
            }
            else
            {
                Recipe_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Recipe.ToList();
            }
        }

        private void comboBax_3_cb(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
