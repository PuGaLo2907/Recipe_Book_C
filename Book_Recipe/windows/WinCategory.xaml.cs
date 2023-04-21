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
    /// Логика взаимодействия для WinCategory.xaml
    /// </summary>
    public partial class WinCategory : Window
    {
        public WinCategory()
        {
            InitializeComponent();
        }
        private Category category;
        public WinCategory(Category selectedCategory)
        {
            InitializeComponent();
            this.category = selectedCategory;
            DataContext = selectedCategory;
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (String.IsNullOrWhiteSpace(category.Category_name))
            {
                errors += "Пожалуйста, введите название категории\n";
            }
            if (errors != "")
            {
                MessageBox.Show(errors, "Ошибка записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow.Book_Recipe.Category.Add(category);
            MainWindow.Book_Recipe.SaveChanges();
            MessageBox.Show($"Запись сохранена");
            this.Close();
        }

        private void btn_image_click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog myDialog = new OpenFileDialog();

            myDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            myDialog.Filter = "Картинки(*.JPG;*.GIF;*.PNG) | *.JPG;*.GIF;*.PNG" + "|Все файлы (*.*)|*.*";

            if (myDialog.ShowDialog() == true)
            {
                textblock_1.Text = @"\image\" + myDialog.SafeFileName;
                category.Image = textblock_1.Text;
                String path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
        }
    }
}
