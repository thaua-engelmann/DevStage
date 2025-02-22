using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DevStage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Create(RequestUserJson request)
        {
            return Created();
        }
    }
}
