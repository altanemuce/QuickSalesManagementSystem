using QSMS.Application.Repositories.Abstract.Product;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.Product
{
    public class EfProductRepository : EfEntityRepositoryBase<QSMS.Domain.Entities.Product>,IProductRepository
    {
        public EfProductRepository(QSMSDbContext dbContext) : base(dbContext)
        {

        }
    }
}
