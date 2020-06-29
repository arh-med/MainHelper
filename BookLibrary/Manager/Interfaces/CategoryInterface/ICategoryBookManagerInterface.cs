using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.Base.ManagerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Interfaces.CategoryInterface
{
   public interface ICategoryBookManagerInterface : IManagerBaseInterface<CategoryClass>
    {
        CategoryClass Create(string Name, string Color);
    }
}
