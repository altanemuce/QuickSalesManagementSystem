using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Domain.Entities.Identity;

namespace QSMS.Application.Features.Commands.AppRole.CreateAppRole
{
    public class CreateAppRoleCommandHandler : IRequestHandler<CreateAppRoleCommandRequest, CreateRoleDto>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
        public CreateAppRoleCommandHandler(IMapper mapper, RoleManager<Domain.Entities.Identity.AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<CreateRoleDto> Handle(CreateAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            

            await _roleManager.CreateAsync(new Domain.Entities.Identity.AppRole { Name=request.RoleName});
           
            return new();
        }
    }
}
