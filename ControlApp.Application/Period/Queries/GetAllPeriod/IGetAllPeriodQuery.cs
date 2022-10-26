using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Period.Queries.GetAllPeriod
{
    public interface IGetAllPeriodQuery
    {
        List<GetAllPeriodModel>? Execute();
    }
}
