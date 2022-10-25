using ControlApp.Application.DataBase;
using ControlApp.Domain.CommercialAdvisor;
using ControlApp.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Persistence.DataBase
{
    public class DatabaseService: IDatabaseService
    {
        public List<CommercialAdvisorEntity> CommercialAdvisor()
        {
            return new List<CommercialAdvisorEntity>
            {
                new CommercialAdvisorEntity
                {
                    Id = 1,
                    Code = "T101",
                    Name = "Jose Carrera"
                },
                new CommercialAdvisorEntity
                {
                    Id = 2,
                    Code = "T102",
                    Name = "Juan Domingo"
                },
                new CommercialAdvisorEntity
                {
                    Id = 3,
                    Code = "T103",
                    Name = "Javier Prado"
                }
            };
        }

        public List<CustomerEntity> Customer()
        {
            return new List<CustomerEntity>
            {
                new CustomerEntity
                {
                    Id = 1,
                    
                }
            };
        }

    }
}
