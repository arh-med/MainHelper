using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes.Base;

namespace TaskLibrary.Entityes
{
    public class CategoryClass : EntityNameClass
    {
        public string ColorCategory { get; internal set; }
        public CategoryClass(string Name, string ColorCategory)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.ColorCategory = ColorCategory;
        }
        
    }
}
