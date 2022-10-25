using ControlApp.Application.Product.Queries.GetAllProduct;
using Microsoft.AspNetCore.Mvc;

namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
  
    public class ProductController : ControllerBase
    {
        private readonly IGetAllProductQuery _getAllProductQuery;

        public ProductController(IGetAllProductQuery getAllProductQuery)
        {
            _getAllProductQuery = getAllProductQuery;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _getAllProductQuery.Execute();

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
