using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QSMS.Application.Features.Commands.Product.CreateProduct;
using QSMS.Application.Features.Commands.Product.RemoveProduct;
using QSMS.Application.Features.Commands.Product.UpdateProduct;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.Queries.Product.GetAllProduct;
using QSMS.Application.Features.Queries.Product.GetByIdProduct;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Application.Repositories.Abstract.Tag;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        public ProductController(IMediator mediator, ICategoryRepository categoryRepository, ITagRepository tagRepository)
        {
            _mediator = mediator;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = (from category in _categoryRepository.GetAll(false)
                              select new SelectListItem()
                              {
                                  Text = category.CategoryName,
                                  Value = category.Id.ToString()
                              }).ToList();
            ViewBag.CategoryList = categories;

            var tags = (from tag in _tagRepository.GetAll(false)
                        select new SelectListItem()
                        {
                            Text = tag.TagName,
                            Value = tag.Id.ToString()
                        }).ToList();
            ViewBag.TagList = tags;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductDto createProductDto = await _mediator.Send(createProductCommandRequest);
            return View(createProductDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetListProductDto getListProductDto = await _mediator.Send(getAllProductQueryRequest);
            return View(getListProductDto);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductDto removeProductDto = await _mediator.Send(removeProductCommandRequest);
            return RedirectToAction("GetAll", "Product");
        }

        [HttpGet("/product-update/{id}")]
        public async Task<IActionResult> Update(GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            var categories = (from category in _categoryRepository.GetAll(false)
                              select new SelectListItem()
                              {
                                  Text = category.CategoryName,
                                  Value = category.Id.ToString()
                              }).ToList();
            ViewBag.CategoryList = categories;

            var tags = (from tag in _tagRepository.GetAll(false)
                        select new SelectListItem()
                        {
                            Text = tag.TagName,
                            Value = tag.Id.ToString()
                        }).ToList();
            ViewBag.TagList = tags;
            GetByIdProductDto getByIdProductDto = await _mediator.Send(getByIdProductQueryRequest);
            return View(getByIdProductDto);
        }

        [HttpPost("/product-update/{id}")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductDto updateProductDto = await _mediator.Send(updateProductCommandRequest);
            return RedirectToAction("GetAll", "Product");
        }
    }
}
