
using Newtonsoft.Json;
namespace GISServer.Core.Client.Symbols
{
    public class Font
    {
        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("decoration")]
        public string Decoration { get; set; }

        public string ToJSON()
        {
            return GISServer.Core.Client.Utilities.Serializer.ToJson(this);
        }
    }
}
