using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GISServer.Core.Client.Symbols
{
    public class SimpleMarkerSymbol:Symbol
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("style")]
        public String Style { get; set; }
        [JsonProperty("color")]
        public List<int> Color { get; set; }
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
        public Outline(int width,List<int> color)
        {
            this.Color = color;
            this.Width = width;
        }

        public Outline(int width, params int[] color)
        {
            var colorlist = new List<int>();
            foreach (var item in color)
            {
                colorlist.Add(item);
            }
            this.Color = colorlist;
            this.Width = width;
        }
        [JsonProperty("color")]
        public List<int> Color { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
