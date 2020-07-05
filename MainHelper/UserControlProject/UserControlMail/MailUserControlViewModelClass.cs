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

        #region CollectionPage
        private ObservableCollection<int> countPage;
        public ObservableCollection<int> CountPage
        {
            get
            {
                return countPage;

            }
            set
            {
                Set(ref countPage, value);
            }
        }
        #endregion
        public ICommand ConnectCommand { get; }
        private bool CanConnectCommandExecute()
        {
            return true;
        }
        private void OnConnectCommandExecute()
        {
            Connection = true;
            bool mailConnection = mailManager.Connection(Login, Password, SelectComboBoxMail, 993);
            for (int i = 1; i <= mailManager.Count(); i++)
            {
                try
                {
                    if (i == 11)
                    {
                        return;
                    }
                    CountPage.Add(i);
                }
                catch (Exception)
                {

                    return;
                }
               
            }
           
            if (mailConnection == true)
            {
                Connection = false;
                Mails = new ObservableCollection<MailClass>(mailManager.GetAll());
            }
           
        }
        public MailUserControlViewModelClass(IMailManagerInterface mailManager)
        {
            this.mailManager = mailManager;
            ConnectCommand = new RelayCommand(OnConnectCommandExecute, CanConnectCommandExecute);
            ComboBoxMailAddress = new List<string> { "imap.mail.ru" };
            CountPage = new ObservableCollection<int>();
        }
    }
}
