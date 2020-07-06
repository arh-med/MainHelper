using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailLibrary.Entityes;
using MailLibrary.Manager.Interfaces.MailInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainHelper.UserControlProject.UserControlMail
{
    public class MailUserControlViewModelClass : ViewModelBase
    {
        IMailManagerInterface mailManager;
        private bool connection;
        public bool Connection
        {
            get
            {
                return connection;
            }
            set
            {
                Set(ref connection, value);
            }
        }
        private string login = "arh_med@mail.ru";
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
        private string password = "103A89a217";
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
        private bool CanConnectCommandExecute()
        {
            return true;
        }
        private void OnConnectCommandExecute()
        {
            Connection = true;
            bool mailConnection = mailManager.Connection(Login, Password, SelectComboBoxMail, 993);
            if (mailConnection == true)
            {
                mailManager.Indox();
                CountMessage = mailManager.Count();
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll(CountMessage, 10));
                Connection = false;
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

        }
        public MailUserControlViewModelClass(IMailManagerInterface mailManager)
        {
            this.mailManager = mailManager;
            ConnectCommand = new RelayCommand(OnConnectCommandExecute, CanConnectCommandExecute);
            NextPageCommand = new RelayCommand(OnNextPageCommandExecute, CanNextPageCommandExecute);
            BackPageCommand = new RelayCommand(OnBackPageCommandExecute, CanBackPageCommandExecute);
            ComboBoxMailAddress = new List<string> { "imap.mail.ru" };
           
        }
    }
}
