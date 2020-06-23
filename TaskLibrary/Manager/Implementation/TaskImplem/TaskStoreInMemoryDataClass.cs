using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;
using TaskLibrary.Manager.LocalMemory;

namespace MainHelper.Services.ManagerData.TaskManagerData
{
    public class TaskStoreInMemoryDataClass : ITaskStoreInMemoryInterface
    {
        TaskLocalMemoryClass taskMemoryClass = new TaskLocalMemoryClass();

        public void Add(TaskClass addCategory)
        {
            taskMemoryClass.collectionClasses.Add(addCategory);
        }


        public void Delete(TaskClass removeCategory)
        {
            
        }

        public void Edit(TaskClass editCategory)
        {
          
        }

        public ObservableCollection<TaskClass> GetAll()
        {
            return taskMemoryClass.collectionClasses;
        }

        public TaskClass GetById(Guid guid)
        {
            return taskMemoryClass.collectionClasses.FirstOrDefault(c => c.Id == guid);
        }

        public void Save()
        {
            taskMemoryClass.Serialize();
        }
    }
}
