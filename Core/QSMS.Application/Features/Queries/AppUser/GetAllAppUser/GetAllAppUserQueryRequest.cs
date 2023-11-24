using MediatR;
using QSMS.Application.Features.DTOs.User;

namespace QSMS.Application.Features.Queries.AppUser.GetAllAppUser
{
    public class GetAllAppUserQueryRequest : IRequest<GetListAppUserDto>
    {
    }
}
