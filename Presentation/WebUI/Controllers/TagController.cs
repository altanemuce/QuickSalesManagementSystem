using MediatR;
using Microsoft.AspNetCore.Mvc;
using QSMS.Application.Features.Commands.Category.CreateCategory;
using QSMS.Application.Features.Commands.Tag.CreateTag;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.Tag;

namespace WebUI.Controllers
{
    public class TagController : Controller
    {
        private readonly IMediator _mediator;
        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTagCommandRequest createTagCommandRequest)
        {
            CreateTagDto createTagDto = await _mediator.Send(createTagCommandRequest);
            return View(createTagDto);
        }
    }
}
