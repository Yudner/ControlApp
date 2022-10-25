using ControlApp.Application.DataBase;
using ControlApp.Domain.Customer;
using ControlApp.Domain.Product;
using ControlApp.Domain.User;

namespace ControlApp.Persistence.DataBase
{
    public class DatabaseService: IDatabaseService
    {
        public List<UserEntity> User()
        {
            return new List<UserEntity>
            {
                new UserEntity
                {
                    Id = 1,
                    Code = "A101",
                    Name = "Jose Carrera",
                    Role = "Asesor Comercial"
                },
                new UserEntity
                {
                    Id = 2,
                    Code = "A102",
                    Name = "Juan Domingo",
                    Role = "Asesor Comercial"
                },
                new UserEntity
                {
                    Id = 3,
                    Code = "A103",
                    Name = "Javier Prado",
                    Role = "Asesor Comercial"
                },
                new UserEntity
                {
                    Id = 4,
                    Code = "G101",
                    Name = "Yudner Paredes",
                    Role = "Gerente de Agencia"
                },
                new UserEntity
                {
                    Id = 5,
                    Code = "G102",
                    Name = "Diego Paredes",
                    Role = "Gerente de Agencia"
                }
            };
        }

        public List<ProductEntity> Product()
        {
            return new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = 1,
                    ProductName = "Tarjeta de Crédito Clásica",
                    Points = 10
                },

                new ProductEntity
                {
                    Id = 2,
                    ProductName = "Tarjeta de Crédito Oro",
                    Points = 20
                },
                new ProductEntity
                {
                    Id = 3,
                    ProductName = "Tarjeta de Crédito Platino",
                    Points = 40
                },
                new ProductEntity
                {
                    Id = 4,
                    ProductName = "Crédito Hipotecario",
                    Percentage = 0.5
                },
                new ProductEntity
                {
                    Id = 5,
                    ProductName = "Crédito efectivo",
                    Percentage = 0.3
                }
            };
        }
        public List<CustomerEntity> Customer()
        {
            return new List<CustomerEntity>
            {
                
            };
        }

    }
}
