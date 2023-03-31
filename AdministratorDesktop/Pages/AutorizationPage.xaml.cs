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

namespace AdministratorDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserTypeComboBox.ItemsSource = App.Context.UserTypes.ToList();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserTypeComboBox.SelectedItem != null && !string.IsNullOrWhiteSpace(UserLoginTextBox.Text) && !string.IsNullOrWhiteSpace(UserPasswordPasswordBox.Password) && !string.IsNullOrWhiteSpace(UserSecretWordPasswordBox.Password))
            {
                bool check = true;
                foreach (Models.User user in App.Context.Users.ToList().Where(x=>x.Type == ((Models.UserType)UserTypeComboBox.SelectedItem).Id))
                {
                    if (user.Login == UserLoginTextBox.Text.Trim() && user.Password == UserPasswordPasswordBox.Password.Trim() && user.SecretWord == UserSecretWordPasswordBox.Password.Trim())
                    {
                        switch (((Models.UserType)UserTypeComboBox.SelectedItem).Name)
                        {
                            case "Администратор доступа":
                                Helpers.PageManager.Navigate(new Pages.AdministratorPage(), $"{user.FullName.Split(" ")[0]} {user.FullName.Split(" ")[1].First()}.{user.FullName.Split(" ")[2].First()}.");
                                break;

                            case "Служба ИБ":
                                Helpers.PageManager.Navigate(new Pages.IBServicePage(), $"{user.FullName.Split(" ")[0]} {user.FullName.Split(" ")[1].First()}.{user.FullName.Split(" ")[2].First()}.");
                                break;
                        }
                        check = false;
                        break;
                    }
                }
                if (check)
                    MessageBox.Show("Неверный логин, пароль или секретное слово", "Уведомление");
            }
            else
                MessageBox.Show("Заполните все поля", "Ошибка");
        }
    }
}
