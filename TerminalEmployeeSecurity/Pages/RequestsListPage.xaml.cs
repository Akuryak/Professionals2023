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
using TerminalEmployeeSecurity.Models;

namespace TerminalEmployeeSecurity.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestsListPage.xaml
    /// </summary>
    public partial class RequestsListPage : Page
    {
        List<Models.Request> requests;
        public RequestsListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            requests = Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests");
            if (requests != null)
                RequestsDataGrid.ItemsSource = requests;
            else
                MessageBox.Show("При получении данных произошла ошибка", "Ошибка");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Request> requests = Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests");
            if (requests != null)
                RequestsDataGrid.ItemsSource = requests;
            else
                MessageBox.Show("При получении данных произошла ошибка", "Ошибка");
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                Models.Request mainRequest = requests.FirstOrDefault(x=> SearchTextBox.Text.Contains(x.Visitor.FullName) || SearchTextBox.Text.Contains(x.Visitor.VisitorPassport));
                if (requests.Where(x => x.GroupId == mainRequest.GroupId).Count() > 1)
                    RequestsDataGrid.ItemsSource = requests.Where(x => x.GroupId == mainRequest.GroupId);
                else
                    RequestsDataGrid.ItemsSource = new List<Models.Request>() { mainRequest };
            }
            else
                RequestsDataGrid.ItemsSource = requests;
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
    }
}
