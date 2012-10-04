using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GISServer.Core.Client.Symbols
{
    public class SimpleMarkerSymbol : Symbol
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("style")]
        public String Style { get; set; }
        [JsonProperty("color")]
        public List<byte> Color { get; set; }
        [JsonProperty("size")]
        public double Size { get; set; }
        [JsonProperty("angle")]
        public double Angle { get; set; }
        [JsonProperty("xoffset")]
        public double Xoffset { get; set; }
        [JsonProperty("yoffset")]
        public double Yoffset { get; set; }
        [JsonProperty("outline")]
        public Outline Outline { get; set; }
    }
    public class Outline
    {
        public Outline()
        {
        }
        public Outline(double width, List<byte> color)
        {
            this.Color = color;
            this.Width = width;
        }

        public Outline(double width, params byte[] color)
        {
            var colorarray = new List<byte>();
            foreach (var item in color)
            {
                colorarray.Add(item);
            }
            this.Color = colorarray;
            this.Width = width;
        }
        [JsonProperty("color")]
        public List<byte> Color { get; set; }
        [JsonProperty("width")]
        public double Width { get; set; }
    }
}
