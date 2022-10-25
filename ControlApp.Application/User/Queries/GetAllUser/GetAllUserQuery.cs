using ControlApp.Application.DataBase;
using Newtonsoft.Json;

namespace ControlApp.Application.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IGetAllUserQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetAllUserQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<GetAllUserModel>? Execute()
        {
            var list = _databaseService.User();
            if (list != null && list.Count > 0)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(list);
                return JsonConvert.DeserializeObject<List<GetAllUserModel>>(ObjectSerialize);
            }
            return null;
        }
    }
}
