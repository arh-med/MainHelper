using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Manager.Interfaces.ManagerBase
{
    public interface IManagerBaseInterface<T>
    {
        ObservableCollection<T> GetAll();

        T GetByID(Guid guid);

        T Create(string Name, string ColorCategory);

        void Add(T newCategory);

        void Edit(T editCategory);

        void Delete(T removeCategory);

        void Save();
    }
}
