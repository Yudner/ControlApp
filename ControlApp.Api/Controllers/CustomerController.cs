using ControlApp.Application.Customer.Commands.CreateCustomer;
using ControlApp.Application.User.Queries.GetAllUser;
using Microsoft.AspNetCore.Mvc;

namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICreateCustomerCommand _createCustomerCommand;

        public CustomerController(ICreateCustomerCommand createCustomerCommand)
        {
            _createCustomerCommand = createCustomerCommand;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateCustomerModel model)
        {
            try
            {
                if (model == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "Parámetros no válidos");

                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, "Parámetros no válidos");

                var idCustomer = _createCustomerCommand.Execute(model);

                if (idCustomer == 0)
                    return StatusCode(StatusCodes.Status400BadRequest);

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
