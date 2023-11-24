using Microsoft.EntityFrameworkCore;
using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QSMS.Domain.Entities
{
    public class CategoryProduct:BaseEntity,IEntity
    { 
        public int CategoriesId { get; set; }
        public int ProductsId { get; set; }
    }
}
