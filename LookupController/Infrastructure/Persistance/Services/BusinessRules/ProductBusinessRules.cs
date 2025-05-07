using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.BusinessRules;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.BusinessRules
{
    public class ProductBusinessRules : IProductBusinessRules
    {
        private readonly IProductReadRepository _readRepository;

        public ProductBusinessRules(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task Validate(ProductRequestDto productDto)
        {
            await CheckIfProductNameExists(productDto.Name);
        }
        private async Task CheckIfProductNameExists(string name)
        {
            var exists = await _readRepository.GetAll()
                .AnyAsync(p => p.Name == name);

            if (exists)
                throw new Exception("Bu isimde bir ürün zaten mevcut.");
        }
    }
}
