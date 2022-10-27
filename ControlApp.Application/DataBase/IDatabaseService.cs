using ControlApp.Domain.Customer;
using ControlApp.Domain.Goald;
using ControlApp.Domain.Period;
using ControlApp.Domain.Product;
using ControlApp.Domain.Sale;
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
        List<UserEntity>? GetUserByRole(string role);
        List<ProductEntity>? GetAllProduct();
        ProductEntity? GetProductById(int id);
        int CreateCustomer(CustomerEntity model);
        List<CustomerEntity>? GetAllCustomer();
        CustomerEntity? GetCustomerById(int id);
        bool CreateGoald(GoaldEntity model);
        List<GoaldEntity>? GetAllGoald();
        GoaldEntity? GetGoaldByUserIdPeriodId(int userId, int periodId);
        List<PeriodEntity>? GetAllPeriod();
        bool CreateSale(SaleEntity model);
        List<SaleEntity>? GetAllSale();
        List<SaleEntity>? GetAllSaleByUserId(int userId);
        List<SaleEntity>? GetAllSaleByUserIdByPeriodId(int userId, int periodId);
    }
}
