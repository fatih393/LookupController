using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.BusinessRules;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.BusinessRules
{
    public abstract class BusinessRulesServiceBase<TEntity> : IBusinessRulesService<TEntity>
    where TEntity : BaseEntity
    {
        protected readonly IReadRepostory<TEntity> ReadRepo;

        protected BusinessRulesServiceBase(IReadRepostory<TEntity> readRepo)
        {
            ReadRepo = readRepo;
        }

        public abstract Task ValidateAsync(TEntity entity);
    }
}
