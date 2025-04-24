using Lookupcontroller.Application.Mapper;
using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Commons;
using Lookupcontroller.Application.Shared.ResponseModel;
using Lookupcontroller.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.EntityServices.Common
{
    public class EntityService<TEntity, TResponseDto, TRequestDto>
     : IEntityService<TEntity, TRequestDto, TResponseDto>
     where TEntity : BaseEntity, new() where TResponseDto : BaseResponseDto, new()
    {
        private readonly IReadRepostory<TEntity> _readRepository;
        private readonly IWriteRepostory<TEntity> _writeRepository;
     
        public EntityService(IReadRepostory<TEntity> readRepository, IWriteRepostory<TEntity> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public Task<IApiResponse<TResponseDto>> AddAsync(TRequestDto record, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<TResponseDto>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IApiResponse<List<TResponseDto>>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _readRepository.GetAll();
            if (filter != null)
                query = query.Where(filter);

            var entities = await query.ToListAsync();

            if (entities == null || entities.Count == 0)
                return ApiResponse<List<TResponseDto>>.CreateNotFound("Entity not found");

            var mappedEntities = ObjectMapper.Mapper.Map<List<TResponseDto>>(entities);
            return ApiResponse<List<TResponseDto>>.Create(mappedEntities);

        }

        public Task<IApiResponse<bool>> UpdateAsync(Guid id, TRequestDto record)
        {
            throw new NotImplementedException();
        }
    }
}
