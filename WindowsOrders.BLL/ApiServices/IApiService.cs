using WindowsOrders.BLL.Repos.Dtos;

namespace WindowsOrders.BLL.ApiServices
{
    public interface IApiService
    {
        Task<IEnumerable<StatesDto>> GetStatesAsync();
        Task<IEnumerable<TypesDto>> GetTypesAsync();
        Task<int> SaveOrderAsync(OrderDto newOrder);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
    }
}
