using QSMS.Application.Repositories.Abstract.CategoryProduct;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.CategoryProduct
{
    public class EfCategoryProductRepository : EfEntityRepositoryBase<Domain.Entities.CategoryProduct>, ICategoryProductRepository
    {
        public EfCategoryProductRepository(QSMSDbContext dbContext) : base(dbContext)
        {

        }
    }
}
