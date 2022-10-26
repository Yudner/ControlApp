using ControlApp.Application.DataBase;
using ControlApp.Application.User.Queries.GetAllUser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.User.Queries.GetUserByCode
{
    public class GetUserByCodeQuery : IGetUserByCodeQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetUserByCodeQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public GetUserByCodeModel? Execute(string code)
        {
            var user = _databaseService.GetUserByCode(code);
            if (user != null)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(user);
                return JsonConvert.DeserializeObject<GetUserByCodeModel>(ObjectSerialize);
            }
            return null;
        }
    }
}
