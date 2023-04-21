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
    /// Логика взаимодействия для WinKitchen.xaml
    /// </summary>
    public partial class WinKitchen : Window
    {
        public WinKitchen()
        {
            InitializeComponent();
        }
        private Kitchen kitchen;
        public WinKitchen(Kitchen selectKitchen)
        {
            InitializeComponent();
            this.kitchen = selectKitchen;
            DataContext = selectKitchen;

            country_box.ItemsSource = MainWindow.Book_Recipe.Country.ToList();
        }
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (String.IsNullOrWhiteSpace(kitchen.Kitchen_name))
            {
                errors += "Пожалуйста, введите название кухни\n";
            }
            if (errors != "")
            {
                MessageBox.Show(errors, "Ошибка записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow.Book_Recipe.Kitchen.Add(kitchen);
            MainWindow.Book_Recipe.SaveChanges();
            MessageBox.Show($"Запись сохранена");
            this.Close();
        }
    }
}
