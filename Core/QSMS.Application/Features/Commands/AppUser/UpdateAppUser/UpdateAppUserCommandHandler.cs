using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.AppUser.UpdateAppUser
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, UpdateUserDto>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateAppUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UpdateUserDto> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser mappedUser = _mapper.Map<Domain.Entities.Identity.AppUser>(request);
            var user = _userManager.FindByIdAsync(request.Id.ToString()).Result;
            if (user !=null) 
            {              
                await _userManager.UpdateAsync(mappedUser);
            }
            
            if (request.Roles != null)
            {
                await _userManager.AddToRolesAsync(mappedUser, request.Roles);
            }
            return new();
        }

    }
}
