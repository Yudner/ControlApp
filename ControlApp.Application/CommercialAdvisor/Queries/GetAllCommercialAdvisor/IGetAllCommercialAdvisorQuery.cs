using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.CommercialAdvisor.Queries.GetAllCommercialAdvisor
{
    public interface IGetAllCommercialAdvisorQuery
    {
        List<GetAllCommercialAdvisorModel>? Execute();
    }
}
