using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Shapes;
using TerminalEmployeeSecurity.Models;

namespace TerminalEmployeeSecurity.Windows
{
    /// <summary>
    /// Логика взаимодействия для RequestInfoWindow.xaml
    /// </summary>
    public partial class RequestInfoWindow : Window
    {
        Models.Request Request;
        Thread thread;
        public RequestInfoWindow(Models.Request request)
        {
            InitializeComponent();
            Request = request;
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
                            if (request.Datetime.AddMinutes(10).CompareTo(DateTime.Now) > 0)
                            {
                                MessageBox.Show($"Посетитель {request.Visitor.FullName} не дошел до подразделения за 10 минут", "Предупреджение");
                            }
                        }
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"Заявка от {Request.Datetime}";
        }

        private void AcceptVisitorLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            Models.Visit visit = Helpers.ApiRequests.GetList<Models.Visit>("http://localhost:8080/getVisit").LastOrDefault(x=>x.VisitorId == Request.VisitorId);
            if (visit != null)
            {
                if (VisitorLeaveDatePicker.SelectedDate == null)
                    visit.VisitDate = DateOnly.Parse(DateTime.Now.ToShortDateString());
                else
                    visit.VisitDate = DateOnly.Parse(VisitorLeaveDatePicker.SelectedDate.Value.ToShortDateString());
                Helpers.ApiRequests.PostObject("http://localhost:8080/putVisit", visit);
            }
            else
                MessageBox.Show("Пользователь еще не пришел", "Ошибка");
        }

        private void AcceptVisitorButton_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            if (Request.GroupId != null)
            {
                foreach (Models.Request request in Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests").Where(x => x.GroupId == Request.GroupId).ToList())
                {
                    request.Datetime = DateTime.Now;
                    request.StatusNavigation.Discription = "Проход разрешен";
                    Helpers.ApiRequests.PostObject("http://localhost:8080/putRequest", request);
                }
            }
            else
            {
                Request.Datetime = DateTime.Now;
                Request.StatusNavigation.Discription = "Проход разрешен";
                Helpers.ApiRequests.PostObject("http://localhost:8080/putRequest", Request);
            }
                
        }
    }
}
