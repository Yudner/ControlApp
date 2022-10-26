using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Goald.Commands.CreateGoald
{
    public class CreateGoaldModel
    {
        public double Points { get; set; }
        public int PeriodId { get; set; }
        public int UserId { get; set; }
    }
}
