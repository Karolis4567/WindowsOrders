using WindowsOrders.BLL.ApiServices.Extensions;

namespace WindowsOrders.BLL.ApiServices.ApiClients
{
    public class ApiClientReturn
    {
        public ApiClientReturn(HttpResponseMessage response)
        {

            this.statusCode = (int)response.StatusCode;
            this.isRequestSucceeded = response.IsSuccessStatusCode;
            this.responseContent = response.Content.ReadAsStringAsync().Result;
        }


        public bool isRequestSucceeded { get; init; }
        public int statusCode { get; init; }
        public string responseContent { get; init; }

        public T GetResponseObject<T>() where T : class
        {           
            return this.responseContent.FromJson<T>();
        }
    }
}