using Lookupcontroller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int stock { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
