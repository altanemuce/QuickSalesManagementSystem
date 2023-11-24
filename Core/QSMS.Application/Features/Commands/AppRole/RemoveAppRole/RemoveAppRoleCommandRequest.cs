using MediatR;
using QSMS.Application.Features.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.AppRole.RemoveAppRole
{
    public class RemoveAppRoleCommandRequest:IRequest<RemoveAppRoleDto>
    {
        public int Id { get; set; }
    }
}
