using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Services.BusinessRules
{
    public interface IBusinessRulesService<TEntity>
    where TEntity : BaseEntity
    {
        Task ValidateAsync(TEntity entity);
    }

}
