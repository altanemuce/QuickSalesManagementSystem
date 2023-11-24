using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.Role;

namespace QSMS.Application.Features.Queries.AppRole.GetAllAppRole
{
    public class GetAllAppRoleQueryHandler : IRequestHandler<GetAllAppRoleQueryRequest, GetListAppRoleDto>
    {
        private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
        public GetAllAppRoleQueryHandler(RoleManager<Domain.Entities.Identity.AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<GetListAppRoleDto> Handle(GetAllAppRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _roleManager.Roles.ToList();
            return new()
            {
                AppRoles = result,
            };
        }
    }
}
