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
using Helpers;

namespace GeneralDepatmentEemployeesTerminal.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EmployeeCodeTextBox.Text))
            {
                if (int.TryParse(EmployeeCodeTextBox.Text, out int code))
                {
                    bool check = true;
                    List<Models.Staff> staffs = Helpers.ApiRequests.GetList<Models.Staff>("http://localhost:8080/getStaff");
                    if (staffs != null)
                    {
                        foreach (Models.Staff staff in staffs)
                        {
                            if (staff.StaffId == code)
                            {
                                ProjectHelpers.FrameNavigator.Navigate(new Pages.RequestsListPage(), "Просмотр заявок - " + staff.FullName);
                                check = false;
                                break;
                            }
                        }
                        if (check)
                            MessageBox.Show("Неверный код сотрудника", "Ошибка");
                    }
                    else
                        MessageBox.Show("При получении данных произошла ошибка", "Ошибка");
                }
                else
                    MessageBox.Show("Введите целое число в поле \"Код\".", "Ошибка");
            }
            else
                MessageBox.Show("Заполните все поля", "Ошибка");
        }
    }
}
