using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GISServer.Core.Client.Symbols
{
    public class SimpleLineSymbol : Symbol
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("style")]
        public String Style { get; set; }
        [JsonProperty("color")]
        public List<byte> Color { get; set; }
        [JsonProperty("width")]
        public double Width { get; set; }
    }
}
