using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.DTOs.User
{
    public class GetListAppUserDto
    {
        public List<Domain.Entities.Identity.AppUser> AppUsers { get; set; }
    }
}
