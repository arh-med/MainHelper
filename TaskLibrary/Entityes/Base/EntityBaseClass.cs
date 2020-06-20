using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Entityes.Base
{
    public abstract class EntityBaseClass
    {
        public Guid Id { get; internal set; }
    }
}
