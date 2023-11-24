using Microsoft.AspNetCore.Http;
using QSMS.Domain.Entities;

namespace QSMS.Application.Features.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageName { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Tags { get; set; }
        public List<IFormFile> ImageFile { get; set; }
    }
}
