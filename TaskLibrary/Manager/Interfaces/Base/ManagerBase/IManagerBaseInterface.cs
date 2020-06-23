using System;
using System.Collections.ObjectModel;

namespace TaskLibrary.Manager.Interfaces.ManagerBase
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
