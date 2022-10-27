

namespace ControlApp.Application.Sale.Queries.GetSaleByUserId
{
    public class GetSaleByUserIdModel
    {
        public int Id { get; set; }
        public double Points { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Amount { get; set; }

        public int UserId { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string DocumentNumber { get; set; }


        public int ProductId { get; set; }
        public string ProductName { get; set; }


        public int PeriodId { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
    }
}
