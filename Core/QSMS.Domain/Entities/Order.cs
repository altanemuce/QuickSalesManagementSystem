using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Domain.Entities
{
    public class Order:BaseEntity,IEntity
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
