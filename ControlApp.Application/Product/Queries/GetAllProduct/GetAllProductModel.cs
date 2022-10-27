using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Product.Queries.GetAllProduct
{
    public class GetAllProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Points { get; set; }
        public double Percentage { get; set; }
    }
}
