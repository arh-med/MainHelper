using System;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces.ManagerBase;

namespace TaskLibrary.Manager.Interfaces
{
    public interface ITaskManagerInterface : IManagerBaseInterface<TaskClass>
    {
        TaskClass Create(string Name, string Body, DateTime DateTimeTask, DateTime AlarmTimeTask, CategoryClass CategoryTask, bool CheckAlarm, string Priority);
    }
}
