using Lookupcontroller.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Commons;
namespace LookupControllerAPI.API.Controllers.Common
{
 
    public class LookupControllerBase<TEntity, TEntityService, TResponseDto, TRequestDto> : ControllerBase
          where TEntity : BaseEntity, new()
         where TEntityService : IEntityService<TEntity, TRequestDto, TResponseDto>
         where TResponseDto : BaseResponseDto, new()
    {
        protected readonly TEntityService _lookupService;

        public LookupControllerBase(TEntityService lookupService)
        {
            _lookupService = lookupService;
        }
      
        [HttpGet("getall")]
        public virtual async Task<IActionResult> GetAll()
        {
                var response = await _lookupService.GetListAsync();
                return response is null || response.Data is null || response.Data.Count <= 0 ? NoContent() : Ok(response);
          
        }
      
        [HttpPost("create")]
        public virtual async Task<IActionResult> Create([FromBody] TRequestDto record)
        {
            var response = await _lookupService.AddAsync(record);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("getbyid/{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _lookupService.GetAsync(x => x.Id == id);
            return response is null || !response.Success || response.Data is null ? NoContent() : Ok(response);
        }
        [HttpPut("update/{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] TRequestDto record)
        {
            var response = await _lookupService.UpdateAsync(id, record);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }
    }
}
