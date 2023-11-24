using MediatR;
using QSMS.Application.Features.DTOs.Role;

namespace QSMS.Application.Features.Commands.AppRole.UpdateAppRole
{
    public class UpdateAppRoleCommandRequest : IRequest<UpdateRoleDto>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
