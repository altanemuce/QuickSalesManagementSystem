using QSMS.Application.Repositories.Abstract.Customer;
using QSMS.Persistence.Contexts;

namespace QSMS.Persistence.Repositories.Customer
{
    public class EfCustomerRepository:EfEntityRepositoryBase<QSMS.Domain.Entities.Customer>,ICustomerRepository
    {
        public EfCustomerRepository(QSMSDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
