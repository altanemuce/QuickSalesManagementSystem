using QSMS.Application.Repositories.Abstract.ProductTag;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.ProductTag
{
    public class EfProductTagRepository : EfEntityRepositoryBase<Domain.Entities.ProductTag>, IProductTagRepository
    {
        public EfProductTagRepository(QSMSDbContext dbContext) : base(dbContext)
        {

        }
    }
}
