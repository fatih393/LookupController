using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Order;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Services.EntityServices
{
    public interface IOrderService : IEntityService<Order, OrderRequestDto, OrderResponseDto>
    {
    }
}
