using MediatR;
using QSMS.Application.Features.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.Tag.CreateTag
{
    public class CreateTagCommandRequest : IRequest<CreateTagDto>
    {
        public string TagName { get; set; }
    }
}
