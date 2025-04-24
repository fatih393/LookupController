using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.EntityServices;
using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Application.Shared.ResponseModel;
using Lookupcontroller.Domain.Entities;
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
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _readRepository;
        readonly IProductWriteRepository _writeRepository;
     

        public ProductService(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public Task<IApiResponse<ProductResponseDto>> AddAsync(ProductRequestDto record, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<ProductResponseDto>> GetAsync(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IApiResponse<List<ProductResponseDto>>> GetListAsync(Expression<Func<Product, bool>>? filter = null)
        {
            try
            {
                var productsQuery = _readRepository.GetAll(false);

                if (filter != null)
                    productsQuery = productsQuery.Where(filter);

                var products = await productsQuery.ToListAsync();

                if (products == null || products.Count == 0)
                {
                    // Veritabanında eşleşen ürün yok
                    return ApiResponse<List<ProductResponseDto>>.CreateNotFound("Ürün bulunamadı.");
                }

                var productDtos = products.Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    stock = p.stock,
                }).ToList();

                // Başarılı durum
                return ApiResponse<List<ProductResponseDto>>.CreateOk(productDtos);
            }
            catch (Exception ex)
            {
                // Hata durumunda dön
                return ApiResponse<List<ProductResponseDto>>.Create(ex);
            }
        }

        public Task<IApiResponse<bool>> UpdateAsync(Guid id, ProductRequestDto record)
        {
            throw new NotImplementedException();
        }
    }
}
