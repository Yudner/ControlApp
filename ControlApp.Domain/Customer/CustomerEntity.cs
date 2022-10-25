using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Domain.Customer
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
