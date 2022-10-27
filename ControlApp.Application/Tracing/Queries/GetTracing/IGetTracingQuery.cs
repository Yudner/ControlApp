using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Tracing.Queries.GetTracing
{
    public interface IGetTracingQuery
    {
        GetTracingModel? Execute(int userId, int periodId);
    }
}
