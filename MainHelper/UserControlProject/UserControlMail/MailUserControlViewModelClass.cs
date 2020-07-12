using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailLibrary.Entityes;
using MailLibrary.Manager.Interfaces.MailInterface;
using MainHelper.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MainHelper.UserControlProject.UserControlMail
{
    public class MailUserControlViewModelClass : ViewModelBase
    {
        IMailManagerInterface mailManager;
        private ObservableCollection<MailClass> mails;
        public ObservableCollection<MailClass> Mails
        {
            get
            {
                return mails;

            }
            set
            {
                Set(ref mails, value);
            }
        }
        public List<string> ComboBoxMailAddress { get; }

        #region Properties Login In
        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                Set(ref login, value);
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                Set(ref password, value);
            }
        }

        private bool savePassword;
        public bool SavePassword
        {
            get
            {
                return savePassword;
            }
            set
            {
                Set(ref savePassword, value);
            }
        }

        private string selectComboBoxMail;
        public string SelectComboBoxMail
        {
            get
            {
                return selectComboBoxMail;
            }
            set
            {
                Set(ref selectComboBoxMail, value);
            }
        }

        
        #endregion

        #region Properties Mails
        private int countMessage;
        public int CountMessage
        {
            get
            {
                return countMessage;
            }
            set
            {
                Set(ref countMessage, value);
            }
        }

        private bool selectMessageBool;
        public bool SelectMessageBool
        {
            get
            {
                return selectMessageBool;
            }
            set
            {
                Set(ref selectMessageBool, value);
            }
        }

        private string _reportPage;
        public string ReportPage
        {
            get
            {
                return _reportPage;
            }

            set
            {
                Set(ref _reportPage, value);
            }
        }

        private MailClass selectMessage;
        public MailClass SelectMessage
        {
            get
            {
                return selectMessage;
            }
            set
            {
                Set(ref selectMessage, value);
                SelectMessageBool = true;
                try
                {
                    ReportPage = selectMessage.Body;
                    RaisePropertyChanged(ReportPage);
                }
                catch (Exception) { }
                try
                {
                    mailManager.FlagSeen(selectMessage.Uid);
                    selectMessage.FlagMail = false;

                }
                catch (Exception) { }

            }
        }
        #endregion

        #region Properties SendMessage
        private string from;
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                Set(ref from, value);
            }
        }

        private string sendHeadline;
        public string SendHeadline
        {
            get
            {
                return sendHeadline;
            }
            set
            {
                Set(ref sendHeadline, value);
            }
        }

        private string sendBody;
        public string SendBody
        {
            get
            {
                return sendBody;
            }
            set
            {

                Set(ref sendBody, ($@"<h2>{value}</h2> "));
            }
        }

        private bool createMessage;
        public bool CreateMessage
        {
            get
            {
                return createMessage;
            }
            set
            {
                Set(ref createMessage, value);
            }
        }

        private string sendBool;
        public string SendBool
        {
            get
            {
                return sendBool;
            }
            set
            {
                Set(ref sendBool, value);
            }
        }
        #endregion

        #region Properties IsEnabled
        private bool buttonLoginIsEnabled;
        public bool ButtonLoginIsEnabled
        {
            get
            {
                return buttonLoginIsEnabled;
            }
            set
            {
                Set(ref buttonLoginIsEnabled, value);
            }
        }

        private bool mailConnection;
        public bool MailConnection
        {
            get
            {
                return mailConnection;
            }
            set
            {
                Set(ref mailConnection, value);
            }
        }

        private bool buttonSendIsEnabled;
        public bool ButtonSendIsEnabled
        {
            get
            {
                return buttonSendIsEnabled;
            }
            set
            {
                Set(ref buttonSendIsEnabled, value);
            }
        }

        private bool progressBarIsEnebled = false;
        public bool ProgressBarIsEnebled
        {
            get
            {
                return progressBarIsEnebled;
            }
            set
            {
                Set(ref progressBarIsEnebled, value);
            }
        }
        #endregion

        #region ICommand Mails
        public ICommand ConnectCommand { get; }
        private bool CanConnectCommandExecute(object parameter)
        {
            if (Login is null || Password is null || SelectComboBoxMail is null)
            {
                ButtonLoginIsEnabled = false;
                return false;
            }

            else
            {
                ButtonLoginIsEnabled = true;
                return true;
            }
        }
        private async void OnConnectCommandExecuteAsync(object parameter)
        {
           
            PasswordBox passwordBox = parameter as PasswordBox;
            Password = passwordBox.Password;
            #region SaveLogin
            if (SavePassword == true)
            {
                Settings.Default["Login"] = Login;
                Settings.Default["Password"] = Password;
                Settings.Default["Remember"] = true;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default["Login"] = "";
                Settings.Default["Password"] = "";
                Settings.Default["Remember"] = false;
                Settings.Default.Save();
            }
            #endregion
            ProgressBarIsEnebled = true;
            await Task.Run(Connection);
            void Connection()
            {
                MailConnection = mailManager.Connection(Login, Password, ($@"imap.{SelectComboBoxMail}"), 993);
                if (MailConnection == true)
                {
                    mailManager.Indox();
                    CountMessage = mailManager.Count();
                    if (CountMessage <= 0)
                    {
                        Mails = new ObservableCollection<MailClass>();
                    }
                    else
                    {
                        Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
                    }

                }
                else
                {
                    MessageBox.Show("The username or password is not correct");
                }
            }
            ProgressBarIsEnebled = false;

        }

        public ICommand NextPageCommand { get; }
        private bool CanNextPageCommandExecute()
        {
            return true;
        }
        private async void OnNextPageCommandExecuteAsync()
        {

            if (CountMessage > mailManager.Count() || CountMessage <= 0) return;
            CountMessage = CountMessage - 10;
            ProgressBarIsEnebled = true;
            await Task.Run(NextPage);
            void NextPage()
            {
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            }
            ProgressBarIsEnebled = false;
            SelectMessageBool = false;
        }

        public ICommand BackPageCommand { get; }
        private bool CanBackPageCommandExecute()
        {
            return true;
        }
        private async void OnBackPageCommandExecuteAsync()
        {

            if (CountMessage >= mailManager.Count() || CountMessage <= 0) return;
            CountMessage = CountMessage + 10;
            ProgressBarIsEnebled = true;
            await Task.Run(BackPage);
            void BackPage()
            {
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            }
            ProgressBarIsEnebled = false;
            SelectMessageBool = false;
        }

        public ICommand BackCommand { get; }
        private bool CanBackCommandExecute()
        {
            return true;
        }
        private void OnBackCommandExecute()
        {

            Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            SelectMessageBool = false;
        }

        public ICommand DeleteMessageCommand { get; }
        private bool CanDeleteMessageCommandExecute(object parameter)
        {
            return true;
        }
        private void OnDeleteMessageCommandExecute(object parameter)
        {
            MailClass mailClass = parameter as MailClass;
            mailManager.Delete(mailClass.Uid);

            MailConnection = mailManager.Connection(Login, Password, ($@"imap.{SelectComboBoxMail}"), 993);
            if (MailConnection == true)
            {
                mailManager.Indox();
                CountMessage = mailManager.Count();
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            }

            SelectMessageBool = false;

        }

        public ICommand DeleteRangeMessageCommand { get; }
        private bool CanDeleteRangeMessageCommandExecute()
        {
            return true;
        }
        private async void OnDeleteRangeMessageCommandExecuteAsync()
        {
            IList<int> massegaRange = new List<int>();
            foreach (MailClass mail in Mails)
            {
                if (mail.CheckMail == true)
                {
                    massegaRange.Add(mail.Uid);
                }
            }
            ProgressBarIsEnebled = true;
            await Task.Run(DeleteRange);
            void DeleteRange()
            {
                #region ifCount
                if (massegaRange.Count == 0)
                {
                    return;
                }
                if (massegaRange.Count == 1)
                {
                    mailManager.Delete(massegaRange[0]);
                }
                else
                {
                    mailManager.DeleteRange(massegaRange);
                }
                #endregion
                MailConnection = mailManager.Connection(Login, Password, ($@"imap.{SelectComboBoxMail}"), 993);
                if (MailConnection == true)
                {
                    mailManager.Indox();
                    CountMessage = mailManager.Count();
                    Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
                }
            }
            ProgressBarIsEnebled = false;
            SelectMessageBool = false;

        }
        #endregion

        #region ICommand SendMessage
        public ICommand NewEmailCommand { get; }
        private bool CanNewEmailCommandExecute()
        {
            return true;
        }
        private void OnNewEmailCommandExecute()
        {
            CreateMessage = true;
        }

        public ICommand SenEmailCommand { get; }
        private bool CanSenEmailCommandExecute()
        {
            if (From is null || From == "")
            {
                ButtonSendIsEnabled = false;
                return false;
            }
            else
            {
                ButtonSendIsEnabled = true;
                return true;
            } 
           
        }
        private void OnSenEmailCommandExecute()
        {
            SendBool =  mailManager.SendEmail(mailManager.CreatedEmail(Login, Login, From, SendBody, "smtp.mail.ru", 25, Login, Password, SendHeadline));
            CreateMessage = false;
            MessageBox.Show(SendBool);
           
        }

        public ICommand CloseNewEmailCommand { get; }
        private bool CanCloseNewEmailCommandExecute()
        {
            return true;
        }
        private void OnCloseNewEmailCommandExecute()
        {
            CreateMessage = false;
        }
        #endregion

        public MailUserControlViewModelClass(IMailManagerInterface mailManager)
        {
            this.mailManager = mailManager;

            #region RememberLoginPassword
            if ((bool)Settings.Default["Remember"] == true)
            {
                Login = (string)Settings.Default["Login"];
                Password = (string)Settings.Default["Password"];
                SavePassword = (bool)Settings.Default["Remember"];
            }
            #endregion

            #region Command Mails
            ConnectCommand = new RelayCommand<object>(OnConnectCommandExecuteAsync, CanDeleteMessageCommandExecute);
            DeleteMessageCommand = new RelayCommand<object>(OnDeleteMessageCommandExecute, CanConnectCommandExecute);
            DeleteRangeMessageCommand = new RelayCommand(OnDeleteRangeMessageCommandExecuteAsync, CanDeleteRangeMessageCommandExecute);
            NextPageCommand = new RelayCommand(OnNextPageCommandExecuteAsync, CanNextPageCommandExecute);
            BackPageCommand = new RelayCommand(OnBackPageCommandExecuteAsync, CanBackPageCommandExecute);
            ComboBoxMailAddress = new List<string> { "mail.ru" };
            BackCommand = new RelayCommand(OnBackCommandExecute, CanBackCommandExecute);
            #endregion

            #region Command SenMessage
            NewEmailCommand = new RelayCommand(OnNewEmailCommandExecute, CanNewEmailCommandExecute);
            SenEmailCommand = new RelayCommand(OnSenEmailCommandExecute, CanSenEmailCommandExecute);
            CloseNewEmailCommand = new RelayCommand(OnCloseNewEmailCommandExecute, CanCloseNewEmailCommandExecute);
            #endregion




        }
    }
}
