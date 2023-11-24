using MediatR;
using QSMS.Application.Features.DTOs.User;

namespace QSMS.Application.Features.Commands.AppUser.UpdateAppUser
{
    public class UpdateAppUserCommandRequest : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
