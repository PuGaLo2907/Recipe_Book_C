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
    /// Логика взаимодействия для Book_window_table.xaml
    /// </summary>
    public partial class Book_window_table : Window
    {
        public Book_window_table()
        {
            InitializeComponent();
            Book_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
            UpdateRecipe();
            Refresh();
        }

        private void button_add_table(object sender, RoutedEventArgs e)
        {
            Book newBook = new Book();
            WinBook winBook = new WinBook(newBook);
            winBook.ShowDialog();
            UpdateRecipe();
        }
        private void UpdateRecipe()
        {
            Book_window_tabl_tabl.ItemsSource = null;
            Book_window_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
        }

        private void Refresh()
        {

        }
        private void button_Delete_table(object sender, RoutedEventArgs e)
        {
            var Button_Delet = Book_window_tabl_tabl.SelectedItem as Book;
            if (Button_Delet != null)
            {
                MainWindow.Book_Recipe.Book.Remove(Button_Delet);
                MainWindow.Book_Recipe.SaveChanges();
                UpdateRecipe();

            }
            else MessageBox.Show("Выберите запись для удаления!");
        }

        private void textSearchClick(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Redact(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button; //Какая кнопка нажата
            var selectedBook = editButton.DataContext as Book; // какоя категория выбрана
            WinBook winNew = new WinBook(selectedBook);
            winNew.ShowDialog();
        }
    }
}
