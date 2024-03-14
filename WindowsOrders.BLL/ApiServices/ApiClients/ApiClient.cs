using System.Text;
using WindowsOrders.BLL.ApiServices.Extensions;

namespace WindowsOrders.BLL.ApiServices.ApiClients
{
    public class ApiClient
    {
        protected HttpClient _httpClient;
        protected string _baseUrl;
        public ApiClient(string baseUrl)
        {
            this._baseUrl = baseUrl;    
            this._httpClient = new HttpClient();        
        }

        protected string GetFullUrl(string url) =>
            $"{this._baseUrl}{url}";

       public async Task<ApiClientReturn> GetAsync(string url)
       {
            var response = await this._httpClient.GetAsync(this.GetFullUrl(url));
            return new ApiClientReturn(response);
       }

        public async Task<ApiClientReturn> PostAsync(string url, object data)
        {
            var content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json");
            var testUrl = this.GetFullUrl(url);
            try
            {
                var response = await _httpClient.PostAsync(testUrl, content);
                return new ApiClientReturn(response);
            } 
            catch (Exception ex) 
            {
                var forTest = data.ToJson();
                return null;
            }
        }

    }
}
