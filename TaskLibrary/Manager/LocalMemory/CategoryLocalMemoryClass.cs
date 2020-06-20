using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Entityes;

namespace TaskLibrary.Manager.LocalMemory.LocalMemoryBase
{
    public  class CategoryLocalMemoryClass : LocalMemoryBaseClass<CategoryClass>
    {
        public CategoryLocalMemoryClass(string Name) : base(Name)
        {
        }
    }
}
