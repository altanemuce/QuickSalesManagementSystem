using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Application.Repositories.Abstract.Product;

namespace QSMS.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CreateCategoryDto> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category mappedCategory = _mapper.Map<Domain.Entities.Category>(request);
            var res = await _categoryRepository.AddAsync(mappedCategory);
            if (!res)
            {
                throw new Exception("Eklemede Hata!!!");
            }
            await _categoryRepository.SaveAsync();
            return new();
        }
    }
}
