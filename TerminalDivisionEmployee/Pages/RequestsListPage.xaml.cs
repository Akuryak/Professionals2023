using System;
using System.Collections.Generic;
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
using TerminalDivisionEmployee.Models;

namespace TerminalDivisionEmployee.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestsListPage.xaml
    /// </summary>
    public partial class RequestsListPage : Page
    {
        List<Models.Request> requests;
        Staff Staff;
        Thread thread;
        public RequestsListPage(Staff staff)
        {
            InitializeComponent();
            Staff = staff;

            thread = new Thread(CheckVisitors);
            thread.IsBackground = true;
            thread.Start();
        }

        public void CheckVisitors()
        {
            while (true)
            {
                Thread.Sleep(10 * 1000);
                foreach (Request request in Helpers.ApiRequests.GetList<Request>("http://localhost:8080/getRequests"))
                {
                    if (request.StatusNavigation != null)
                    {
                        if (request.StatusNavigation.Discription.Contains("Проход разрешен"))
                        {
                            if (request.Datetime.AddMinutes(-10).CompareTo(DateTime.Now) > 0)
                            {
                                MessageBox.Show($"Посетитель {request.Visitor.FullName} не дошел до подразделения за 10 минут", "Предупреджение");
                            }
                        }
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            requests = Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests").Where(x=>x.Division == Staff.Division && x.StatusNavigation.Discription.Contains("Проход разрешен")).ToList();
            if (requests != null)
                RequestsDataGrid.ItemsSource = requests;
            else
                MessageBox.Show("При получении данных произошла ошибка", "Ошибка");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectHelpers.FrameNavigator.Navigate(new AutorizationPage(), null);
        }

        private void OpenRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Button res = (Button)sender;
            Models.Request request = (Models.Request)res.DataContext;
            Windows.RequestInfoWindow requestEditWindow = new Windows.RequestInfoWindow(request);
            requestEditWindow.Show();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.Windows.OfType<Windows.ReportWindow>().FirstOrDefault() != null)
            {
                Windows.ReportWindow reportWindow = new Windows.ReportWindow();
                reportWindow.Show();
            }
            else
                MessageBox.Show("Нельзя открыть больше 1 окна", "Уведомление");
        }
    }
}
