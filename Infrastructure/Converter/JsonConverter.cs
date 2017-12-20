using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.Converter
{
    public class JsonConverter
    {
        public static string ToJson(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        public static T ToObject<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
