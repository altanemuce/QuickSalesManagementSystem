using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.User;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Domain.Entities.Identity;

namespace QSMS.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateUserDto>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        private readonly IMapper _mapper;
        public CreateAppUserCommandHandler(SignInManager<Domain.Entities.Identity.AppUser> signInManager, UserManager<Domain.Entities.Identity.AppUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<CreateUserDto> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser mappedUser = _mapper.Map<Domain.Entities.Identity.AppUser>(request);
            IdentityResult result = await _userManager.CreateAsync(mappedUser, request.Password);
            if (request.Roles != null)
            {
                mappedUser.SecurityStamp = "bla bla";
                await _userManager.AddToRolesAsync(mappedUser, request.Roles);
            }
            return new();
        }
    }
}
