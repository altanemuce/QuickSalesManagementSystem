using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Application.Features.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Queries.AppRole.GetByIdAppRole
{
    public class GetByIdAppRoleQueryHandler : IRequestHandler<GetByIdAppRoleQueryRequest, GetByIdAppRoleDto>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
        public GetByIdAppRoleQueryHandler(IMapper mapper, RoleManager<Domain.Entities.Identity.AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<GetByIdAppRoleDto> Handle(GetByIdAppRoleQueryRequest request, CancellationToken cancellationToken)
        {
            
            Domain.Entities.Identity.AppRole getRole = await _roleManager.FindByIdAsync(request.Id.ToString());
            
            return new()
            {
                Id = getRole.Id,
                RoleName = getRole.Name,
            };
        }
    }
}
