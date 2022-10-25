using ControlApp.Domain.CommercialAdvisor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.DataBase
{
    public interface IDatabaseService
    {
        List<CommercialAdvisorEntity> CommercialAdvisor();
    }
}
