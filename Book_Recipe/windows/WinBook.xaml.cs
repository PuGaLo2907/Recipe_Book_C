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
    /// Логика взаимодействия для WinBook.xaml
    /// </summary>
    public partial class WinBook : Window
    {
        public WinBook()
        {
            InitializeComponent();
        }
        private Book book;
        public WinBook(Book selectedBook)
        {
            InitializeComponent();
            this.book = selectedBook;
            DataContext = selectedBook;
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (String.IsNullOrWhiteSpace(book.Book_name))
            {
                errors += "Пожалуйста, введите название книги\n";
            }
            if (String.IsNullOrWhiteSpace(book.Author))
            {
                errors += "Пожалуйста, введите автора\n";
            }
            if (errors != "")
            {
                MessageBox.Show(errors, "Ошибка записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow.Book_Recipe.Book.Add(book);
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
                book.Image = textblock_1.Text;
                String path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
        }
    }
}
