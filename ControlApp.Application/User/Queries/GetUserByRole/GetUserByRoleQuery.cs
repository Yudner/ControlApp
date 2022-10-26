using ControlApp.Application.DataBase;
using ControlApp.Application.User.Queries.GetUserByCode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.User.Queries.GetUserByRole
{  
    public class GetUserByRoleQuery : IGetUserByRoleQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetUserByRoleQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public GetUserByRoleModel? Execute(string role)
        {
            var user = _databaseService.GetUserByRole(role);
            if (user != null)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(user);
                return JsonConvert.DeserializeObject<GetUserByRoleModel>(ObjectSerialize);
            }
            return null;
        }
    }
}
