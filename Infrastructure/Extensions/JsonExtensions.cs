using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static T ToObject<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
