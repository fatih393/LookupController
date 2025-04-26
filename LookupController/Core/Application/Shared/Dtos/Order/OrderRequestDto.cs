using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Shared.Dtos.Order
{
    public class OrderRequestDto
    {
        public int ProductId { get; set; }
        public DateTime CreateOrderDate { get; set; } = DateTime.UtcNow;


    }
}
