using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GISServer.Core.Client.Symbols
{
    public class TextSymbol : Symbol
    {
        public TextSymbol()
        {
            Type = "esriTS";
        }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("color")]
        public List<byte> Color { get; set; }
        [JsonProperty("backgroundColor")]
        public List<byte> BackgroundColor { get; set; }
        [JsonProperty("borderLineColor")]
        public List<byte> BorderLineColor { get; set; }
        [JsonProperty("verticalAlignment")]
        public String VerticalAlignment { get; set; }
        [JsonProperty("horizontalAlignment")]
        public string HorizontalAlignment { get; set; }
        [JsonProperty("rightToLeft")]
        public bool RightToLeft { get; set; }
        [JsonProperty("angle")]
        public Double Angle { get; set; }
        [JsonProperty("xoffset")]
        public Double Xoffset { get; set; }
        [JsonProperty("yoffset")]
        public Double Yoffset { get; set; }
        [JsonProperty("kerning")]
        public bool kerning { get; set; }
        [JsonProperty("font")]
        public Font Font { get; set; }
    }
}
