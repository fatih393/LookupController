using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Services.EntityServices
{
    public interface IProductService : IEntityService<Product, ProductRequestDto, ProductResponseDto>
    {
     /*   Task<bool> AddProductAsync(string productName, int productStock);
        Task<List<Product>> GetProductAsync();
        Task<bool> RemoveProductAsync(int id);
        Task<bool> UpdateProductAsync(int id, string productName, int productStock);*/
    }
}
