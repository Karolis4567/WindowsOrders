using WindowsOrders.BLL.ApiServices.ApiClients;
using WindowsOrders.BLL.Extensions;
using WindowsOrders.BLL.Repos.Dtos;

namespace WindowsOrders.BLL.ApiServices
{
    public class ApiService : IApiService   
    {
        internal ApiClient apiClient;
        public ApiService(string baseUrl)
        {
            this.apiClient = new ApiClient(baseUrl);
        }   

        public async Task<IEnumerable<StatesDto>> GetStatesAsync()
        {
            var result = await this.apiClient.GetAsync("WindowsOrdersMeta/GetStates");
            return result.GetResponseObject<IEnumerable<StatesDto>>();
        }

        public async Task<IEnumerable<TypesDto>> GetTypesAsync()
        {
            var result = await this.apiClient.GetAsync("WindowsOrdersMeta/GetTypes");
            return result.GetResponseObject<IEnumerable<TypesDto>>();
        }
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var result = await this.apiClient.GetAsync("WindowsOrders/GetAllOrders");
            return result.GetResponseObject<IEnumerable<OrderDto>>();
        }

        public async Task<OrderDto> GetOrderAsync(int id)
        {
            var result = await this.apiClient.GetAsync($"WindowsOrders/GetOrder?id={id}");
            return result.GetResponseObject<OrderDto>();
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var result = await this.apiClient.GetAsync($"WindowsOrders/DeleteOrder?id={id}");
            return result.isRequestSucceeded;
        }

        public async Task<int> SaveOrderAsync(OrderDto newOrder)
        {
            var result = await this.apiClient.PostAsync("WindowsOrders/SaveOrder", newOrder);
            return result.responseContent.ToInt();
        }

        

    }
}
