
using System.Collections.Generic;
using Newtonsoft.Json;
namespace GISServer.Core.Client.Symbols
{
    public class PictureFillSymbol
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("imageData")]
        public string ImageData { get; set; }
        [JsonProperty("contentType")]
        public string contentType { get; set; }
        [JsonProperty("outline")]
        public SimpleLineSymbol Outline { get; set; }
        [JsonProperty("color")]
        public List<int> Color { get; set; }
        [JsonProperty("width")]
        public double Width { get; set; }
        [JsonProperty("height")]
        public double Height { get; set; }
        [JsonProperty("angle")]
        public double Angle { get; set; }
        [JsonProperty("xoffset")]
        public double Xoffset { get; set; }
        [JsonProperty("yoffset")]
        public double Yoffset { get; set; }
        [JsonProperty("xscale")]
        public double Xscale { get; set; }
        [JsonProperty("yscale")]
        public double Yscale { get; set; }
    }
}
