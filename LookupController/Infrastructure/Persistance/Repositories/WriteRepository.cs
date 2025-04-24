using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Domain.Entities.Common;
using Lookupcontroller.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepostory<T> where T : BaseEntity
    {
        readonly LookupcontrollerContext _context;

        public WriteRepository(LookupcontrollerContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State != EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);
        }

        public async Task<int> Saveasync()
        => await _context.SaveChangesAsync();
    }
}
