using QSMS.Domain.Abstract;

namespace QSMS.Domain.Entities.Common
{
    public class BaseEntity
    {
        virtual public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
    }
}
