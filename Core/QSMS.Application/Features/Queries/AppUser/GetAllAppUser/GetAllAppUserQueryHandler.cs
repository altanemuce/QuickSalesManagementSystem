using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.User;

namespace QSMS.Application.Features.Queries.AppUser.GetAllAppUser
{
    public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQueryRequest, GetListAppUserDto>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        public GetAllAppUserQueryHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<GetListAppUserDto> Handle(GetAllAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _userManager.Users.ToList();
            return new()
            {
                AppUsers = result
            };
        }
    }
}
