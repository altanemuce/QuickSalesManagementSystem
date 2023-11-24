using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Domain.Entities
{
    public class Customer : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
