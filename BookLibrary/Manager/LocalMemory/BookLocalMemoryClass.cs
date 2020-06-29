using BookLibrary.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.LocalMemory.LocalMemoryBase
{
    public class BookLocalMemoryClass : LocalMemoryBaseClass<BookClass>
    {
        public BookLocalMemoryClass() : base("Book")
        {
        }
    }
}
