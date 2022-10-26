using ControlApp.Application.Goald.Commands.CreateGoald;
using ControlApp.Application.Goald.Queries.GetAllGoald;
using Microsoft.AspNetCore.Mvc;

namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/goald")]
    public class GoaldController : ControllerBase
    {
        private readonly ICreateGoaldCommand _createGoaldCommand;
        private readonly IGetAllGoaldQuery _getAllGoaldQuery;

        public GoaldController(ICreateGoaldCommand createGoaldCommand, IGetAllGoaldQuery getAllGoaldQuery)
        {
            _createGoaldCommand = createGoaldCommand;
            _getAllGoaldQuery = getAllGoaldQuery;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateGoaldModel model)
        {
            try
            {
                if (model == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "Parámetros no válidos");

                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, "Parámetros no válidos");

                var result = _createGoaldCommand.Execute(model);

                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest);

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _getAllGoaldQuery.Execute();

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
