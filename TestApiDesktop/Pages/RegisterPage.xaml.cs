using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.BorderBrush != new SolidColorBrush(Colors.Red) && !string.IsNullOrWhiteSpace(PasswordTextBox.Text) && PasswordTextBox.Text.Trim().Count() > 4)
            {
                try
                {
                    using (HttpClient getVisitors = new HttpClient())
                    {
                        if (JsonConvert.DeserializeObject<List<Models.Visitor>>(getVisitors.GetAsync("http://localhost:8080/getVisitor", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result).ToList().FirstOrDefault(x => x.Email == EmailTextBox.Text.Trim()) == null)
                        {
                            using (HttpClient putClient = new HttpClient())
                            {
                                using (HttpClient getMaxIdClient = new HttpClient())
                                {
                                    var responce = putClient.PutAsync("http://localhost:8080/putVisitor", new StringContent(JsonConvert.SerializeObject(new Models.Visitor(int.Parse(getMaxIdClient.GetAsync("http://localhost:8080/maxIdVisitor", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result) + 1, null, null, EmailTextBox.Text, null, null, EmailTextBox.Text, Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox.Text))), null)), Encoding.UTF8, "application/json")).Result;
                                    MessageBox.Show(responce.Content.ReadAsStringAsync().Result, "Уведомление");
                                    Helpers.FrameNavigator.Navigate(new AutorizationPage());
                                }
                            }
                        }
                        else MessageBox.Show("Такой email уже занят", "Ошибка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при отправке данных\n" + ex.ToString(), "Ошибка");
                }
            }
            else
                MessageBox.Show("Заполните все поля и проверьте правильность написания почты\n\nПароль должен содержать от 5 символов", "Ошибка");
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!EmailTextBox.Text.Contains("@") && !EmailTextBox.Text.Contains(".") || string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else EmailTextBox.BorderBrush = new SolidColorBrush(Colors.Orange);
        }

        private void ReturnBackButton_Click(object sender, RoutedEventArgs e)
        {
            Helpers.FrameNavigator.Navigate(new AutorizationPage());
        }
    }
}
