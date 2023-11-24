using QSMS.Application.Repositories.Abstract.Order;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.Order
{
    public class EfOrderRepository : EfEntityRepositoryBase<QSMS.Domain.Entities.Order>,IOrderRepository
    {
        public EfOrderRepository(QSMSDbContext dbContext) : base(dbContext)
        {

        }
    }
}
