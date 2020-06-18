using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Entityes
{
    public class TaskClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime DateTimeTask { get; set; }
        public bool CheckTask { get; set; }
        public DateTime AlarmTimeTask { get; set; }
        public CategoryClass CategoryTask { get; set; }

        public TaskClass(string Name, string Body, DateTime DateTimeTask,  DateTime AlarmTimeTask, CategoryClass CategoryTask)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Body = Body;
            this.DateTimeTask = DateTimeTask;
            this.CheckTask = false;
            this.AlarmTimeTask = AlarmTimeTask;
            this.CategoryTask = CategoryTask;

        }
    }
}
