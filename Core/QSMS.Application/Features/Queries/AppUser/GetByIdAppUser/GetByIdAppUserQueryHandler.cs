using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Queries.AppUser.GetByIdAppUser
{
    public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQueryRequest, GetByIdAppUserDto>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly IMapper _mapper;
        public GetByIdAppUserQueryHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<GetByIdAppUserDto> Handle(GetByIdAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser mappedUser = _mapper.Map<Domain.Entities.Identity.AppUser>(request);
            Domain.Entities.Identity.AppUser getUser = await _userManager.FindByIdAsync(request.Id.ToString());
            GetByIdAppUserDto getByIdAppUserDto = _mapper.Map<GetByIdAppUserDto>(getUser);
            return getByIdAppUserDto;

        }
    }
}
