using MediatR;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Application.Features.DTOs.User;

namespace QSMS.Application.Features.Queries.AppRole.GetByIdAppRole
{
    public class GetByIdAppRoleQueryRequest:IRequest<GetByIdAppRoleDto>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
