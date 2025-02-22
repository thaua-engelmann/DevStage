using DevStage.Api.UseCases.Users.Register;
using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using DevStage.Exception;
using Microsoft.AspNetCore.Mvc;

namespace DevStage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserJson request)
        {

            try
            {
                var useCase = new UseCaseRegisterUser();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch(DevStageException exception)
            {
                return BadRequest(new ResponseErrorMessagesJson
                {
                    Errors = exception.GetErrorMessages()
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson
                {
                    Errors = ["Internal Server Error."]
                });
            }

        }
    }
}
