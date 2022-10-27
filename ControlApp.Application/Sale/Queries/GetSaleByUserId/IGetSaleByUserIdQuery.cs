
namespace ControlApp.Application.Sale.Queries.GetSaleByUserId
{
    public interface IGetSaleByUserIdQuery
    {
        List<GetSaleByUserIdModel>? Execute(int userId);
    }
}
