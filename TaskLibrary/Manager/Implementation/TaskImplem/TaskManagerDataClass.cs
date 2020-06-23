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
    public class TaskManagerDataClass : ITaskManagerInterface
    {
        ITaskStoreInMemoryInterface taskStoreInMemoryInterface;
        public TaskManagerDataClass(ITaskStoreInMemoryInterface taskStoreInMemoryInterface)
        {
            this.taskStoreInMemoryInterface = taskStoreInMemoryInterface;
        }
        public void Add(TaskClass newCategory)
        {
            taskStoreInMemoryInterface.Add(newCategory);
        }


        public void Delete(TaskClass removeCategory)
        {
            
        }

        public void Edit(TaskClass editCategory)
        {
           
        }

        public ObservableCollection<TaskClass> GetAll()
        {
            return taskStoreInMemoryInterface.GetAll();
        }

        public TaskClass GetByID(Guid guid)
        {
            return taskStoreInMemoryInterface.GetById(guid);
        }

        public void Save()
        {
            taskStoreInMemoryInterface.Save();
        }
    }
}
