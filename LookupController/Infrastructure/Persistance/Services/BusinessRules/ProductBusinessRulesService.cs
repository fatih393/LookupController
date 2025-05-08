using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.BusinessRules
{
    public class ProductBusinessRulesService
    : BusinessRulesServiceBase<Product>
    {
        public ProductBusinessRulesService(IProductReadRepository readRepo)
            : base(readRepo) { }

        public override async Task ValidateAsync(Product entity)
        {
            
            var exists = await ReadRepo.GetAll()
                                       .AnyAsync(p => p.Name == entity.Name);
            if (exists)
                throw new Exception("Bu isimde bir ürün zaten mevcut.");
        }
    }
}
