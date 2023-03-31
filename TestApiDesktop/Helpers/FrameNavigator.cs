using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestApiDesktop.Helpers
{
    internal class FrameNavigator
    {
        public static Frame MainFrame;

        public static void Navigate(Page page)
        {
            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinHeight = page.MinHeight;
            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinWidth = page.MinWidth;
            MainFrame.Navigate(page);
        }
    }
}
