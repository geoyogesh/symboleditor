using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GISServer.Core.Client.Symbols
{
    public class SimpleFillSymbol:Symbol
    {
        [JsonProperty("type")]
        public String Type { get; set; }
        [JsonProperty("style")]
        public String Style { get; set; }
        [JsonProperty("color")]
        public List<int> Color { get; set; }
        [JsonProperty("outline")]
        public SimpleLineSymbol Outline { get; set; }
    }
}
