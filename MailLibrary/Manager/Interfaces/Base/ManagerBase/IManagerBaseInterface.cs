using MailLibrary.Entityes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary.Manager.Interfaces.Base
{
    public interface IManagerBaseInterface<T>
    {
        ObservableCollection<T> GetAll(int Count, int returnMessage);

        bool Connection(string login, string password, string mail, int port);

        int Count();

        void Indox();

        void Delete(int index);

        void DeleteRange(IList<int> indexList);

        void FlagSeen(int index);

        SendMailClass CreatedEmail(string AddressSender, string NameSender, string AddresRecipient, string BodyMessage, string AddressServer, int Port, string Login, string Password,string Headline);

        string SendEmail(SendMailClass sendMailClass);
        

    }
}
