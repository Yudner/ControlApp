using ControlApp.Application.CommercialAdvisor.Queries.GetAllCommercialAdvisor;
using Microsoft.AspNetCore.Mvc;


namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/commercial-advisor")]
    public class CommercialAdvisorController : ControllerBase
    {
        private readonly IGetAllCommercialAdvisorQuery _getAllCommercialAdvisorQuery;

        public CommercialAdvisorController(IGetAllCommercialAdvisorQuery getAllCommercialAdvisorQuery)
        {
            _getAllCommercialAdvisorQuery = getAllCommercialAdvisorQuery;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _getAllCommercialAdvisorQuery.Execute();
                //CacheDependency
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
