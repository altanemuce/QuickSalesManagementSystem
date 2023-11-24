using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QSMS.Application.Features.Commands.Category.CreateCategory;
using QSMS.Application.Features.Commands.Category.RemoveCategory;
using QSMS.Application.Features.Commands.Category.UpdateCategory;
using QSMS.Application.Features.Commands.Product.RemoveProduct;
using QSMS.Application.Features.Commands.Product.UpdateProduct;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.Queries.Category.GetAllCategory;
using QSMS.Application.Features.Queries.Category.GetByIdCategory;
using QSMS.Application.Features.Queries.Product.GetAllProduct;
using QSMS.Application.Features.Queries.Product.GetByIdProduct;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryDto createCategoryDto = await _mediator.Send(createCategoryCommandRequest);
            return View(createCategoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetListCategoryDto getListCategoryDto = await _mediator.Send(getAllCategoryQueryRequest);
            return View(getListCategoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            RemoveCategoryDto removeCategoryDto = await _mediator.Send(removeCategoryCommandRequest);
            return RedirectToAction("GetAll", "Category");
        }

        [HttpGet("/category-update/{id}")]
        public async Task<IActionResult> Update(GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {

            GetByIdCategoryDto getByIdCategoryDto = await _mediator.Send(getByIdCategoryQueryRequest);
            return View(getByIdCategoryDto);
        }

        [HttpPost("/category-update/{id}")]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryDto updateCategoryDto = await _mediator.Send(updateCategoryCommandRequest);
            return RedirectToAction("GetAll", "Category");
        }
    }
}
