using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MainHelper.UserControlProject.UserControlTask.Validators
{
    public static class WebBrowserUtilityUser
    {
        public static readonly DependencyProperty BindableSourceProperty =
                               DependencyProperty.RegisterAttached("BindableSource", typeof(string),
                               typeof(WebBrowserUtilityUser), new UIPropertyMetadata(null,
                               BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o,
                                                         DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebBrowser)o;
            webBrowser.NavigateToString((string)e.NewValue);
        }
    }
}
