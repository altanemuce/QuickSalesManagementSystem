using Microsoft.EntityFrameworkCore;
using QSMS.Domain.Entities.Common;

namespace QSMS.Application.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
