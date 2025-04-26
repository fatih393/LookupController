using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.EntityServices;
using Lookupcontroller.Application.Shared.Dtos.Order;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities;
using Lookupcontroller.Persistance.Services.EntityServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.EntityServices
{
    public class OrderService : EntityService<Order, OrderRequestDto, OrderResponseDto>, IOrderService
    {
        public OrderService(IOrderReadRepository readRepository, IOrderWriteRepository writeRepository)
            : base(readRepository, writeRepository)
        {
        }
    }
}
