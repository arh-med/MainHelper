using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;

namespace TaskLibrary.Manager.TaskManager
{
    public class CategoryManagerClass : ICategoryManagerInterface
    {
        ICategoryStoreInMemoryInterface categoryStoreInMemoryClass;
        public CategoryManagerClass(ICategoryStoreInMemoryInterface categoryStoreInMemoryClass)
        {
            this.categoryStoreInMemoryClass = categoryStoreInMemoryClass;
        }
        public ObservableCollection<CategoryClass> GetAll()
        {
            return categoryStoreInMemoryClass.GetAll();
        }
        public void Add (CategoryClass newCategory)
        {
            categoryStoreInMemoryClass.Add(newCategory);
        }
        public void Edit (CategoryClass editCategory)
        {

        }
        public void Delete (CategoryClass removeCategory)
        {

        }
    }
}
