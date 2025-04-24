using Lookupcontroller.Application.Shared.ResponseModel;
using Lookupcontroller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Services.EntityServices.Common
{
    public interface IEntityService<TEntity, TRequestDto, TResponseDto>
    where TEntity : BaseEntity, new()

    {
        // GET - Tek kayıt getirme
        Task<IApiResponse<TResponseDto>> GetAsync(Expression<Func<TEntity, bool>> filter);

        // GET - Tüm kayıtları getirme
        Task<IApiResponse<List<TResponseDto>>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null);

        // POST - Yeni kayıt ekleme
        Task<IApiResponse<TResponseDto>> AddAsync(TRequestDto record, Guid userId);

        // PUT - Kayıt güncelleme
        Task<IApiResponse<bool>> UpdateAsync(Guid id, TRequestDto record);

        // DELETE - Kayıt silme
        Task<IApiResponse<bool>> DeleteAsync(Guid id);
    }
}
