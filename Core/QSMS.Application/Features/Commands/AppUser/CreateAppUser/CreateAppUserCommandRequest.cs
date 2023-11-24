using MediatR;
using QSMS.Application.Features.DTOs.User;

namespace QSMS.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandRequest:IRequest<CreateUserDto>
    {
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
