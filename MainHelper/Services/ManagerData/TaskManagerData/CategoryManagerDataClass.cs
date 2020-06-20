using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;

namespace MainHelper.Services.ManagerData.TaskManagerData
{
    public class CategoryManagerDataClass : ICategoryManagerInterface
    {
        ICategoryStoreInMemoryInterface categoryStoreInMemoryClass;
        public CategoryManagerDataClass(ICategoryStoreInMemoryInterface categoryStoreInMemoryClass)
        {
            this.categoryStoreInMemoryClass = categoryStoreInMemoryClass;
        }
        public ObservableCollection<CategoryClass> GetAll()
        {
            return categoryStoreInMemoryClass.GetAll();
        }
        public CategoryClass GetByID(Guid guid)
        {
            return categoryStoreInMemoryClass.GetById(guid);
        }

        public CategoryClass Create(string Name, string ColorCategory)
        {
            return categoryStoreInMemoryClass.Create(Name, ColorCategory);
        }
        public void Add(CategoryClass newCategory)
        {
            categoryStoreInMemoryClass.Add(newCategory);
        }
        public void Edit(CategoryClass editCategory)
        {

        }
        public void Delete(CategoryClass removeCategory)
        {

        }
        public void Save()
        {
            categoryStoreInMemoryClass.Save();
        }

       
    }
}
