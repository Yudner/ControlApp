using ControlApp.Application.User.Queries.GetAllUser;
using Microsoft.AspNetCore.Mvc;


namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUserQuery _getAllUserQuery;

        public UserController(IGetAllUserQuery getAllUserQuery)
        {
            _getAllUserQuery = getAllUserQuery;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _getAllUserQuery.Execute();

                if (list == null)
                    return StatusCode(StatusCodes.Status204NoContent);

                return StatusCode(StatusCodes.Status200OK, list);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
