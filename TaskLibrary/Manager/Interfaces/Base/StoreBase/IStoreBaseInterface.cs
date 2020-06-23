using System;
using System.Collections.ObjectModel;

namespace TaskLibrary.Manager.Interfaces.StoreBase
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
