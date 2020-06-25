using System;
using TaskLibrary.Entityes.Base;

namespace TaskLibrary.Entityes
{
    public class TaskClass : EntityNameClass
    {
        public string Body { get; set; }
        public DateTime DateTimeTask { get; set; }
        public bool CheckTask { get; set; }
        public bool CheckAlarm { get; set; }
        public DateTime AlarmTimeTask { get; set; }
        public CategoryClass CategoryTask { get; set; }
        public string Priority { get; set; }

        public TaskClass(string Name, string Body, DateTime DateTimeTask,  DateTime AlarmTimeTask, CategoryClass CategoryTask, bool CheckAlarm, string Priority)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Body = Body;
            this.DateTimeTask = DateTimeTask;
            this.AlarmTimeTask = AlarmTimeTask;
            this.CategoryTask = CategoryTask;
            this.CheckAlarm = CheckAlarm;
            this.Priority = Priority;

        }
    }
}
