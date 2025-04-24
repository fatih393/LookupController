using Lookupcontroller.Application.Services.EntityServices;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Application.Shared.Extensions;
using Lookupcontroller.Domain.Entities;
using Lookupcontroller.Persistance.Services.EntityServices;
using LookupControllerAPI.API.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LookupControllerAPI.API.Controllers
{
    [Route("api/Lookup/[controller]")]
    [ApiController]
    public class ProductController : LookupControllerBase<Product, IProductService, ProductRequestDto, ProductResponseDto>
    {
        private readonly ClaimExtension _claimExtension;

        public ProductController(IProductService lookupService,
            ClaimExtension claimExtension) : base(lookupService)
        {
            _claimExtension = claimExtension;
        }
        [HttpGet("getall-product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _lookupService.GetListAsync(); // Burada filtre kullanmak isterseniz ekleyebilirsiniz.
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response.Message);
        }
    }
}
