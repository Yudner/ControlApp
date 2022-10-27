using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Sale.Commands.CreateSale
{
    public class CreateSaleModel
    {
        public double Points { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int PeriodId { get; set; }
    }
}