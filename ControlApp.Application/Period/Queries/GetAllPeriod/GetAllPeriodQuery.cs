using ControlApp.Application.DataBase;
using ControlApp.Application.Product.Queries.GetAllProduct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Period.Queries.GetAllPeriod
{
    public class GetAllPeriodQuery : IGetAllPeriodQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetAllPeriodQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<GetAllPeriodModel>? Execute()
        {
            var list = _databaseService.GetAllPeriod();
            if (list != null && list.Count > 0)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(list);
                return JsonConvert.DeserializeObject<List<GetAllPeriodModel>>(ObjectSerialize);
            }
            return null;
        }
    }
}
