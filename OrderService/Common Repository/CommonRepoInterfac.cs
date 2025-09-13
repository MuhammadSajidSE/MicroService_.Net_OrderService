using OrderService.Return_Data;

namespace OrderService.Common_Repository
{
    public interface CommonRepoInterfac<Tentity, TDTO>
    {
        Task<CommonRetrun> AddOrder(TDTO dto);
        Task<CommonRetrun> GetAllOrder();
    }
}
