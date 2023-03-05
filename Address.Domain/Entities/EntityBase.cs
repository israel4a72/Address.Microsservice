using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Domain.Entities
{
    public class EntityBase
    {
        public DateTime CreationTime => DateTime.Now;
    }
}