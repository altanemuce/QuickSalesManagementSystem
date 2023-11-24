using QSMS.Application.Repositories.Abstract.Tag;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.Tag
{
    public class EfTagRepository:EfEntityRepositoryBase<QSMS.Domain.Entities.Tag>,ITagRepository
    {
        public EfTagRepository(QSMSDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
