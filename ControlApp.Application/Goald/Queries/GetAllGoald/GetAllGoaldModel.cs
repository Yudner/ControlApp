using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Goald.Queries.GetAllGoald
{
    public class GetAllGoaldModel
    {
        public int Id { get; set; }
        public double Points { get; set; }
        public int PeriodId { get; set; }
        public int UserId { get; set; }
    }
}
