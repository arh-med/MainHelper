using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.CategoryInterface;
using BookLibrary.Manager.LocalMemory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Implementation.CategoryImplem
{
    public class CategoryBookStoreInMemoryDataClass : ICategoryBookStoreInMemoryInterface
    {
        CategoryLocalMemoryClass localMemoryClass = new CategoryLocalMemoryClass();
        
        public void Add(CategoryClass entity)
        {
            localMemoryClass.collectionClasses.Add(entity);
        }

        public CategoryClass Create(string Name, string Color)
        {
            CategoryClass categoryClass = new CategoryClass(Name, Color);
            return categoryClass;
        }

        public void Delete(CategoryClass entity)
        {
            int index = localMemoryClass.collectionClasses.IndexOf(entity);
            localMemoryClass.collectionClasses.RemoveAt(index);
        }

        public void Edit(CategoryClass entity)
        {
           
        }

        public ObservableCollection<CategoryClass> GetAll()
        {
            return localMemoryClass.collectionClasses;
        }

        public CategoryClass GetById(Guid guid)
        {
            return localMemoryClass.collectionClasses.FirstOrDefault(c => c.Id == guid);
        }

        public void Save()
        {
            localMemoryClass.Serialize();
        }
    }
}
