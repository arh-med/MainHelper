using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Interfaces.Base.StoreBase
{
    public interface IStoreBaseInterface<T>
    {
        ObservableCollection<T> GetAll();

        T GetById(Guid guid);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void Save();
    }
}
