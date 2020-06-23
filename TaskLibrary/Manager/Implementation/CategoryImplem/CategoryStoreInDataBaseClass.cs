using System;
using System.Collections.ObjectModel;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;

namespace MainHelper.Services.ManagerData.TaskManagerData
{
    public class CategoryStoreInDataBaseClass : ICategoryStoreInDataBaseInterface
    {
        public void Add(CategoryClass addCategory)
        {
           
        }


        public void Delete(CategoryClass removeCategory)
        {
           
        }

        public void Edit(CategoryClass editCategory)
        {
           
        }

        public ObservableCollection<CategoryClass> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryClass GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            
        }
    }
}
