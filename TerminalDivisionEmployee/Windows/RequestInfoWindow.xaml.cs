using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using TerminalDivisionEmployee.Models;

namespace TerminalDivisionEmployee.Windows
{
    /// <summary>
    /// Логика взаимодействия для RequestInfoWindow.xaml
    /// </summary>
    public partial class RequestInfoWindow : Window
    {
        Models.Request Request;
        public RequestInfoWindow(Models.Request request)
        {
            InitializeComponent();
            Request = request;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"Заявка от {Request.Datetime}";
        }

        private void AcceptVisitorLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Request.GroupId != null)
            {
                foreach (Models.Request request in Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests").Where(x => x.GroupId == Request.GroupId && x.StatusNavigation.Discription.Contains("Проход разрешен")).ToList())
                {
                    if (VisitorLeaveDatePicker.SelectedDate != null)
                        request.Datetime = (DateTime)VisitorLeaveDatePicker.SelectedDate;
                    else
                        request.Datetime = DateTime.Now;
                    request.StatusNavigation.Discription = "Посетитель убывает";
                    Helpers.ApiRequests.PostObject("http://localhost:8080/putRequest", request);
                }
            }
            else
            {
                if (VisitorLeaveDatePicker.SelectedDate != null)
                    Request.Datetime = (DateTime)VisitorLeaveDatePicker.SelectedDate;
                else
                    Request.Datetime = DateTime.Now;
                Request.StatusNavigation.Discription = "Посетитель убывает";
                Helpers.ApiRequests.PostObject("http://localhost:8080/putRequest", Request);
            }
        }

        private void AcceptVisitorButton_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            if (Request.GroupId != null)
            {
                foreach (Models.Request request in Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests").Where(x => x.GroupId == Request.GroupId).ToList())
                {
                    Helpers.ApiRequests.PostObject("http://localhost:8080/putVisit", new Models.Visit(Helpers.ApiRequests.GetObject<int>("http://localhost:8080/maxIdVisit"), request.Visitor.Id, DateTime.Now, null, null, null));
                    Helpers.ApiRequests.DeleteObject<Models.Request>($"http://localhost:8080/deleteRequest/{request.Id}");
                }
            }
            else
            {
                Helpers.ApiRequests.PostObject("http://localhost:8080/putVisit", new Models.Visit(Helpers.ApiRequests.GetObject<int>("http://localhost:8080/maxIdVisit"), Request.Visitor.Id, DateTime.Now, null, null, null));
                Helpers.ApiRequests.DeleteObject<Models.Request>($"http://localhost:8080/deleteRequest/{Request.Id}");
            }
                
        }

        private void BlockVisitorButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите занести пользователя {Request.Visitor.FullName} в черный список?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Request.Visitor.Blacklist = 1;
                Helpers.ApiRequests.PostObject("http://localhost:8080/putVisitor", Request.Visitor);
                Helpers.ApiRequests.DeleteObject<Request>($"http://localhost:8080/deleteRequests/{Request.Id}");
            }
        }
    }
}
