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
        public void Add(TaskClass newTask)
        {
            taskStoreInMemoryInterface.Add(newTask);
        }


        public void Delete(TaskClass removeTask)
        {
            taskStoreInMemoryInterface.Delete(removeTask);
        }

        public void Edit(TaskClass editTask)
        {
            taskStoreInMemoryInterface.Edit(editTask);
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
        public TaskClass Create(string Name, string Body, DateTime DateTimeTask, DateTime AlarmTimeTask, CategoryClass CategoryTask, bool CheckAlarm, string Priority)
        {
           return taskStoreInMemoryInterface.Create(Name, Body, DateTimeTask, AlarmTimeTask, CategoryTask, CheckAlarm,  Priority);
        }
    }
}
