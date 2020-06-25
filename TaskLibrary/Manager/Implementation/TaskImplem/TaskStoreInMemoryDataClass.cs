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

        public void Add(TaskClass addTask)
        {
            taskMemoryClass.collectionClasses.Add(addTask);
        }


        public void Delete(TaskClass removeTask)
        {
            int index = taskMemoryClass.collectionClasses.IndexOf(removeTask);
            taskMemoryClass.collectionClasses.RemoveAt(index);
        }

        public void Edit(TaskClass editTask)
        {
            Guid guid = editTask.Id;
            int index = taskMemoryClass.collectionClasses.IndexOf(taskMemoryClass.collectionClasses.FirstOrDefault(c => c.Id == guid));
            taskMemoryClass.collectionClasses.RemoveAt(index);
            TaskClass taskClassEdit = editTask;
            taskMemoryClass.collectionClasses.Add(taskClassEdit);
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
        public TaskClass Create(string Name, string Body, DateTime DateTimeTask, DateTime AlarmTimeTask, CategoryClass CategoryTask, bool CheckAlarm, string Priority)
        {
            TaskClass taskClass = new TaskClass(Name, Body, DateTimeTask, AlarmTimeTask, CategoryTask, CheckAlarm, Priority);
            return taskClass;
        }
    }
}
