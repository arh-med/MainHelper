using System;
using System.Collections.ObjectModel;
using System.Linq;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;
using TaskLibrary.Manager.LocalMemory.LocalMemoryBase;

namespace MainHelper.Services.ManagerData.TaskManagerData
{
    public class CategoryStoreInMemoryDataClass : ICategoryStoreInMemoryInterface
    {
        CategoryLocalMemoryClass localMemoryClass = new CategoryLocalMemoryClass();


        public ObservableCollection<CategoryClass> GetAll()
        {
            return localMemoryClass.collectionClasses;
        }
        public CategoryClass GetById(Guid guid)
        {
            return localMemoryClass.collectionClasses.FirstOrDefault(c => c.Id == guid);
        }
        public CategoryClass Create(string Name, string ColorCategory)
        {
            CategoryClass categoryClass = new CategoryClass(Name, ColorCategory);
            return categoryClass;
        }

        public void Add(CategoryClass newCategory)
        {
            localMemoryClass.collectionClasses.Add(newCategory);

        }
        public void Edit(CategoryClass editCategory)
        {

        }
        public void Delete(CategoryClass removeCategory)
        {

        }
        public void Save()
        {
            localMemoryClass.Serialize();
        }
       
    }
}
