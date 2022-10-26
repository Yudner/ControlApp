using ControlApp.Application.DataBase;
using ControlApp.Domain.Customer;
using ControlApp.Domain.Goald;
using ControlApp.Domain.Period;
using ControlApp.Domain.Product;
using ControlApp.Domain.User;
using Newtonsoft.Json;

namespace ControlApp.Persistence.DataBase
{
    public class DatabaseService: IDatabaseService
    {
        private static string route = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"ControlApp.Persistence", "Files");

        #region User
        public List<UserEntity>? GetAllUser()
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserEntity>>(json);
            }
        }
        public UserEntity? GetUserByCode(string code)
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<UserEntity>>(json);
                
                if (list != null)
                    return list.FirstOrDefault(x => x.Code == code);

                return null;

            }
        }
        public UserEntity? GetUserByRole(string role)
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<UserEntity>>(json);

                if (list != null)
                    return list.FirstOrDefault(x => x.Role == role);

                return null;

            }
        }
        #endregion

        #region Product
        public List<ProductEntity>? GetAllProduct()
        {
            var file = Path.Combine(route, "Product.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ProductEntity>>(json);
            }
        }
        #endregion

        #region Customer
        public bool CreateCustomer(CustomerEntity model)
        {
            var file = Path.Combine(route, "Customer.JSON");

            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var content = JsonConvert.DeserializeObject<List<CustomerEntity>>(json);
                r.Close();

                if (content == null)
                    content = new List<CustomerEntity>();

                model.Id = content.Count + 1;
                content.Add(model);
                json = JsonConvert.SerializeObject(content, Formatting.Indented);
                File.WriteAllText(file, json);
                return true;
            }
        }
        #endregion


        #region Goald
        public bool CreateGoald(GoaldEntity model)
        {
            var file = Path.Combine(route, "Goald.JSON");

            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var content = JsonConvert.DeserializeObject<List<GoaldEntity>>(json);
                r.Close();

                if (content == null)
                    content = new List<GoaldEntity>();

                model.Id = content.Count + 1;
                content.Add(model);
                json = JsonConvert.SerializeObject(content, Formatting.Indented);
                File.WriteAllText(file, json);
                return true;
            }
        }
        public List<GoaldEntity>? GetAllGoald()
        {
            var file = Path.Combine(route, "Goald.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<GoaldEntity>>(json);
            }
        }
        public GoaldEntity? GetGoaldByUserId(int userId)
        {
            var file = Path.Combine(route, "Goald.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<GoaldEntity>>(json);
                if (list != null)
                    return list.FirstOrDefault(x => x.UserId == userId);

                return null;
            }
        }
        #endregion

        #region Period
        public List<PeriodEntity>? GetAllPeriod()
        {
            var file = Path.Combine(route, "Period.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<PeriodEntity>>(json);
            }
        }
        #endregion
    }
}
