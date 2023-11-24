using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.Category
{
    public class EfCategoryRepository:EfEntityRepositoryBase<QSMS.Domain.Entities.Category>,ICategoryRepository
    {
        public EfCategoryRepository(QSMSDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
