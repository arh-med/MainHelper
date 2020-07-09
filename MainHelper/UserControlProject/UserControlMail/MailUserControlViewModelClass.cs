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
using System.Windows.Controls;
using System.Windows.Input;

namespace MainHelper.UserControlProject.UserControlMail
{
    public class MailUserControlViewModelClass : ViewModelBase
    {
        IMailManagerInterface mailManager;
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
       
        private string login ;
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
        private string password ;
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
                {ReportPage = selectMessage.Body;
                 RaisePropertyChanged(ReportPage);}
                catch (Exception) { }
                try
                { mailManager.FlagSeen(selectMessage.Uid);
                  selectMessage.FlagMail = false;
                 
                }
                catch (Exception) {}
                
            }
        }



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

        public ICommand ConnectCommand { get; }
        private bool CanConnectCommandExecute(object parameter)
        {
            return true;
        }
        private void OnConnectCommandExecute(object parameter)
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
            bool mailConnection = mailManager.Connection(Login, Password, SelectComboBoxMail, 993);
            if (mailConnection == true)
            {
                mailManager.Indox();
                CountMessage = mailManager.Count();
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            }
           
        }

        public ICommand NextPageCommand { get; }
        private bool CanNextPageCommandExecute()
        {
            return true;
        }
        private void OnNextPageCommandExecute()
        {
            
            if (CountMessage > mailManager.Count() || CountMessage <= 0) return;
            CountMessage = CountMessage - 10;
            Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            SelectMessageBool = false;
        }

        public ICommand BackPageCommand { get; }
        private bool CanBackPageCommandExecute()
        {
            return true;
        }
        private void OnBackPageCommandExecute()
        {
           
            if (CountMessage >= mailManager.Count() || CountMessage <= 0) return;
            CountMessage = CountMessage + 10;
            Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
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

            bool mailConnection = mailManager.Connection(Login, Password, SelectComboBoxMail, 993);
            if (mailConnection == true)
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
        private void OnDeleteRangeMessageCommandExecute()
        {
            IList<int> massegaRange = new List<int>();
            foreach (MailClass mail in Mails)
            {
                if (mail.CheckMail == true)
                {
                    massegaRange.Add(mail.Uid);
                }
            }
            mailManager.DeleteRange(massegaRange);

            bool mailConnection = mailManager.Connection(Login, Password, SelectComboBoxMail, 993);
            if (mailConnection == true)
            {
                mailManager.Indox();
                CountMessage = mailManager.Count();
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
            }

            SelectMessageBool = false;

        }
        public MailUserControlViewModelClass(IMailManagerInterface mailManager)
        {
            if ((bool)Settings.Default["Remember"] == true)
            {
                Login = (string)Settings.Default["Login"];
                Password = (string)Settings.Default["Password"];
                SavePassword = (bool)Settings.Default["Remember"];
            }
            this.mailManager = mailManager;
            ConnectCommand = new RelayCommand<object>(OnConnectCommandExecute, CanDeleteMessageCommandExecute);
            DeleteMessageCommand = new RelayCommand<object>(OnDeleteMessageCommandExecute, CanConnectCommandExecute);
            DeleteRangeMessageCommand = new RelayCommand(OnDeleteRangeMessageCommandExecute, CanDeleteRangeMessageCommandExecute);
            NextPageCommand = new RelayCommand(OnNextPageCommandExecute, CanNextPageCommandExecute);
            BackPageCommand = new RelayCommand(OnBackPageCommandExecute, CanBackPageCommandExecute);
            ComboBoxMailAddress = new List<string> { "imap.mail.ru" };
            BackCommand = new RelayCommand(OnBackCommandExecute, CanBackCommandExecute);
        }
    }
}
