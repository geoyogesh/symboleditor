using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GISServer.Core.Client.Utilities
{
    internal static class Serializer
    {
        public static string ToJsonWithoutFormatting(object obj)
        {
            return JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.None
                });
        }

        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting=Formatting.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

    }
}
