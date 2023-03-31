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

namespace GeneralDepatmentEemployeesTerminal.Windows
{
    /// <summary>
    /// Логика взаимодействия для RequestEditWindow.xaml
    /// </summary>
    public partial class RequestEditWindow : Window
    {
        Models.Request Request;
        List<Models.Visitor> visitors;
        public RequestEditWindow(Models.Request request)
        {
            InitializeComponent();
            Request = request;
        }

        public void Refresh()
        {
            TypeTextBox.Text = Request.Type;
            DivisionComboBox.SelectedItem = Request.Division;
            VisitDatePicker.SelectedDate = Request.Datetime;
            if (Request.StatusNavigation.Status1 == 1) StatusCheckBox.IsChecked = true;
            DiscriptionTextBox.Text = Request.StatusNavigation.Discription;

            NameTextBox.Text = Request.Visitor.FullName;
            EmailTextBox.Text = Request.Visitor.Email;
            PhoneNumberTextBox.Text = Request.Visitor.PhoneNumber;
            PassSeriesTextBox.Text = Request.Visitor.VisitorPassport.Substring(0, 3);
            PassNumberTextBox.Text = Request.Visitor.VisitorPassport.Substring(4, 9);
            BirthdateDatePicker.SelectedDate = Request.Visitor.Birthdate.Value.ToDateTime(new TimeOnly(0, 0));
        }

        public void BlackListDetected()
        {
            TypeTextBox.IsEnabled = false;
            DivisionComboBox.IsEnabled = false;
            VisitDatePicker.IsEnabled = false;
            StatusCheckBox.IsEnabled = false;
            DiscriptionTextBox.IsEnabled = false;

            NameTextBox.IsEnabled = false;
            EmailTextBox.Text = Request.Visitor.Email;
            PhoneNumberTextBox.IsEnabled = false;
            PassSeriesTextBox.IsEnabled = false;
            PassNumberTextBox.IsEnabled = false;
            BirthdateDatePicker.IsEnabled = false;

            StatusCheckBox.IsChecked = false;
            Request.StatusNavigation.Status1 = 0;
            Request.StatusNavigation.Discription = "Заявка на посещение объекта КИИ отклонена в связи с нарушением Федерального закона от 26.07.2017 № 187-ФЗ «О безопасности критической информационной инфраструктуры Российской Федерации»";
            Helpers.ApiRequests.PostObject("http://localhost:8080/putRequest", Request);
        }

        private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            visitors = new List<Models.Visitor>();
            visitors = (List<Models.Visitor>)Helpers.ApiRequests.GetList<Models.Visit>("http://localhost/getVisit").Where(x => x.GroupId == Request.GroupId);

            int counter = 0;
            if (visitors.Count > 0)
            {
                foreach (Models.Request req in Helpers.ApiRequests.GetList<Models.Request>("http://localhost/getRequests"))
                {
                    foreach (Models.Visitor visitor in visitors)
                    {
                        if (req.Visitor.Id == visitor.Id || req.Visitor.Id == visitor.Id && Request.StatusNavigation.Discription.Contains("недостоверных данных"))
                            counter++;
                    }
                }
            }
            if (counter > 1)
                MessageBox.Show("Пользователь находится в черном списке");
            DivisionComboBox.ItemsSource = Helpers.ApiRequests.GetList<Models.Division>("http://localhost:8080/getDivision");
            if (Request.Type == "Групповая")
                VisitorsListBox.ItemsSource = visitors;
            else
                VisitorsListBox.Visibility = Visibility.Collapsed;
            Refresh();
            BlackListDetected();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TypeTextBox.Text) && DivisionComboBox.SelectedItem != null && VisitDatePicker.SelectedDate != null && !string.IsNullOrWhiteSpace(DiscriptionTextBox.Text))
            {
                if (!string.IsNullOrWhiteSpace(TypeTextBox.Text) && DivisionComboBox.SelectedItem != null && VisitDatePicker.SelectedDate != null && !string.IsNullOrWhiteSpace(DiscriptionTextBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) && !string.IsNullOrWhiteSpace(PassNumberTextBox.Text) && !string.IsNullOrWhiteSpace(PassSeriesTextBox.Text) && BirthdateDatePicker.SelectedDate != null)
                    {
                        if ((bool)StatusCheckBox.IsChecked)
                            Request.StatusNavigation.Status1 = 1;
                        else
                            Request.StatusNavigation.Status1 = 0;
                        Request.Type = TypeTextBox.Text;
                        Request.DivisionNavigation = (Models.Division)DivisionComboBox.SelectedItem;
                        Request.Datetime = (DateTime)VisitDatePicker.SelectedDate;
                        Request.StatusNavigation.Discription = DiscriptionTextBox.Text;

                        ((Models.Visitor)VisitorsListBox.SelectedItem).FullName = NameTextBox.Text;
                        ((Models.Visitor)VisitorsListBox.SelectedItem).Email = EmailTextBox.Text;
                        ((Models.Visitor)VisitorsListBox.SelectedItem).PhoneNumber = PhoneNumberTextBox.Text;
                        ((Models.Visitor)VisitorsListBox.SelectedItem).VisitorPassport = $"{PassSeriesTextBox.Text}{PassNumberTextBox.Text}";
                        ((Models.Visitor)VisitorsListBox.SelectedItem).Birthdate = DateOnly.Parse(((DateTime)BirthdateDatePicker.SelectedDate).ToShortDateString());

                        Helpers.ApiRequests.PostObject("http://localhost:8080/putVisitor", ((Models.Visitor)VisitorsListBox.SelectedItem));
                        Helpers.ApiRequests.PostObject("http://localhost:8080/putRequest", Request);
                    }
                    else MessageBox.Show("Заполните все поля", "Ошибка");
                }
                else MessageBox.Show("Заполните все поля", "Ошибка");
            }
            else MessageBox.Show("Заполните все поля", "Ошибка");
        }

        private void VisitorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VisitorsListBox.SelectedItem != null)
            {
                NameTextBox.Text = ((Models.Visitor)VisitorsListBox.SelectedItem).FullName;
                EmailTextBox.Text = ((Models.Visitor)VisitorsListBox.SelectedItem).Email;
                PhoneNumberTextBox.Text = ((Models.Visitor)VisitorsListBox.SelectedItem).PhoneNumber;
                PassSeriesTextBox.Text = ((Models.Visitor)VisitorsListBox.SelectedItem).VisitorPassport.Substring(0, 3);
                PassNumberTextBox.Text = ((Models.Visitor)VisitorsListBox.SelectedItem).VisitorPassport.Substring(4, 9);
                BirthdateDatePicker.SelectedDate = ((Models.Visitor)VisitorsListBox.SelectedItem).Birthdate.Value.ToDateTime(new TimeOnly(0, 0));
            }
        }
    }
}
