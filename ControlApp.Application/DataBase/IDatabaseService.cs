using ControlApp.Domain.Customer;
using ControlApp.Domain.Goald;
using ControlApp.Domain.Period;
using ControlApp.Domain.Product;
using ControlApp.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.DataBase
{
    public interface IDatabaseService
    {
        List<UserEntity>? GetAllUser();
        UserEntity? GetUserByCode(string code);
        List<ProductEntity>? GetAllProduct();
        bool CreateCustomer(CustomerEntity model);
        bool CreateGoald(GoaldEntity model);
        List<GoaldEntity>? GetAllGoald();
        GoaldEntity? GetGoaldByUserId(int userId);
        List<PeriodEntity>? GetAllPeriod();
    }
}
