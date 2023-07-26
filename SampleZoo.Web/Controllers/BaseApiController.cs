using Microsoft.AspNetCore.Mvc;

namespace SampleZoo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase where T : class
    {
        protected IActionResult ReturnList(List<T> result)
        => Ok(result);

        protected IActionResult ReturnSingle(T? result)
        => result is null ? NotFound() : Ok(result);

        protected IActionResult ReturnCreatedResult()
        => NoContent();

        protected IActionResult ReturnUpdatedResult()
        => NoContent();

        protected IActionResult DeletedUpdatedResult()
        => NoContent();

        //the crud results are handled by a base class so in the future if we wanted to change the return result or add a message or return type
        //we can do it much easier
    }
}
