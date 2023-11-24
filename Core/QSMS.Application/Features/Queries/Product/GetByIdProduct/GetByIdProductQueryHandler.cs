using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Repositories.Abstract.Product;

namespace QSMS.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetByIdProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<GetByIdProductDto> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product mappedProduct = _mapper.Map<Domain.Entities.Product>(request);
            Domain.Entities.Product getProduct = await _productRepository.GetByIdAsync(request.Id);
            GetByIdProductDto getByIdProductDto = _mapper.Map<GetByIdProductDto>(getProduct);
            return getByIdProductDto;

        }
    }
}
