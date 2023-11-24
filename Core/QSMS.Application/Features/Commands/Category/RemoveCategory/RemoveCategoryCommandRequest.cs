using MediatR;
using QSMS.Application.Features.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.Category.RemoveCategory
{
    public class RemoveCategoryCommandRequest:IRequest<RemoveCategoryDto>
    {
        public int Id { get; set; }
    }
}
