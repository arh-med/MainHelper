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
    public class TaskStoreInDataBaseClass : ITaskStoreInDataBaseInterface
    {
        public void Add(TaskClass addCategory)
        {
           
        }


        public void Delete(TaskClass removeCategory)
        {
           
        }

        public void Edit(TaskClass editCategory)
        {
            
        }

        public ObservableCollection<TaskClass> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskClass GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
           
        }
    }
}
