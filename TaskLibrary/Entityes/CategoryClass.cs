using System;
using TaskLibrary.Entityes.Base;

namespace TaskLibrary.Entityes
{
    public class CategoryClass : EntityNameClass
    {
        public string ColorCategory { get;  set; }
        public CategoryClass(string Name, string ColorCategory)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.ColorCategory = ColorCategory;
        }
        
    }
}
