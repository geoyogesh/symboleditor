using System;
using System.Windows.Controls;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using System.Diagnostics;

namespace SymbolEditor.Silverlight.UserControls
{
    public partial class StylePreview : UserControl
    {
        private string symbolstring;

        public string SymbolString
        {
            get
            {
                return symbolstring;
            }
            set
            {

                Symbol symbol;
                try
                {
                    symbol = Symbol.FromJson(value);
                    var graphicsLayer = mapcanvas.Layers["MyGraphics"] as GraphicsLayer;


                    switch (symbol.GetType().Name)
                    {
                        case "SimpleMarkerSymbol":
                        case "PictureMarkerSymbol":
                        case "TextSymbol":
                            {
                                var gh = new Graphic();
                                if (!((graphicsLayer.Graphics.Count != 0) && (graphicsLayer.Graphics[0].Geometry is MapPoint)))
                                {
                                    gh.Geometry = getGeometry("Point");
                                    gh.Symbol = symbol;
                                    graphicsLayer.ClearGraphics();
                                    graphicsLayer.Graphics.Add(gh);
                                    mapcanvas.Extent = gh.Geometry.Extent;
                                }
                                else
                                {
                                    graphicsLayer.Graphics[0].Symbol = symbol;
                                    mapcanvas.Extent = graphicsLayer.Graphics[0].Geometry.Extent;
                                }
                            }
                            break;
                        case "SimpleLineSymbol":
                            {
                                var gh = new Graphic();
                                if (!((graphicsLayer.Graphics.Count != 0) && (graphicsLayer.Graphics[0].Geometry is Polyline)))
                                {
                                    gh.Geometry = getGeometry("Polyline");
                                    gh.Symbol = symbol;
                                    graphicsLayer.ClearGraphics();
                                    graphicsLayer.Graphics.Add(gh);
                                    mapcanvas.Extent = gh.Geometry.Extent;
                                }
                                else
                                {
                                    graphicsLayer.Graphics[0].Symbol = symbol;
                                    mapcanvas.Extent = graphicsLayer.Graphics[0].Geometry.Extent;
                                }
                            }
                            break;
                        case "SimpleFillSymbol":
                        case "PictureFillSymbol":
                            {
                                var gh = new Graphic();
                                if (!((graphicsLayer.Graphics.Count != 0) && (graphicsLayer.Graphics[0].Geometry is Polygon)))
                                {
                                    gh.Geometry = getGeometry("Polygon");
                                    gh.Symbol = symbol;
                                    graphicsLayer.ClearGraphics();
                                    graphicsLayer.Graphics.Add(gh);
                                    mapcanvas.Extent = gh.Geometry.Extent;
                                }
                                else
                                {
                                    graphicsLayer.Graphics[0].Symbol = symbol;
                                    mapcanvas.Extent = graphicsLayer.Graphics[0].Geometry.Extent;
                                }
                            }
                            break;
                        default:
                            {
                            }
                            break;
                    }

                    //foreach (var g in graphicsLayer.Graphics)
                    //{
                    //    if ((g.Geometry is Polygon) && symbol is FillSymbol)
                    //    {
                    //        g.Symbol = symbol;
                    //    }
                    //    else if (g.Geometry is Polyline && symbol is LineSymbol)
                    //    {
                    //        g.Symbol = symbol;
                    //    }
                    //    else if (g.Geometry is MapPoint && symbol is MarkerSymbol)
                    //    {
                    //        g.Symbol = symbol;
                    //    }
                    //}
                    symbolstring = value;
                }
                catch (Exception)
                {


                }


            }
        }

        private ESRI.ArcGIS.Client.Geometry.Geometry getGeometry(string geometrytype)
        {
            switch (geometrytype)
            {
                case "Point":
                    var point = new MapPoint(-16584535.1432908, 8580553.67499035);
                    return point;
                case "Polyline":
                    {
                        string coordinatestring = "-16584535.1432908,8580553.67499035 -16583535.1432908,8585553.67499035 -16580535.1432908,8575553.67499035";
                        var pointcollection = new PointCollectionConverter().ConvertFromString(coordinatestring) as ESRI.ArcGIS.Client.Geometry.PointCollection;
                        var polygon = new ESRI.ArcGIS.Client.Geometry.Polyline();
                        polygon.Paths.Add(pointcollection);
                        return polygon;
                    }
                case "Polygon":
                    {
                        string coordinatestring = "-16584535.1432908,8580553.67499035 -16583535.1432908,8585553.67499035 -16580535.1432908,8575553.67499035 -16584515.1432908,8580555.67499035 -16584535.1432908,8580553.67499035";
                        var pointcollection = new PointCollectionConverter().ConvertFromString(coordinatestring) as ESRI.ArcGIS.Client.Geometry.PointCollection;
                        var polygon = new ESRI.ArcGIS.Client.Geometry.Polygon();
                        polygon.Rings.Add(pointcollection);
                        return polygon;
                    }
                case "Multipoint":
                    return null;
                case "Envelope":
                    return null;
                default:
                    return null;
            }
        }


        public StylePreview()
        {
            InitializeComponent();
            
        }

        private void mapcanvas_ExtentChanged(object sender, ExtentEventArgs e)
        {
            Debug.WriteLine("================================");
            Debug.WriteLine(mapcanvas.Extent.XMin.ToString());
            Debug.WriteLine(mapcanvas.Extent.YMin.ToString());
            Debug.WriteLine(mapcanvas.Extent.XMax.ToString());
            Debug.WriteLine(mapcanvas.Extent.YMax.ToString());
            Debug.WriteLine("================================");
        }
    }
}
