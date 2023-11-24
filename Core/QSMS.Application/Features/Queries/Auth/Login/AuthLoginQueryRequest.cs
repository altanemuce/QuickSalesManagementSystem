using MediatR;
using QSMS.Application.Features.DTOs.Auth;

namespace QSMS.Application.Features.Queries.Auth.Login
{
    public class AuthLoginQueryRequest:IRequest<LoginUserDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
