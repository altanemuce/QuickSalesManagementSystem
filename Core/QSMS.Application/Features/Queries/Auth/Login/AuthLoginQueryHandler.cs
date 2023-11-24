using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.Auth;
using QSMS.Domain.Entities.Identity;

namespace QSMS.Application.Features.Queries.Auth.Login
{
    public class AuthLoginQueryHandler : IRequestHandler<AuthLoginQueryRequest, LoginUserDto>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        private readonly IMapper _mapper;
        public AuthLoginQueryHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IMapper mapper, SignInManager<Domain.Entities.Identity.AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public async Task<LoginUserDto> Handle(AuthLoginQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser mappedUser = _mapper.Map<Domain.Entities.Identity.AppUser>(request);
            var result = await _userManager.FindByNameAsync(mappedUser.UserName);
            if (result == null)
                result = await _userManager.FindByEmailAsync(mappedUser.Email);
            if (result == null)
                throw new Exception("Hata");

            await _signInManager.PasswordSignInAsync(result, request.Password, false, true);
            return new();
        }
    }
}
