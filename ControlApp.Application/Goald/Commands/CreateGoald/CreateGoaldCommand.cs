using ControlApp.Application.Customer.Commands.CreateCustomer;
using ControlApp.Application.DataBase;
using ControlApp.Domain.Customer;
using ControlApp.Domain.Goald;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Goald.Commands.CreateGoald
{
    public class CreateGoaldCommand : ICreateGoaldCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreateGoaldCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public bool Execute(CreateGoaldModel model)
        {
            var GoaldEntity = new GoaldEntity
            {
                Points = model.Points,
                PeriodId = model.PeriodId,
                UserId = model.UserId
            };

            return _databaseService.CreateGoald(GoaldEntity);
        }
    }
}
