using ControlApp.Application.DataBase;
using ControlApp.Domain.Customer;

namespace ControlApp.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreateCustomerCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public int Execute(CreateCustomerModel model)
        {
            var CutomerEntity = new CustomerEntity
            {
                DocumentNumber = model.DocumentNumber,
                DocumentType = model.DocumentType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            return _databaseService.CreateCustomer(CutomerEntity);
        }
    }
}
