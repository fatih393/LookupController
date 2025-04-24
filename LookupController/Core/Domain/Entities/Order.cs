using Lookupcontroller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lookupcontroller.Domain.Entities
{
    public class Order: BaseEntity
    {
        public DateTime CreateOrderDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
