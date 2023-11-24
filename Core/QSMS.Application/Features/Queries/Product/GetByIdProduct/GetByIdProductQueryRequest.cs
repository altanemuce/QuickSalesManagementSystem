using MediatR;
using Microsoft.AspNetCore.Http;
using QSMS.Application.Features.DTOs.Product;

namespace QSMS.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductDto>
    {
        public int Id { get; set; }

    }
}
