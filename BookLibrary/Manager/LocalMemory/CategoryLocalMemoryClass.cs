using BookLibrary.Entityes;
using BookLibrary.Manager.LocalMemory.LocalMemoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.LocalMemory
{
    public  class CategoryLocalMemoryClass : LocalMemoryBaseClass<CategoryClass>
    {
        public CategoryLocalMemoryClass() : base("CategoryBook")
        {
        }
    }
}
