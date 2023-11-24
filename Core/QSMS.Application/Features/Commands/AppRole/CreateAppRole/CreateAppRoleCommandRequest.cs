using MediatR;
using QSMS.Application.Features.DTOs.Role;

namespace QSMS.Application.Features.Commands.AppRole.CreateAppRole
{
    public class CreateAppRoleCommandRequest:IRequest<CreateRoleDto>
    {
        public string RoleName { get; set; }
    }
}
