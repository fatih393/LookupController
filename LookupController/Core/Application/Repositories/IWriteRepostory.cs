using Lookupcontroller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Repostories
{
    public interface IWriteRepostory<T> : IRepostory<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        bool Remove(T model);
        Task<bool> RemoveAsync(int id);
        Task<int> Saveasync();
    }
}
