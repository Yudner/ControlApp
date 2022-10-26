using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.User.Queries.GetUserByRole
{
    public interface IGetUserByRoleQuery
    {
        GetUserByRoleModel? Execute(string role);
    }
}
