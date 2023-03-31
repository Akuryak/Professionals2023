using AdministratorDesktop.Models;
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
    /// Логика взаимодействия для IBServicePage.xaml
    /// </summary>
    public partial class IBServicePage : Page
    {
        public IBServicePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = App.Context.Users.ToList().Where(x=>x.Verificated == 0);
            UserType.ItemsSource = App.Context.UserTypes.ToList();

            AccessСredentialsUsersDataGrid.ItemsSource = App.Context.Users.ToList();
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserLogin.Text = ((User)sender).Login;
            UserPassword.Text = ((User)sender).Password;
            UserSecretWord.Text = ((User)sender).SecretWord;
            UserType.SelectedItem = ((User)sender).TypeNavigation;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(UserLogin.Text) && !string.IsNullOrWhiteSpace(UserPassword.Text) && !string.IsNullOrWhiteSpace(UserSecretWord.Text) && UserType.SelectedItem != null)
                {
                    App.Context.Users.FirstOrDefault(x=>x.Id == ((User)UsersDataGrid.SelectedItem).Id).Login = UserLogin.Text;
                    App.Context.Users.FirstOrDefault(x=>x.Id == ((User)UsersDataGrid.SelectedItem).Id).Password = UserPassword.Text;
                    App.Context.Users.FirstOrDefault(x=>x.Id == ((User)UsersDataGrid.SelectedItem).Id).SecretWord = UserSecretWord.Text;
                    App.Context.Users.FirstOrDefault(x => x.Id == ((User)UsersDataGrid.SelectedItem).Id).Type = ((UserType)UserType.SelectedItem).Id;
                    if ((bool)VerificateUserCheckBox.IsChecked)
                        App.Context.Users.FirstOrDefault(x => x.Id == ((User)UsersDataGrid.SelectedItem).Id).Verificated = 1;
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные сохранены", "Уведомление");
                    Helpers.PageManager.MainFrame.Navigate(new IBServicePage());
                }
                else
                    MessageBox.Show("Заполните все поля", "Ошибка");
            }
            else
                MessageBox.Show("Выберите пользователя", "Ошибка");
        }

        private void VerificationButton_Click(object sender, RoutedEventArgs e)
        {
            VerificationGrid.Visibility = Visibility.Visible;
            AccessСredentialsGrid.Visibility = Visibility.Collapsed;
            AccessСredentialsButton.Background = new SolidColorBrush(Colors.Silver);
            VerificationButton.Background = new SolidColorBrush(Colors.LightBlue);
        }

        private void AccessСredentialsButton_Click(object sender, RoutedEventArgs e)
        {
            VerificationGrid.Visibility = Visibility.Collapsed;
            AccessСredentialsGrid.Visibility = Visibility.Visible;
            VerificationButton.Background = new SolidColorBrush(Colors.Silver);
            AccessСredentialsButton.Background = new SolidColorBrush(Colors.LightBlue);
        }

        private void AcceptUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessСredentialsUsersDataGrid.SelectedItem != null)
            {
                App.Context.SaveChanges();
                MessageBox.Show("Данные сохранены", "Уведомление");
                Helpers.PageManager.MainFrame.Navigate(new IBServicePage());
            }
            else
                MessageBox.Show("Выберите пользователя", "Ошибка");
        }
    }
}
