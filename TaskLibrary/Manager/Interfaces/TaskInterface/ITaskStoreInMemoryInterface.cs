using System;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces.StoreBase;

namespace TaskLibrary.Manager.Interfaces
{
    public interface ITaskStoreInMemoryInterface : IStoreBaseInterface<TaskClass>
    {
         TaskClass Create(string Name, string Body, DateTime DateTimeTask, DateTime AlarmTimeTask, CategoryClass CategoryTask, bool CheckAlarm, string Priority);
       
    }
}
