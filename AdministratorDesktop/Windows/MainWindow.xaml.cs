using System;
using System.Collections.Generic;
using System.IO;
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

namespace AdministratorDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Helpers.PageManager.MainFrame = MainFrame;
            Helpers.PageManager.Navigate(new Pages.AutorizationPage());
            if (File.Exists("isBlock.bin"))
            {
                DateTime dateTime = DateTime.Parse(File.ReadAllText("isBlock.bin"));
                if (dateTime.AddMinutes(5).CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show($"Окно заблокировано. Прошло {Math.Round((DateTime.Now - dateTime).TotalSeconds)} секунды.", "Уведомление");
                    Mouse.OverrideCursor = Cursors.Wait;
                    this.IsEnabled = false;
                    Thread.Sleep(300000 - (int)(DateTime.Now - dateTime).TotalMilliseconds);
                    this.IsEnabled = true;
                    Mouse.OverrideCursor = null;
                    File.Delete("isBlock.bin");
                }
                else
                    File.Delete("isBlock.bin");
            }
        }
    }
}
