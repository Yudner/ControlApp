using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.User.Queries.GetUserByCode
{
    public interface IGetUserByCodeQuery
    {
        GetUserByCodeModel? Execute(string code);
    }
}
