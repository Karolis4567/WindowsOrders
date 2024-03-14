using WindowsOrders.BLL.Repos.Dtos;

namespace WindowsOrders.BLL.Repos
{
    public interface IWindowsOrdersMetaRepo
    {
        Task<IEnumerable<StatesDto>> GetStatesAsync();
        Task<IEnumerable<TypesDto>> GetTypesAsync();
    }
}
