using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Entityes
{
    public class CategoryClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ConsoleColor ColorCategory { get; set; }
        public CategoryClass(string Name, ConsoleColor ColorCategory)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.ColorCategory = ColorCategory;
        }
    }
}
