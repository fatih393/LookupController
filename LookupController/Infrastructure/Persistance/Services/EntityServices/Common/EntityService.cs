using Lookupcontroller.Application.Mapper;
using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.BusinessRules;
using Lookupcontroller.Application.Services.EntityServices.Common;
using Lookupcontroller.Application.Shared.Dtos.Commons;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Application.Shared.ResponseModel;
using Lookupcontroller.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.EntityServices.Common
{
    public class EntityService<TEntity, TRequestDto, TResponseDto>
     : IEntityService<TEntity, TRequestDto, TResponseDto>
     where TEntity : BaseEntity, new() where TResponseDto : BaseResponseDto, new()
    {
        private readonly IReadRepostory<TEntity> _readRepository;
        private readonly IWriteRepostory<TEntity> _writeRepository;
        private readonly IBusinessRulesService<TEntity> _businessRules;
        public EntityService(IReadRepostory<TEntity> readRepository, IWriteRepostory<TEntity> writeRepository, IBusinessRulesService<TEntity> businessRules)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _businessRules = businessRules;
        }

        public virtual async Task<IApiResponse<TResponseDto>> AddAsync(TRequestDto record)
        {
            try
            {
               
                var entity = ObjectMapper.Mapper.Map<TEntity>(record);
                await _businessRules.ValidateAsync(entity);
                var result = await _writeRepository.AddAsync(entity);

                if (!result)
                    return ApiResponse<TResponseDto>.CreateBadRequest(null, "Ekleme başarısız.");

                await _writeRepository.Saveasync();

                var mappedResult = ObjectMapper.Mapper.Map<TResponseDto>(entity);

                return ApiResponse<TResponseDto>.Create(mappedResult, StatusCode: StatusCodes.Status201Created.ToString());
            }
            catch (Exception ex)
            {
                return ApiResponse<TResponseDto>.Create(ex);
            }
        }

        public async Task<IApiResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _readRepository.Table.FindAsync(id);
            if (entity == null)
                return ApiResponse<bool>.CreateNotFound("Varlık bulunamadı.");

            var result = _writeRepository.Remove(entity);
          
            if (!result)
                return ApiResponse<bool>.CreateBadRequest(false, "Silme başarısız.");

            await _writeRepository.Saveasync();
            return ApiResponse<bool>.CreateOk(true);
        }

        public async Task<IApiResponse<TResponseDto>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _readRepository.Table.Where(filter).FirstOrDefaultAsync();

            if (entity == null)
                return ApiResponse<TResponseDto>.CreateNotFound("Varlık bulunamadı.");

            var dto = ObjectMapper.Mapper.Map<TResponseDto>(entity);
            return ApiResponse<TResponseDto>.CreateOk(dto);
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

        public async Task<IApiResponse<bool>> UpdateAsync(int id, TRequestDto record)
        {
            var entity = await _readRepository.Table.FindAsync(id);

            if (entity == null)
                return ApiResponse<bool>.CreateBadRequest(false, "Varlık bulunamadı.");

            ObjectMapper.Mapper.Map(record, entity);

            var result = await _writeRepository.Saveasync(); 

            return result > 0
             ? ApiResponse<bool>.CreateOk(true)
             : ApiResponse<bool>.CreateBadRequest(false);

        }

        public async Task<IApiResponse<List<TResponseDto>>> Pagination(ProductPaginationRequestDto dto)
        {
            var totalCount = _readRepository.GetAll(false).Count();
            var entities = _readRepository.GetAll(false).Skip(dto.Page * dto.Size).Take(dto.Size).ToList();
            if (entities == null || entities.Count == 0)
                return ApiResponse<List<TResponseDto>>.CreateNotFound("Entity not found");

            var mappedEntities = ObjectMapper.Mapper.Map<List<TResponseDto>>(entities);
            return ApiResponse<List<TResponseDto>>.Create(mappedEntities);

        }
    }
}
