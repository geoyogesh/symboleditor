
using Newtonsoft.Json;
namespace GISServer.Core.Client.Symbols
{
    public class Symbol
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        public string ToJSON()
        {
            return GISServer.Core.Client.Utilities.Serializer.ToJson(this);
        }
    }
}
