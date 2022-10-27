
namespace ControlApp.Application.Customer.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        int Execute(CreateCustomerModel model);
    }
}
