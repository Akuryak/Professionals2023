using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using TestApiDesktop.Models;

namespace TestApiDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для SoloVisitPage.xaml
    /// </summary>
    public partial class SoloVisitPage : Page
    {
        public static Models.Visitor Visitor;
        public static string UserPhoto;
        public static string UserPassport;
        public SoloVisitPage(Models.Visitor visitor)
        {
            InitializeComponent();
            Visitor = visitor;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Helpers.FrameNavigator.Navigate(new ChooseVisitTypePage(Visitor));
            }
        }

        private void ClearFormTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Helpers.FrameNavigator.Navigate(new SoloVisitPage(Visitor));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StartDatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now));
            BirthdateDatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddYears(-16), DateTime.MaxValue));

            //try
            //{
            //    using (HttpClient getPurposes = new HttpClient())
            //    {
            //        PurposOfTheVisitComboBox.ItemsSource = JsonConvert.DeserializeObject<List<Models.PurposOfTheVisit>>(getPurposes.GetAsync("http://localhost:8080/getPurposeOfTheVisit", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
            //    }
            //    using(HttpClient getSubdivisions = new HttpClient())
            //    {
            //        SubdivisionComboBox.ItemsSource = JsonConvert.DeserializeObject<List<Models.Division>>(getSubdivisions.GetAsync("http://localhost:8080/getDivision", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("При получении данных с сервера\n\n" + ex.ToString(), "Ошибка");
            //}
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StartDatePicker.SelectedDate != null)
            {
                EndDatePicker.IsEnabled = true;
                EndDatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, (DateTime)StartDatePicker.SelectedDate));
                EndDatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.Parse(StartDatePicker.SelectedDate.ToString()).AddDays(15), DateTime.MaxValue));
            }
            else EndDatePicker.IsEnabled = false;
        }

        private void AcceptRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null && PurposOfTheVisitComboBox.SelectedItem != null && SubdivisionComboBox.SelectedItem != null && FullnameStaffsListBox.SelectedItem != null && !string.IsNullOrWhiteSpace(SurnameTextBox.Text) && !string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(DiscriptionTextBox.Text) && !string.IsNullOrWhiteSpace(PassSeriesTextBox.Text) && !string.IsNullOrWhiteSpace(PassNumberTextBox.Text))
            {
                if (PhoneNumberTextBox.Text[0] == '+' && char.IsDigit(PhoneNumberTextBox.Text[1]) && PhoneNumberTextBox.Text[2] == ' ' && PhoneNumberTextBox.Text[3] == '(' && char.IsDigit(PhoneNumberTextBox.Text[4]) && char.IsDigit(PhoneNumberTextBox.Text[5]) && char.IsDigit(PhoneNumberTextBox.Text[6]) && PhoneNumberTextBox.Text[7] == ')' && PhoneNumberTextBox.Text[8] == ' ' && char.IsDigit(PhoneNumberTextBox.Text[9]) && char.IsDigit(PhoneNumberTextBox.Text[10]) && char.IsDigit(PhoneNumberTextBox.Text[11]) && PhoneNumberTextBox.Text[12] == '-' && char.IsDigit(PhoneNumberTextBox.Text[13]) && char.IsDigit(PhoneNumberTextBox.Text[14]) && PhoneNumberTextBox.Text[15] == '-' && char.IsDigit(PhoneNumberTextBox.Text[16]) && char.IsDigit(PhoneNumberTextBox.Text[17]))
                {
                    if (EmailTextBox.Text.Contains("@") && EmailTextBox.Text.Contains("."))
                    {
                        if (UserPassport != null)
                        {
                            try
                            {
                                using (HttpClient postVisitor = new HttpClient())
                                {
                                    var responceVisitor = postVisitor.PutAsync("http://localhost:8080/putVisitor", new StringContent(JsonConvert.SerializeObject(new Models.Visitor(Visitor.Id, $"{SurnameTextBox.Text} {NameTextBox.Text} {PatronomicTextBox.Text}", PhoneNumberTextBox.Text, EmailTextBox.Text, $"{PassSeriesTextBox.Text}{PassNumberTextBox.Text}", DateOnly.Parse(((DateTime)BirthdateDatePicker.SelectedDate).ToShortDateString()), Visitor.Login, Visitor.Password, null)), Encoding.UTF8, "application/json"));
                                    using (HttpClient postRequest = new HttpClient())
                                    {
                                        using (HttpClient getMaxRequestID = new HttpClient())
                                        {
                                            var responceRequest = postRequest.PutAsync("http://localhost:8080/putRequest", new StringContent(JsonConvert.SerializeObject(new Models.Request(int.Parse(getMaxRequestID.GetAsync("http://localhost:8080/maxIdRequest", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result), "Личная", ((Models.Division)SubdivisionComboBox.SelectedItem).Id, DateTime.Now, null, null, null)), Encoding.UTF8, "application/json"));
                                            MessageBox.Show("Заявка успешно отправлена", "Уведомление");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка подключения");
                            }
                        }
                        else MessageBox.Show("Прикрепите скан паспорта", "Ошибка");
                    }
                    else MessageBox.Show("Проверьте правильность написания почты", "Ошибка");
                }
                else MessageBox.Show("Проверьте правильность написания номера телефона", "Ошибка");
            }
            else MessageBox.Show("Заполните все обязательные поля", "Ошибка");
        }

        private async void FullNameTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FullNameTextbox.Text))
            {
                try
                {
                    Models.Division selectedDivision = (Models.Division)SubdivisionComboBox.SelectedItem;
                    using (HttpClient getStaff = new HttpClient())
                    {
                        FullnameStaffsListBox.ItemsSource = JsonConvert.DeserializeObject<List<Models.Staff>>(getStaff.GetAsync("http://localhost:8080/getStaff", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result).Where(x => x.Division == selectedDivision.Id && x.FullName.Contains(FullNameTextbox.Text.Trim()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        private void SubdivisionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubdivisionComboBox.SelectedItem != null)
            {
                FullNameTextbox.Text = null;
                FullNameTextbox.IsEnabled = true;
                FullnameStaffsListBox.ItemsSource = null;
            }
            else FullNameTextbox.IsEnabled = false;
        }

        private void FullnameStaffsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FullnameStaffsListBox.SelectedItem != null)
            {
                Models.Staff staff = (Models.Staff)FullnameStaffsListBox.SelectedItem;
                FullNameTextbox.Text = staff.FullName;
            }
        }

        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.SpecialFolder.CommonPictures.ToString();
            openFileDialog.Title = "Выберите ваше фото";
            openFileDialog.Filter = "Фото|*.jpg";
            if (openFileDialog.ShowDialog() != null)
            {
                if (openFileDialog.FileName != "")
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length < 4000000)
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                        bitmapImage.EndInit();
                        UserPhotoImage.Source = bitmapImage;
                        UserPhoto = openFileDialog.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Размер файла больше 4мб", "Ошибка");
                        return;
                    }
                }
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.SpecialFolder.CommonDocuments.ToString();
            openFileDialog.Title = "Выберите ваш скан паспорта";
            openFileDialog.Filter = "Пасспорт|*.pdf";
            if (openFileDialog.ShowDialog() != null)
            {
                if (openFileDialog.FileName != "")
                {
                    UserPassport = openFileDialog.FileName;
                    MessageBox.Show("Данные успешно загружены", "Уведомление");
                }
            }
        }
    }
}
