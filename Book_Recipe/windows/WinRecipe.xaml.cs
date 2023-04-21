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
using Microsoft.Win32;

namespace Book_Recipe.windows
{
    /// <summary>
    /// Логика взаимодействия для WinRecipe.xaml
    /// </summary>
    public partial class WinRecipe : Window
    {
        public WinRecipe()
        {
            InitializeComponent();
        }
        private Recipe recipe;
        public WinRecipe(Recipe selectedRecipe)
        {
            InitializeComponent();
            this.recipe = selectedRecipe;
            DataContext = selectedRecipe;

            kitchen_box.ItemsSource = MainWindow.Book_Recipe.Kitchen.ToList();
            category_box.ItemsSource = MainWindow.Book_Recipe.Category.ToList();
            book_box.ItemsSource = MainWindow.Book_Recipe.Book.ToList();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (String.IsNullOrWhiteSpace(recipe.Dish_name))
            {
                errors += "Пожалуйста, введите название Блюда\n";
            }
            if (String.IsNullOrWhiteSpace(recipe.Cooking_method))
            {
                errors += "Пожалуйста, введите способ приготовления\n";
            }
            if (recipe.Calorie <= 0)
            {
                errors += "Пожалуйста, введите кол-во калорий\n";
            }
            if (recipe.Portion <= 0)
            {
                errors += "Пожалуйста, введите кол-во порций\n";
            }
            if (errors != "")
            {
                MessageBox.Show(errors, "Ошибка записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow.Book_Recipe.Recipe.Add(recipe);
            MainWindow.Book_Recipe.SaveChanges();
            MessageBox.Show($"Запись сохранена");
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (recipe.ID_Recipe == 0)
            {
                kitchen_box.SelectedIndex = 0;
                category_box.SelectedIndex = 0;
            }
        }

        private void btn_image_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();

            myDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            myDialog.Filter = "Картинки(*.JPG;*.GIF;*.PNG) | *.JPG;*.GIF;*.PNG" + "|Все файлы (*.*)|*.*";

            if (myDialog.ShowDialog() == true)
            {
                textblock_1.Text = @"\image\" + myDialog.SafeFileName;
                recipe.Image = textblock_1.Text;
                String path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
        }
    }
}
