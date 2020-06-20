using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Manager.Interfaces.StoreBase
{
    public interface IStoreBaseInterface<T>
    {
        ObservableCollection<T> GetAll();

        T GetById(Guid guid);

        T Create(string Name, string ColorCategory);

        void Add(T addCategory);

        void Edit(T editCategory);

        void Delete(T removeCategory);

        void Save();
    }
}
