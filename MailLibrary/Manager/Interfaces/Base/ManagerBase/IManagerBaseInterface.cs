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

        void FlagSeen(int index);

    }
}
