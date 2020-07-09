﻿using System;
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

namespace MainHelper.UserControlProject.UserControlMail
{
    /// <summary>
    /// Логика взаимодействия для MailUserControl.xaml
    /// </summary>
    public partial class MailUserControl : UserControl
    {
        public MailUserControl()
        {
            InitializeComponent();
            txt_Password.Password = txt_PasswordTextBloc.Text;
        }
    }
}
