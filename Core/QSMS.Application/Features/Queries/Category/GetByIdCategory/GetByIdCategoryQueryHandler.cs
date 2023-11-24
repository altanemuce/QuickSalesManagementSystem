using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.Queries.Product.GetByIdProduct;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Application.Repositories.Abstract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<GetByIdCategoryDto> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category mappedCategory = _mapper.Map<Domain.Entities.Category>(request);
            Domain.Entities.Category getCategory = await _categoryRepository.GetByIdAsync(request.Id);
            GetByIdCategoryDto getByIdCategoryDto = _mapper.Map<GetByIdCategoryDto>(getCategory);
            return getByIdCategoryDto;

        }
    }
}
