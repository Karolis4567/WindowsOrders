using WindowsOrders.BLL.Repos.Dtos;

namespace WindowsOrders.BLL.Repos
{
    public interface IWindowsOrdersRepo
    {
        Task<int> SaveOrderAsync(OrderDto newOrder);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
        
    }
}
