using MediatR;
using Microsoft.AspNetCore.Http;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Domain.Entities;

namespace QSMS.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<CreateProductDto>
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
