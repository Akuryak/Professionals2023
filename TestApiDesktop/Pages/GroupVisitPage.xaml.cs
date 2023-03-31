using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для GroupVisitPage.xaml
    /// </summary>
    public partial class GroupVisitPage : Page
    {
        Visitor Visitor;
        public static string UserPhoto;
        public static string UserPassport;
        public GroupVisitPage(Visitor visitor)
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

            try
            {
                using (HttpClient getPurposes = new HttpClient())
                {
                    PurposOfTheVisitComboBox.ItemsSource = JsonConvert.DeserializeObject<List<Models.PurposOfTheVisit>>(getPurposes.GetAsync("http://localhost:8080/getPurposeOfTheVisit", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
                }
                using (HttpClient getSubdivisions = new HttpClient())
                {
                    SubdivisionComboBox.ItemsSource = JsonConvert.DeserializeObject<List<Models.Division>>(getSubdivisions.GetAsync("http://localhost:8080/getDivision", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении данных с сервера\n\n" + ex.ToString(), "Ошибка");
            }
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartDatePicker.SelectedDate != null)
            {
                EndDatePicker.IsEnabled = true;
                EndDatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, (DateTime)StartDatePicker.SelectedDate));
                EndDatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.Parse(StartDatePicker.SelectedDate.ToString()).AddDays(15), DateTime.MaxValue));
            }
            else EndDatePicker.IsEnabled = false;
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

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.SpecialFolder.CommonDocuments.ToString();
            openFileDialog.Title = "Выберите ваш скан паспорта";
            openFileDialog.Filter = "Пасспорт|*.pdf";
            if (openFileDialog.ShowDialog() != null)
            {
                UserPassport = openFileDialog.FileName;
                MessageBox.Show("Данные успешно загружены", "Уведомление");
            }
        }
    }
}
