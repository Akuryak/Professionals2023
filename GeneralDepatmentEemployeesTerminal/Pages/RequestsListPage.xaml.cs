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

namespace GeneralDepatmentEemployeesTerminal.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestsListPage.xaml
    /// </summary>
    public partial class RequestsListPage : Page
    {
        public RequestsListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Models.Request> requests = Helpers.ApiRequests.GetList<Models.Request>("http://localhost:8080/getRequests");
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

        private void EditRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Button res = (Button)sender;
            Models.Request request = (Models.Request)res.DataContext;
            if (App.Current.Windows.OfType<Windows.RequestEditWindow>().FirstOrDefault() == null)
            {
                Windows.RequestEditWindow requestEditWindow = new Windows.RequestEditWindow(request);
                requestEditWindow.Show();
            }
            else
                MessageBox.Show("Закройте предыдущие окна редактирования заявки", "Уведомление");
        }
    }
}
