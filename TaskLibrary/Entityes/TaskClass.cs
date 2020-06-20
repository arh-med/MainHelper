using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes.Base;

namespace TaskLibrary.Entityes
{
    public class TaskClass : EntityNameClass
    {
        public string Body { get; set; }
        public DateTime DateTimeTask { get; set; }
        public bool CheckTask { get; set; }
        public DateTime AlarmTimeTask { get; set; }
        public CategoryClass CategoryTask { get; set; }

        public TaskClass(string Name, string Body, DateTime DateTimeTask,  DateTime AlarmTimeTask, CategoryClass CategoryTask)
        {
            Id = Guid.NewGuid();
            CheckTask = false;
            this.Name = Name;
            this.Body = Body;
            this.DateTimeTask = DateTimeTask;
            this.AlarmTimeTask = AlarmTimeTask;
            this.CategoryTask = CategoryTask;

        }
    }
}
