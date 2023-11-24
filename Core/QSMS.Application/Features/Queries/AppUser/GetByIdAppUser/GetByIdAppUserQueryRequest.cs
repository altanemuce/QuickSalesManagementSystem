using MediatR;
using QSMS.Application.Features.DTOs.User;

namespace QSMS.Application.Features.Queries.AppUser.GetByIdAppUser
{
    public class GetByIdAppUserQueryRequest : IRequest<GetByIdAppUserDto>
    {
        public int Id { get; set; }
    }
}
