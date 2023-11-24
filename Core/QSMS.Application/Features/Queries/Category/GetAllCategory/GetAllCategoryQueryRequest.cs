using MediatR;
using QSMS.Application.Features.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<GetListCategoryDto>
    {
    }
}
