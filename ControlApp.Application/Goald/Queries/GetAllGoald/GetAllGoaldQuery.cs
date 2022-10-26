using ControlApp.Application.DataBase;
using ControlApp.Application.Product.Queries.GetAllProduct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Goald.Queries.GetAllGoald
{
    public class GetAllGoaldQuery : IGetAllGoaldQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetAllGoaldQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<GetAllGoaldModel>? Execute()
        {
            var list = _databaseService.GetAllGoald();
            if (list != null && list.Count > 0)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(list);
                return JsonConvert.DeserializeObject<List<GetAllGoaldModel>>(ObjectSerialize);
            }
            return null;
        }
    }
}
