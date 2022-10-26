using ControlApp.Application.Period.Queries.GetAllPeriod;
using ControlApp.Application.Product.Queries.GetAllProduct;
using Microsoft.AspNetCore.Mvc;

namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/product")]

    public class PeriodController : ControllerBase
    {
        private readonly IGetAllPeriodQuery _getAllPeriodQuery;

        public PeriodController(IGetAllPeriodQuery getAllPeriodQuery)
        {
            _getAllPeriodQuery = getAllPeriodQuery;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _getAllPeriodQuery.Execute();

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
