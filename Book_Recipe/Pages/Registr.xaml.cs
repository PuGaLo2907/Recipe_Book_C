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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(tbox_Login.Text) || String.IsNullOrEmpty(pasw_1.Password))
            {
                MessageBox.Show("ВВедите Логин");
                return;
            }
            var user = MainWindow.Book_Recipe.User.AsNoTracking().FirstOrDefault(predicate => predicate.User_Login == tbox_Login.Text && predicate.User_Password == pasw_1.Password);

            if (user == null)
            {
                MessageBox.Show("Пользователь с такими данными не найден");
                tbox_Login.Clear();
                pasw_1.Clear();
                return;
            }
            else
            {
                MessageBox.Show($"Вход прошел успешно");
                NavigationService.Navigate(new Pages.Menu());
            }
        }
    }
}
