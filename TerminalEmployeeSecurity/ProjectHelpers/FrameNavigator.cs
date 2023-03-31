using System.Linq;
using System.Windows.Controls;

namespace TerminalEmployeeSecurity.ProjectHelpers
{
    internal class FrameNavigator
    {
        public static Frame MainFrame;

        public static void Navigate(Page page, string? title)
        {
            if (App.Current.Windows.OfType<MainWindow>().FirstOrDefault() != null)
            {
                if (title == null)
                    App.Current.Windows.OfType<MainWindow>().FirstOrDefault().Title = page.Title;
                else
                    App.Current.Windows.OfType<MainWindow>().FirstOrDefault().Title = title;
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinHeight = page.MinHeight;
                App.Current.Windows.OfType<MainWindow>().FirstOrDefault().MinWidth = page.MinWidth;
                MainFrame.Navigate(page);
            }
        }
    }
}
