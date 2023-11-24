using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Repositories.Abstract.Product;
using QSMS.Domain.Entities;

namespace QSMS.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public RemoveProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<RemoveProductDto> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _productRepository.GetSingleAsync(x => x.Id == request.Id);
            await _productRepository.RemoveAsync(product.Id);
            RemoveProductDto removeProductDto = _mapper.Map<RemoveProductDto>(product);
            await _productRepository.SaveAsync();
            return removeProductDto;
        }
    }
}
