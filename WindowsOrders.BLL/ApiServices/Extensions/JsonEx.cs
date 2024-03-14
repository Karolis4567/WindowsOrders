using Newtonsoft.Json;

namespace WindowsOrders.BLL.ApiServices.Extensions
{
    public static class JsonEx
    {
        public static string ToJson(this object obj)
        {
            if (obj == null) return null;
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(this string jsonString) where T : class
        {
            if (jsonString == null || jsonString.Trim().Length == 0) return null;
            return JsonConvert.DeserializeObject<T>(jsonString);

        }
    }
}
