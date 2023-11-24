using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QSMS.Application.Features.Commands.AppUser.UpdateAppUser;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.User;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Application.Repositories.Abstract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;

        }

        public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var getCategory = await _categoryRepository.GetByIdAsync(request.Id);
            if (getCategory != null)
            {
                getCategory.CategoryName = request.CategoryName;
                _categoryRepository.Update(getCategory);

            }
            await _categoryRepository.SaveAsync();
            return new();
        }
    }
}
