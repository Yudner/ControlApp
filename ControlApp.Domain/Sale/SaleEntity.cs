
namespace ControlApp.Domain.Sale
{
    public class SaleEntity
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public double Points { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
