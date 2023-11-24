using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Repositories.Abstract.Product;

namespace QSMS.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetListProductDto>
    {
       
        private readonly IProductRepository _productRepository;
        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
          
        }
        public async Task<GetListProductDto> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _productRepository.GetAll(false).ToList();

            return new()
            {
                Products = result,
            };
        }
    }
}
