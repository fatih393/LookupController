using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Domain.Entities;
using Lookupcontroller.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(LookupcontrollerContext context) : base(context)
        {
        }
    }
}
