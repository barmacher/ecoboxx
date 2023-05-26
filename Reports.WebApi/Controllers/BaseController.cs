using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Applications.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal int UserId => !User.Identity.IsAuthenticated
            ? default(int)
            : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        internal int BrigadeId => !User.Identity.IsAuthenticated
           ? default(int)
           : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    }
}
