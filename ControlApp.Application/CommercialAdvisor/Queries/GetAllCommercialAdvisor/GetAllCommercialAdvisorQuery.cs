using ControlApp.Application.DataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.CommercialAdvisor.Queries.GetAllCommercialAdvisor
{
    public class GetAllCommercialAdvisorQuery : IGetAllCommercialAdvisorQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetAllCommercialAdvisorQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<GetAllCommercialAdvisorModel>? Execute()
        {
            var list = _databaseService.CommercialAdvisor();
            if (list != null && list.Count > 0)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(list);
                return JsonConvert.DeserializeObject<List<GetAllCommercialAdvisorModel>>(ObjectSerialize);
            }
            return null;
        }
    }
}
