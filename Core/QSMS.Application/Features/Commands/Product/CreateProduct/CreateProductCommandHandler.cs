using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Repositories.Abstract.CategoryProduct;
using QSMS.Application.Repositories.Abstract.Product;
using QSMS.Application.Repositories.Abstract.ProductImage;
using QSMS.Application.Repositories.Abstract.ProductTag;
using QSMS.Domain.Entities;

namespace QSMS.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IProductImageRepository productImageRepository, IMapper mapper, ICategoryProductRepository categoryProductRepository, IProductTagRepository productTagRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _categoryProductRepository = categoryProductRepository;
            _productTagRepository = productTagRepository;
        }
        public async Task<CreateProductDto> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Product product = new Domain.Entities.Product()
            {
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };

            var res = await _productRepository.AddAsync(product);
            if (!res)
            {
                throw new Exception("Eklemede Hata!!!");
            }
            await _productRepository.SaveAsync();
            if (request.Tags != null)
            {
                var model = request.Tags.Select(tag => new Domain.Entities.ProductTag
                {
                    TagsId = tag,
                    ProductsId = product.Id
                }).ToList();
                await _productTagRepository.AddRangeAsync(model);
                await _productTagRepository.SaveAsync();
            }
            if (request.Categories != null)
            {
                var model = request.Categories.Select(category => new Domain.Entities.CategoryProduct
                {
                    CategoriesId = category,
                    ProductsId = product.Id
                }).ToList();
                await _categoryProductRepository.AddRangeAsync(model);
                await _categoryProductRepository.SaveAsync();
            }
            return new();
        }
    }
}
