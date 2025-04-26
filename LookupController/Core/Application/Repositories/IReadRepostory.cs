using Lookupcontroller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Repostories
{
    public interface IReadRepostory<T> : IRepostory<T> where T : BaseEntity
    {
        
        IQueryable<T> GetAll(bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
    }
}
