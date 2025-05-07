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
    public class ProductController : LookupControllerBase<Product, IProductService, ProductResponseDto, ProductRequestDto>
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
            var response = await _lookupService.GetListAsync(); 
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response.Message);
        }

        [HttpGet("getpagination-product")]
        public async Task<IActionResult> GetPaginationProduct([FromQuery] ProductPaginationRequestDto productPaginationRequestDto)
        {
            var response = await _lookupService.Pagination(productPaginationRequestDto);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response.Message);
        }







        [HttpPost("create-product")]
        public async Task<IActionResult> AddProducts([FromBody] ProductRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _lookupService.AddAsync(request);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response.Message);
        }
        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDto productRequest)
        {
           
            var response = await _lookupService.UpdateAsync(id, productRequest);

            if (response.Success)
            {
                return Ok(response.Data); 
            }

            return BadRequest(response.Message); 
        }
    }
}
