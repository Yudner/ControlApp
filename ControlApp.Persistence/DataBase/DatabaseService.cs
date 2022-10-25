using ControlApp.Application.DataBase;
using ControlApp.Domain.Customer;
using ControlApp.Domain.Goald;
using ControlApp.Domain.Product;
using ControlApp.Domain.User;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Xml.Linq;

namespace ControlApp.Persistence.DataBase
{
    public class DatabaseService: IDatabaseService
    {
        private static string route = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "Files");
       
        public List<UserEntity>? GetAllUser()
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserEntity>>(json);
            }
        }

        public List<ProductEntity>? GetAllProduct()
        {
            var file = Path.Combine(route, "Product.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ProductEntity>>(json);
            }
        }

        public bool CreateCustomer(CustomerEntity model)
        {
            var file = Path.Combine(route, "Customer.JSON");

            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var content = JsonConvert.DeserializeObject<List<CustomerEntity>>(json);
                r.Close();
                
                if(content == null)
                    content = new List<CustomerEntity>();

                model.Id = content.Count + 1;
                content.Add(model);
                json = JsonConvert.SerializeObject(content, Formatting.Indented);
                File.WriteAllText(file, json);
                return true;
            }            
        }
        
        public bool CreateGoald(GoaldEntity model)
        {
            var file = Path.Combine(route, "Goald.JSON");

            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                var content = JsonConvert.DeserializeObject<List<GoaldEntity>>(json);
                r.Close();
                
                if(content == null)
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
                if(list != null)
                    return list.FirstOrDefault(x => x.UserId == userId);

                return null;
            }
        }
    }
}
