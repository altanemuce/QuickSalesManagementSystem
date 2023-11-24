using MediatR;
using Microsoft.AspNetCore.Mvc;
using QSMS.Application.Features.Commands.AppRole.CreateAppRole;
using QSMS.Application.Features.Commands.AppRole.RemoveAppRole;
using QSMS.Application.Features.Commands.AppRole.UpdateAppRole;
using QSMS.Application.Features.Commands.AppUser.UpdateAppUser;
using QSMS.Application.Features.Commands.Category.CreateCategory;
using QSMS.Application.Features.Commands.Product.RemoveProduct;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Application.Features.DTOs.User;
using QSMS.Application.Features.Queries.AppRole.GetAllAppRole;
using QSMS.Application.Features.Queries.AppRole.GetByIdAppRole;
using QSMS.Application.Features.Queries.AppUser.GetAllAppUser;
using QSMS.Application.Features.Queries.AppUser.GetByIdAppUser;

namespace WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateAppRoleCommandRequest createAppRoleCommandRequest)
        {
            CreateRoleDto createRoleDto = await _mediator.Send(createAppRoleCommandRequest);
            return View(createRoleDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllAppRoleQueryRequest getAllAppRoleQueryRequest)
        {
            GetListAppRoleDto getListAppRoleDto = await _mediator.Send(getAllAppRoleQueryRequest);
            return View(getListAppRoleDto);
        }

        [HttpGet("/role-update/{id}")]
        public async Task<IActionResult> Update(GetByIdAppRoleQueryRequest getByIdAppRoleQueryRequest)
        {
            GetByIdAppRoleDto getByIdAppRoleDto = await _mediator.Send(getByIdAppRoleQueryRequest);
            return View(getByIdAppRoleDto);
        }

        [HttpPost("/role-update/{id}")]
        public async Task<IActionResult> Update(UpdateAppRoleCommandRequest updateAppRoleCommandRequest)
        {
            UpdateRoleDto updateRoleDto = await _mediator.Send(updateAppRoleCommandRequest);
            return RedirectToAction("GetAll","Role");
        }
        [HttpGet]
        public async Task<IActionResult> Remove(RemoveAppRoleCommandRequest removeAppRoleCommandRequest)
        {
            RemoveAppRoleDto removeAppRoleDto = await _mediator.Send(removeAppRoleCommandRequest);
            return RedirectToAction("GetAll", "User");
        }
    }
}
