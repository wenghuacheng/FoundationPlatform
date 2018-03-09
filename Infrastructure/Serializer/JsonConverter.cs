using Newtonsoft.Json;

namespace Infrastructure.Serializer
{
    public class JsonConverter
    {
        public static string ToJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static T ToObject<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
