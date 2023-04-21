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
    /// Логика взаимодействия для Kitchen_window.xaml
    /// </summary>
    public partial class Kitchen_window : Window
    {
        public static Book_RecipeEntities5 book_Recipe;
        public Kitchen_window()
        {
            InitializeComponent();
            Kitchen_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
        }

        private void button_add_table(object sender, RoutedEventArgs e)
        {
            Kitchen newKitchen = new Kitchen();
            WinKitchen winKitchen = new WinKitchen(newKitchen);
            winKitchen.ShowDialog();
            UpdateKitchen();
        }

        private void button_Delete_table(object sender, RoutedEventArgs e)
        {
            var Button_Delet = Kitchen_tabl_tabl.SelectedItem as Kitchen;
            if (Button_Delet != null)
            {
                MainWindow.Book_Recipe.Kitchen.Remove(Button_Delet);
                MainWindow.Book_Recipe.SaveChanges();
                UpdateKitchen();

            }
            else MessageBox.Show("Выберите запись для удаления!");
        }
        private void UpdateKitchen()
        {
            Kitchen_tabl_tabl.ItemsSource = null;
            Kitchen_tabl_tabl.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
        }
        private void Button_Redact(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button; //Какая кнопка нажата
            var selectKitchen = editButton.DataContext as Kitchen; // какой рецепт выбран
            WinKitchen winNew = new WinKitchen(selectKitchen);
            winNew.ShowDialog();
        }

        private void textSearchClick(object sender, TextChangedEventArgs e)
        {

        }
    }
}
