using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Application.Repositories.Abstract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.AppRole.RemoveAppRole
{
    public class RemoveAppRoleCommandHandler : IRequestHandler<RemoveAppRoleCommandRequest, RemoveAppRoleDto>
    {
        private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
        private readonly IMapper _mapper;
        public RemoveAppRoleCommandHandler(IMapper mapper, RoleManager<Domain.Entities.Identity.AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<RemoveAppRoleDto> Handle(RemoveAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _roleManager.FindByIdAsync(request.Id.ToString());
            await _roleManager.DeleteAsync(res);
            RemoveAppRoleDto removeAppRoleDto = _mapper.Map<RemoveAppRoleDto>(res);
            return removeAppRoleDto;
        }
    }
}
