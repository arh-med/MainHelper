using MainHelper.UserControlProject.UserControlBook;
using MainHelper.UserControlProject.UserControlMail;
using MainHelper.UserControlProject.UserControlTask;
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
using System.Windows.Shapes;

namespace MainHelper.WindowsProject
{
    /// <summary>
    /// Логика взаимодействия для HomePanel.xaml
    /// </summary>
    public partial class HomePanel : Window
    {
        BookUserControl bookUserControl;
        TaskUserControl taskUserControl;
        MailUserControl mailUserControl;
        public HomePanel()
        {
            InitializeComponent();
            bookUserControl = new BookUserControl();
            taskUserControl = new TaskUserControl();
            mailUserControl = new MailUserControl();
        }

        private void ListViewItemBookUserControl(object sender, MouseButtonEventArgs e)
        {
            GridAddUserControl.Children.Clear();
            GridAddUserControl.Children.Add(bookUserControl);
            if (gridMenu.Width == 200)
                buttonOpenMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void ListViewItemTaskUserControl(object sender, MouseButtonEventArgs e)
        {
            GridAddUserControl.Children.Clear();
            GridAddUserControl.Children.Add(taskUserControl);
            if (gridMenu.Width == 200)
                buttonOpenMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void ListViewItemMailUserControl(object sender, MouseButtonEventArgs e)
        {
            GridAddUserControl.Children.Clear();
            GridAddUserControl.Children.Add(mailUserControl);
            if (gridMenu.Width == 200)
                buttonOpenMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}
