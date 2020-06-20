using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;
using TaskLibrary.Manager.LocalMemory;

namespace TaskLibrary.Manager.TaskManager
{
    public  class CategoryStoreInMemoryClass : ICategoryStoreInMemoryInterface
    {
        LocalMemoryClass  localMemoryClass = new LocalMemoryClass();
        public ObservableCollection<CategoryClass> GetAll()
        {
            return localMemoryClass.categoryClasses;
        }
        public void Add(CategoryClass newCategory)
        {
            localMemoryClass.categoryClasses.Add(newCategory);
            localMemoryClass.Serialize();
        }
        public void Edit(CategoryClass editCategory)
        {

        }
        public void Delete(CategoryClass removeCategory)
        {

        }
    }
}
