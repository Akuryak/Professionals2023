using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
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

namespace TestApiDesktop.Pages
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

        public void LoginCheck()
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text.Trim()) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text.Trim()))
            {
                try
                {
                    using (HttpClient getVisitors = new HttpClient())
                    {
                        bool loginCheck = true;
                        bool passwordCheck = true;
                        foreach (Models.Visitor visitor in JsonConvert.DeserializeObject<List<Models.Visitor>>(getVisitors.GetAsync("http://localhost:8080/getVisitor", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result))
                        {
                            if (visitor.Login == LoginTextBox.Text.Trim() || visitor.Email == LoginTextBox.Text.Trim())
                            {
                                if (visitor.Password == Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox.Text.Trim()))))
                                {
                                    loginCheck = false;
                                    passwordCheck = false;
                                    Helpers.FrameNavigator.Navigate(new ChooseVisitTypePage(visitor));
                                    break;
                                }
                            }
                        }
                        if (loginCheck) MessageBox.Show("Неверный логин", "Ошибка");
                        else if (passwordCheck) MessageBox.Show("Неверный пароль", "Ошибка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Helpers.FrameNavigator.Navigate(new Pages.RegisterPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginCheck();
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginCheck();
            }
        }
    }
}
