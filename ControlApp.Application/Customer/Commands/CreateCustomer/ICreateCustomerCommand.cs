
namespace ControlApp.Application.Customer.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        bool Execute(CreateCustomerModel model);
    }
}
