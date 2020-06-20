using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;

namespace TaskLibrary.Manager.Interfaces
{
    public interface ICategoryManagerInterface
    {
         ObservableCollection<CategoryClass> GetAll();

         void Add(CategoryClass newCategory);

         void Edit(CategoryClass editCategory);

         void Delete(CategoryClass removeCategory);
        
    }
}
