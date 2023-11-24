using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Domain.Entities
{
    public class Tag:BaseEntity,IEntity
    {
        public string TagName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
