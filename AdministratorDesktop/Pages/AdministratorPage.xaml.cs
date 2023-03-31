using AdministratorDesktop.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace AdministratorDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        private DispatcherTimer _timer;
        private bool _isLocked;
        public static string UserPhoto;
        public AdministratorPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GenderComboBox.ItemsSource = new List<string>() { "М", "Ж" };
        }

        public void Refresh()
        {
            SurnameTextBox.Text = string.Empty;
            NameTextBox.Text = string.Empty;
            SurnameTextBox.Text = string.Empty;
            PostTextBox.Text = string.Empty;
            GenderComboBox.SelectedItem = null;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri("../Assets/Images/User.png");
            bitmapImage.EndInit();
            UserPhotoImage.Source = bitmapImage;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите отменить?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Refresh();
                MessageBox.Show("Данные удалены", "Уведомление");
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            openFileDialog.Title = "Выберите фото";
            openFileDialog.Filter = "Фото|*.jpg;*.png;";
            if (openFileDialog.ShowDialog() != null)
            {
                if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                    bitmapImage.EndInit();
                    UserPhotoImage.Source = bitmapImage;
                    UserPhoto = openFileDialog.FileName;
                }
            }
        }

        private void SaveButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(SurnameTextBox.Text) && !string.IsNullOrWhiteSpace(PatronomycTextBox.Text) && !string.IsNullOrWhiteSpace(PostTextBox.Text) && GenderComboBox.SelectedItem != null && !string.IsNullOrWhiteSpace(UserPhoto))
            {
                Models.UserType userType = new UserType();
                if (!App.Context.UserTypes.Select(x => x.Name).Contains(PostTextBox.Text.Trim()))
                {
                    userType = new Models.UserType(App.Context.UserTypes.ToList().Max(x => x.Id) + 1, PostTextBox.Text.Trim(), null);
                    App.Context.UserTypes.Add(userType);
                }
                else
                    userType = App.Context.UserTypes.ToList().FirstOrDefault(x => x.Name == PostTextBox.Text.Trim());
                App.Context.Users.Add(new Models.User(App.Context.Users.ToList().Max(x => x.Id) + 1, $"{SurnameTextBox.Text.Trim()} {NameTextBox.Text.Trim()} {PatronomycTextBox.Text.Trim()}", GenderComboBox.SelectedItem.ToString(), 0, userType.Id, null, null, null, UserPhoto, 0, null, null));
                App.Context.SaveChanges();
                Refresh();
                MessageBox.Show("Вы успешно добавили пользователя", "Уведомление");
            }
            
        }

        private void SaveButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            File.WriteAllText("isBlock.bin", DateTime.Now.ToString());
            MessageBox.Show("Окно заблокированно", "Уведомление");
            Mouse.OverrideCursor = Cursors.Wait;
            this.IsEnabled = false;
            Thread.Sleep(300000);
            this.IsEnabled = true;
            Mouse.OverrideCursor = null;
            File.Delete("isBlock.bin");
        }
    }
}
