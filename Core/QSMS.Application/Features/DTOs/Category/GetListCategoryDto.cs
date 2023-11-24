using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.DTOs.Category
{
    public class GetListCategoryDto
    {
        public List<Domain.Entities.Category> Categories { get; set; }
    }
}
