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
        public List<GetUserByRoleModel>? Execute(string role)
        {
            var list = _databaseService.GetUserByRole(role);
            if (list != null)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(list);
                return JsonConvert.DeserializeObject<List<GetUserByRoleModel>>(ObjectSerialize);
            }
            return null;
        }
    }
}
