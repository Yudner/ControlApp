using ControlApp.Application.DataBase;
using ControlApp.Application.Product.Queries.GetAllProduct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var listResult = new List<GetAllGoaldModel>();

            var listGoald = _databaseService.GetAllGoald();

            foreach (var item in listGoald)
            {
                var model = new GetAllGoaldModel();
                var user = _databaseService.GetAllUser()?.FirstOrDefault(x=> x.Id == item.UserId);

                model.Id = item.Id;
                model.Points = item.Points;
                model.UserId = item.UserId;
                model.Name = user.Name;
                model.Role = user.Role;
                model.Code = user.Code;

                var period = _databaseService.GetAllPeriod()?.FirstOrDefault(x=> x.Id == item.PeriodId);

                model.PeriodId = item.PeriodId;
                model.Year = period.Year;
                model.Month = period.Month;

                listResult.Add(model);
            }

            return listResult;
        }
    }
}
