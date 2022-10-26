using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Goald.Queries.GetAllGoald
{
    public interface IGetAllGoaldQuery
    {
        List<GetAllGoaldModel>? Execute();
    }
}
