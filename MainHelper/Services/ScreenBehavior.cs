using MainHelper.WindowsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MainHelper.Services
{
    public class ScreenBehavior : Behavior<Image>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += ImageMouseLeftButtonDown;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= ImageMouseLeftButtonDown;
        }
        private void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HomePanel homePanel = new HomePanel();
            homePanel.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
