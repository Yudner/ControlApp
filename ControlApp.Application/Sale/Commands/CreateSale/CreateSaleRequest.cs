using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Sale.Commands.CreateSale
{
    public class CreateSaleRequest
    {
        public double Points { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductId { get; set; }
        public int PeriodId { get; set; }
    }
}
