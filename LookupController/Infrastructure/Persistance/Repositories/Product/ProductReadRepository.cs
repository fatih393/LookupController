using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Domain.Entities;
using Lookupcontroller.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(LookupcontrollerContext context) : base(context)
        {
        }
    }
}
