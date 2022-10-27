using ControlApp.Application.DataBase;
using ControlApp.Application.Sale.Queries.GetSaleByUserId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Tracing.Queries.GetTracing
{
    public class GetTracingQuery : IGetTracingQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetTracingQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public GetTracingModel? Execute(int userId, int periodId)
        {
            var result = new GetTracingModel();

            var getGoald = _databaseService.GetGoaldByUserIdPeriodId(userId, periodId);
            var getSales = _databaseService.GetAllSaleByUserIdByPeriodId(userId, periodId);

            if(getGoald != null && getSales != null)
            {
                result.Goald = getGoald.Points;
                result.Sales = new List<Sale>();

                foreach (var item in getSales)
                {
                    var customer = _databaseService.GetCustomerById(item.CustomerId);
                    var product = _databaseService.GetProductById(item.ProductId);

                    result.Point = result.Point + item.Points;

                    var sale = new Sale();
                    sale.Id = item.Id;
                    sale.Points = item.Points;
                    sale.Amount = item.Amount;
                    sale.CustomerName = customer?.FirstName + " " + customer?.LastName;
                    sale.DocumentNumber = customer?.DocumentNumber;
                    sale.SaleDate = item.SaleDate;
                    sale.ProductName = product?.ProductName;


                    result.Sales.Add(sale);
                }
            }

            

            return result;
        }
    }
}
