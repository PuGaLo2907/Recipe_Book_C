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
    /// Логика взаимодействия для Category_window_tabl.xaml
    /// </summary>
    public partial class Category_window_tabl : Window
    {
        public static Book_RecipeEntities5 book_Recipe;
        public Category_window_tabl()
        {
            InitializeComponent();
            Category_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
        }

        private void Button_Redact(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button; //Какая кнопка нажата
            var selectedCategory = editButton.DataContext as Category; // какоя категория выбрана
            WinCategory winNew = new WinCategory(selectedCategory);
            winNew.ShowDialog();
        }

        private void button_add_table(object sender, RoutedEventArgs e)
        {
            Category newCategory = new Category();
            WinCategory winCategory = new WinCategory(newCategory);
            winCategory.ShowDialog();
            UpdateRecipe();
        }

        private void button_Delete_table(object sender, RoutedEventArgs e)
        {
            var Button_Delet = Category_window_tabl_tabl.SelectedItem as Category;
            if (Button_Delet != null)
            {
                MainWindow.Book_Recipe.Category.Remove(Button_Delet);
                MainWindow.Book_Recipe.SaveChanges();
                UpdateRecipe();

            }
            else MessageBox.Show("Выберите запись для удаления!");
        }

        private void textSearchClick(object sender, TextChangedEventArgs e)
        {
            var x = MainWindow.Book_Recipe.Category.ToList();
            string searchText = textSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                x = x.Where(p => p.Category_name.ToLower().StartsWith(searchText.ToLower())).ToList();
                Category_window_tabl_tabl.ItemsSource = x;

            }
        }
        private void UpdateRecipe()
        {
            Category_window_tabl_tabl.ItemsSource = null;
            Category_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
        }
    }
}
