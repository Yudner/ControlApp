using ControlApp.Application.DataBase;
using ControlApp.Application.User.Queries.GetAllUser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Product.Queries.GetAllProduct
{
    public class GetAllProductQuery : IGetAllProductQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetAllProductQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<GetAllProductModel>? Execute()
        {
            var list = _databaseService.GetAllProduct();
            if (list != null && list.Count > 0)
            {
                var ObjectSerialize = JsonConvert.SerializeObject(list);
                return JsonConvert.DeserializeObject<List<GetAllProductModel>>(ObjectSerialize);
            }
            return null;
        }
    }
}
