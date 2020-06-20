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
        public string ColorCategory { get; set; }
        public CategoryClass(string Name, string ColorCategory)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.ColorCategory = ColorCategory;
        }
    }
}
