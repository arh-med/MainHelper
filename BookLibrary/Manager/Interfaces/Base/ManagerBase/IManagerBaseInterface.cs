using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Interfaces.Base.ManagerBase
{
    public interface IManagerBaseInterface<T>
    {
        ObservableCollection<T> GetAll();

        T GetByID(Guid guid);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void Save();
    }
}
