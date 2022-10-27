using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Tracing.Queries.GetTracing
{
    public class GetTracingModel
    {
        public int UserId { get; set; }
        public int PeriodId { get; set; }
        public double Goald { get; set; }
        public double Point { get; set; }
        public List<Sale> Sales { get; set; }
    }
    public class Sale
    {
        public int Id { get; set; }
        public double Points { get; set; }
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime SaleDate { get; set; }
        
    }
}