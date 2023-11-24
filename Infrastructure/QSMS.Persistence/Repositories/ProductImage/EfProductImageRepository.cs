using QSMS.Application.Repositories.Abstract.ProductImage;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.ProductImage
{
    public class EfProductImageRepository : EfEntityRepositoryBase<QSMS.Domain.Entities.ProductImage>,IProductImageRepository
    {
        public EfProductImageRepository(QSMSDbContext dbContext) : base(dbContext)
        {

        }
    }
}
