using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdministratorDesktop.Helpers
{
    internal class PageManager
    {
        public static Frame MainFrame;

        public static void Navigate(Page page)
        {
            if (App.Current.Windows.OfType<MainWindow>().FirstOrDefault() != null)
            {
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinWidth = page.MinWidth;
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinHeight = page.MinHeight;
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().Title = page.Title;
            }
            MainFrame.Navigate(page);
        }
        public static void Navigate(Page page, string title)
        {
            if (App.Current.Windows.OfType<MainWindow>().FirstOrDefault() != null)
            {
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinWidth = page.MinWidth;
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinHeight = page.MinHeight;
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().Title = title;
            }
            MainFrame.Navigate(page);
        }
    }
}
