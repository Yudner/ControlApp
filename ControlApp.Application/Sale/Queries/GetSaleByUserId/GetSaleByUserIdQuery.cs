using ControlApp.Application.DataBase;
using ControlApp.Application.Goald.Queries.GetAllGoald;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Sale.Queries.GetSaleByUserId
{
    public class GetSaleByUserIdQuery : IGetSaleByUserIdQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetSaleByUserIdQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<GetSaleByUserIdModel>? Execute(int userId)
        {
            var listResult = new List<GetSaleByUserIdModel>();

            var listSale = _databaseService.GetAllSaleByUserId(userId);

            foreach (var item in listSale)
            {
                var model = new GetSaleByUserIdModel();
                var user = _databaseService.GetAllUser()?.FirstOrDefault(x => x.Id == item.UserId);
                var customer = _databaseService.GetAllCustomer()?.FirstOrDefault(x => x.Id == item.CustomerId);
                var product = _databaseService.GetAllProduct()?.FirstOrDefault(x => x.Id == item.ProductId);
                var period = _databaseService.GetAllPeriod()?.FirstOrDefault(x => x.Id == item.PeriodId);


                model.Id = item.Id;
                model.Points = item.Points;
                model.SaleDate = item.SaleDate;
                model.Amount = item.Amount;
                model.UserId = user.Id;

                model.CustomerId = item.CustomerId;
                model.CustomerName = customer.FirstName + " " + customer.LastName;
                model.DocumentNumber = customer.DocumentNumber;

                model.ProductId = item.ProductId;
                model.ProductName = product.ProductName;

                model.PeriodId = item.PeriodId;
                model.Year = period.Year;
                model.Month = period.Month;

                listResult.Add(model);
            }

            return listResult;
        }
    }
}
