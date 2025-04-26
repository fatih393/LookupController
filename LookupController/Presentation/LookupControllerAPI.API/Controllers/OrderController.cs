using Lookupcontroller.Application.Services.EntityServices;
using Lookupcontroller.Application.Shared.Dtos.Order;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Application.Shared.Extensions;
using Lookupcontroller.Domain.Entities;
using LookupControllerAPI.API.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LookupControllerAPI.API.Controllers
{
    [Route("api/Lookup/[controller]")]
    [ApiController]
    public class OrderController : LookupControllerBase<Order, IOrderService, OrderResponseDto, OrderRequestDto>
    {
        private readonly ClaimExtension _claimExtension;

        public OrderController(IOrderService lookupService,
             ClaimExtension claimExtension) : base(lookupService)
        {
            _claimExtension = claimExtension;
        }
    }
}
