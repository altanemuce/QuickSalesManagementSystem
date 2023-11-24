using AutoMapper;
using MediatR;
using QSMS.Application.Features.Commands.Product.RemoveProduct;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Application.Repositories.Abstract.CategoryProduct;
using QSMS.Application.Repositories.Abstract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.Category.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public RemoveCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<RemoveCategoryDto> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = await _categoryRepository.GetSingleAsync(x => x.Id == request.Id);
            await _categoryRepository.RemoveAsync(category.Id);
            RemoveCategoryDto removeCategoryDto = _mapper.Map<RemoveCategoryDto>(category);
            await _categoryRepository.SaveAsync();
            return removeCategoryDto;
        }
    }
}
