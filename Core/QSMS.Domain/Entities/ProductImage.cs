using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Domain.Entities
{
    public class ProductImage : BaseEntity, IEntity
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
