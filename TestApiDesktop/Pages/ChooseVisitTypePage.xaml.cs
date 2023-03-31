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

namespace TestApiDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChooseVisitTypePage.xaml
    /// </summary>
    public partial class ChooseVisitTypePage : Page
    {
        public static Models.Visitor Visitor = null;
        public ChooseVisitTypePage(Models.Visitor visitor)
        {
            InitializeComponent();
            Visitor = visitor;
        }

        private void SoloVisit_Click(object sender, RoutedEventArgs e)
        {
            Helpers.FrameNavigator.Navigate(new Pages.SoloVisitPage(Visitor));
        }

        private void GroupVisit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
