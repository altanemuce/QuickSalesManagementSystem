using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;

namespace QSMS.Domain.Entities
{
    public class Product : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
