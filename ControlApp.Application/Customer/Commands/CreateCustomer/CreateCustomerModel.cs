
namespace ControlApp.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerModel
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
