using Lookupcontroller.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Commons;
namespace LookupControllerAPI.API.Controllers.Common
{
 
    public class LookupControllerBase<TEntity, TEntityService, TResponseDto, TRequestDto> : ControllerBase
          where TEntity : BaseEntity, new()
         where TEntityService : IEntityService<TEntity, TResponseDto, TRequestDto>
         where TResponseDto : BaseResponseDto, new()
    {
        protected readonly TEntityService _lookupService;

        public LookupControllerBase(TEntityService lookupService)
        {
            _lookupService = lookupService;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("getall")]
        public virtual async Task<IActionResult> GetAll()
        {
            var response = await _lookupService.GetListAsync();
            return response is null || response.Data is null || response.Data.Count <= 0 ? NoContent() : Ok(response);
        }
    }
}
