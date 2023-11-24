using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Domain.Entities.Identity;

namespace QSMS.Application.Features.Commands.AppRole.UpdateAppRole
{
    public class UpdateAppRoleCommandHandler : IRequestHandler<UpdateAppRoleCommandRequest, UpdateRoleDto>
    {
        private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
        private readonly IMapper _mapper;
        public UpdateAppRoleCommandHandler(RoleManager<Domain.Entities.Identity.AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<UpdateRoleDto> Handle(UpdateAppRoleCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Identity.AppRole appRole = new Domain.Entities.Identity.AppRole();
            var user = await _roleManager.Roles.FirstOrDefaultAsync(x=>x.Id==request.Id);

            if (user != null)
            {
                
                user.Name = request.RoleName;
                await _roleManager.UpdateAsync(user);
            }
            return new();
        }
    }
}
