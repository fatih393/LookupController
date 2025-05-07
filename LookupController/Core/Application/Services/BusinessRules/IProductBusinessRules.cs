using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Services.BusinessRules
{
    public interface IProductBusinessRules
    {
        Task Validate(ProductRequestDto productDto);
    }
}
