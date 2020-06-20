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
    public class CategoryStoreInDataBaseClass : ICategoryStoreInDataBaseInterface
    {
        public void Add(CategoryClass addCategory)
        {
           
        }

        public CategoryClass Create(string Name, string ColorCategory)
        {
            throw new NotImplementedException();
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
