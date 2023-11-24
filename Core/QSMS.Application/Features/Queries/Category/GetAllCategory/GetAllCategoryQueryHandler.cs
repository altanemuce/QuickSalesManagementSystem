using MediatR;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Repositories.Abstract.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetListCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<GetListCategoryDto> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _categoryRepository.GetAll (false).ToList();
            return new()
            {
                Categories = result
            };
        }
    }
}
