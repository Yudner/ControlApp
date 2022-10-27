using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp.Application.Sale.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        bool Execute(CreateSaleModel model);
    }
}
