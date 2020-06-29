using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.CategoryInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Implementation.CategoryImplem
{
   public class CategoryBookManagerDataClass : ICategoryBookManagerInterface
    {
        ICategoryBookStoreInMemoryInterface categoryStoreInMemoryClass;
        public CategoryBookManagerDataClass(ICategoryBookStoreInMemoryInterface categoryStoreInMemoryClass)
        {
            this.categoryStoreInMemoryClass = categoryStoreInMemoryClass;
        }
        public void Add(CategoryClass entity)
        {
            categoryStoreInMemoryClass.Add(entity);
        }

        public CategoryClass Create(string Name, string Color)
        {
            return categoryStoreInMemoryClass.Create(Name, Color);
        }

        public void Delete(CategoryClass entity)
        {
            categoryStoreInMemoryClass.Delete(entity);
        }

        public void Edit(CategoryClass entity)
        {
           
        }

        public ObservableCollection<CategoryClass> GetAll()
        {
            return categoryStoreInMemoryClass.GetAll();
        }

        public CategoryClass GetByID(Guid guid)
        {
            return categoryStoreInMemoryClass.GetById(guid);
        }

        public void Save()
        {
            categoryStoreInMemoryClass.Save();
        }
    }
}
