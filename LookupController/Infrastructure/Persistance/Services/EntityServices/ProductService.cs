using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.BusinessRules;
using Lookupcontroller.Application.Services.EntityServices;
using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Application.Shared.ResponseModel;
using Lookupcontroller.Domain.Entities;
using Lookupcontroller.Persistance.Services.EntityServices.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.EntityServices
{
    public class ProductService : EntityService<Product, ProductRequestDto, ProductResponseDto>, IProductService
    {
        public ProductService(
            IProductReadRepository readRepository,
            IProductWriteRepository writeRepository,
            IBusinessRulesService<Product> businessRules)
            : base(readRepository, writeRepository, businessRules)
        {
        }
    }
}
