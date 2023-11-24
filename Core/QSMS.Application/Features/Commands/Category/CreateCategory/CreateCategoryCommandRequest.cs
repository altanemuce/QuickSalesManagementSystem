using MediatR;
using QSMS.Application.Features.DTOs.Category;

namespace QSMS.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest:IRequest<CreateCategoryDto>
    {
        public string CategoryName { get; set; }
    }
}
