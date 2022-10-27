using ControlApp.Application.DataBase;
using ControlApp.Application.Goald.Commands.CreateGoald;
using ControlApp.Domain.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Sale.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreateSaleCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public bool Execute(CreateSaleModel model)
        {
            var SaleEntity = new SaleEntity
            {
                Points = model.Points,
                PeriodId = model.PeriodId,
                UserId = model.UserId,
                CustomerId = model.CustomerId,
                Amount = model.Amount,
                ProductId = model.ProductId,
                SaleDate = DateTime.Now
            };

            return _databaseService.CreateSale(SaleEntity);
        }
    }
}
