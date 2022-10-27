using ControlApp.Application.Customer.Commands.CreateCustomer;
using ControlApp.Application.Goald.Commands.CreateGoald;
using ControlApp.Application.Sale.Commands.CreateSale;
using ControlApp.Application.Sale.Queries.GetSaleByUserId;
using ControlApp.Application.Tracing.Queries.GetTracing;
using Microsoft.AspNetCore.Mvc;

namespace ControlApp.Api.Controllers
{

    [ApiController]
    [Route("api/v1/sale")]
    public class SaleCotroller : ControllerBase
    {
        private readonly IGetSaleByUserIdQuery _getSaleByUserIdQuery;
        private readonly ICreateSaleCommand _createSaleCommand;
        private readonly ICreateCustomerCommand _createCustomerCommand;
        private readonly IGetTracingQuery _getTracingQuery;
        public SaleCotroller(IGetSaleByUserIdQuery getSaleByUserIdQuery,
            ICreateSaleCommand createSaleCommand,
            ICreateCustomerCommand createCustomerCommand,
            IGetTracingQuery getTracingQuery)
        {
            _getSaleByUserIdQuery = getSaleByUserIdQuery;
            _createSaleCommand = createSaleCommand;
            _createCustomerCommand = createCustomerCommand;
            _getTracingQuery = getTracingQuery;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateSaleRequest model)
        {
            try
            {
                if (model == null)
                    return StatusCode(StatusCodes.Status400BadRequest, 400);

                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, 400);


                var customerModel = new CreateCustomerModel
                {
                    DocumentNumber = model.DocumentNumber,
                    DocumentType = model.DocumentType,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                };

                var idCustomer = _createCustomerCommand.Execute(customerModel);

                var saleModel = new CreateSaleModel
                {
                    Amount = model.Amount,
                    Points = model.Points,
                    UserId = model.UserId,
                    PeriodId = model.PeriodId,
                    ProductId = model.ProductId,
                    CustomerId = idCustomer
                };

                var result = _createSaleCommand.Execute(saleModel);

                if (!result)
                    return StatusCode(StatusCodes.Status400BadRequest, 400);

                return StatusCode(StatusCodes.Status200OK, 200);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("getByUserId/{UserId}")]
        public IActionResult GetByUserId(int UserId)
        {
            try
            {
                var list = _getSaleByUserIdQuery.Execute(UserId);

                if (list == null)
                    return StatusCode(StatusCodes.Status204NoContent);

                return StatusCode(StatusCodes.Status200OK, list);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("getTracing/{UserId}/{PeriodId}")]
        public IActionResult GetTracing(int UserId, int PeriodId)
        {
            try
            {
                var list = _getTracingQuery.Execute(UserId, PeriodId);

                if (list == null)
                    return StatusCode(StatusCodes.Status204NoContent, new GetTracingModel());

                return StatusCode(StatusCodes.Status200OK, list);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
