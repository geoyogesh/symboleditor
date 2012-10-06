using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GISServer.Core.Client.Symbols;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GISServer.Core.Client.Utilities
{
    public static class ConvertSymbol
    {

        public static Symbol toJSON(string jsonstring)
    {
        JObject geometryjobject = JObject.Parse(jsonstring);
        var type= (string)geometryjobject["type"];
        switch (type)
        {
            case "esriSMS":
                {
                    return JsonConvert.DeserializeObject<SimpleMarkerSymbol>(jsonstring);
                }
            case "esriSLS":
                {
                    return JsonConvert.DeserializeObject<SimpleLineSymbol>(jsonstring);
                }
            case "esriSFS":
                {
                    return JsonConvert.DeserializeObject<SimpleFillSymbol>(jsonstring);
                }
            case "esriPMS":
                {
                    return JsonConvert.DeserializeObject<PictureMarkerSymbol>(jsonstring);
                }
            case "esriPFS":
                {
                    return JsonConvert.DeserializeObject<PictureMarkerSymbol>(jsonstring);
                }
            case "esriTS":
                {
                    return JsonConvert.DeserializeObject<TextSymbol>(jsonstring);
                }
            default:
                return null;
        }
    }

}
}
