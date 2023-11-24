using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QSMS.Application.Features.DTOs.Auth;
using QSMS.Application.Features.Queries.Auth.Login;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginQueryRequest authLoginQueryRequest)
        {
            LoginUserDto loginUserDto = await _mediator.Send(authLoginQueryRequest);
            return RedirectToAction("GetAll","Product");

        }
    }
}
