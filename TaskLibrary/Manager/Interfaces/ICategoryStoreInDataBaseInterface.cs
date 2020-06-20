using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces.StoreBase;

namespace TaskLibrary.Manager.Interfaces
{
    public interface ICategoryStoreInDataBaseInterface : IStoreBaseInterface<CategoryClass>
    {
    }
}
