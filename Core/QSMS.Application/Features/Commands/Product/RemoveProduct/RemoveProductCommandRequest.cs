using MediatR;
using QSMS.Application.Features.DTOs.Product;

namespace QSMS.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandRequest:IRequest<RemoveProductDto>
    {
        public int Id { get; set; }
    }
}
