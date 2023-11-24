using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QSMS.Application.Features.Commands.AppUser.CreateAppUser;
using QSMS.Application.Features.Commands.AppUser.UpdateAppUser;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.DTOs.User;
using QSMS.Application.Features.Queries.AppUser.GetAllAppUser;
using QSMS.Application.Features.Queries.AppUser.GetByIdAppUser;
using QSMS.Application.Features.Queries.Product.GetAllProduct;
using QSMS.Domain.Entities.Identity;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMediator _mediator;
        public UserController(IMediator mediator, RoleManager<AppRole> roleManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var roles = (from role in _roleManager.Roles
                         select new SelectListItem()
                         {
                             Text = role.Name,
                             Value = role.Name
                         }).ToList();
            ViewBag.RoleList = roles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAppUserCommandRequest createAppUserCommandRequest)
        {
            CreateUserDto createUserDto = await _mediator.Send(createAppUserCommandRequest);
            return RedirectToAction("GetAll", "User");
        }

        [HttpGet("/user-update/{id}")]
        public async Task<IActionResult> Update(GetByIdAppUserQueryRequest getByIdAppUserQueryRequest)
        {
            var roles = (from role in _roleManager.Roles
                         select new SelectListItem()
                         {
                             Text = role.Name,
                             Value = role.Name
                         }).ToList();
            ViewBag.RoleList = roles;
            GetByIdAppUserDto getByIdAppUserDto = await _mediator.Send(getByIdAppUserQueryRequest);
            return View(getByIdAppUserDto);
        }

        [HttpPost("/user-update/{id}")]
        public async Task<IActionResult> Update(UpdateAppUserCommandRequest updateAppUserCommandRequest)
        {
            UpdateUserDto updateUserDto = await _mediator.Send(updateAppUserCommandRequest);
            return View(updateUserDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllAppUserQueryRequest getAllAppUserQueryRequest)
        {
            GetListAppUserDto getListAppUserDto = await _mediator.Send(getAllAppUserQueryRequest);
            return View(getListAppUserDto);
        }
    }
}
