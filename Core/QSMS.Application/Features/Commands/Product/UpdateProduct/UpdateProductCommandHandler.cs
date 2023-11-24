using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Repositories.Abstract.CategoryProduct;
using QSMS.Application.Repositories.Abstract.Product;
using QSMS.Application.Repositories.Abstract.ProductTag;
using QSMS.Domain.Entities;

namespace QSMS.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryProductRepository categoryProductRepository, IProductTagRepository productTagRepository)
        {
            _productRepository = productRepository;
            _categoryProductRepository = categoryProductRepository;
            _productTagRepository = productTagRepository;
        }
        public async Task<UpdateProductDto> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var getProduct = await _productRepository.GetByIdAsync(request.Id);
            if (getProduct != null)
            {
                getProduct.Stock = request.Stock;
                getProduct.Price = request.Price;
                getProduct.Description = request.Description;
                getProduct.Name = request.Name;
                _productRepository.Update(getProduct);
            }
            if (request.Tags != null)
            {
                var find = _productTagRepository.GetWhere(x => x.ProductsId == getProduct.Id).ToList();
                _productTagRepository.RemoveRange(find);
                var model = request.Tags.Select(tag => new Domain.Entities.ProductTag
                {
                    TagsId = tag,
                    ProductsId = getProduct.Id
                }).ToList();
                await _productTagRepository.AddRangeAsync(model);
                await _productTagRepository.SaveAsync();
            }
            if (request.Categories != null)
            {
                var find = _categoryProductRepository.GetWhere(x => x.ProductsId == getProduct.Id).ToList();
                _categoryProductRepository.RemoveRange(find);
                var model = request.Categories.Select(category => new Domain.Entities.CategoryProduct
                {
                    CategoriesId = category,
                    ProductsId = getProduct.Id
                }).ToList();
                await _categoryProductRepository.AddRangeAsync(model);
                await _categoryProductRepository.SaveAsync();
            }
            _productRepository.SaveAsync();
            return new();
        }
    }
}
