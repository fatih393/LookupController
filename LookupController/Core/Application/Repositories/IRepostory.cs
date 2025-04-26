using Lookupcontroller.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Repostories
{
    public interface IRepostory<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
