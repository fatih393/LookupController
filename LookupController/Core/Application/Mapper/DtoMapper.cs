using AutoMapper;
using Lookupcontroller.Application.Shared.Dtos.Order;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Mapper
{
    public class DtoMapper : Profile
    {
        protected internal DtoMapper() : base()
        {

            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductRequestDto, Product>();
            
            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderRequestDto, Order>();
        }

    }
}
