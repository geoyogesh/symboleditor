using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SymbolEditor.Silverlight.UserControls;
using GISServer.Core.Client.Utilities;

namespace SymbolEditor.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();


            var s = new SimpleMarkerSymbol();
            s.OnSymbolChanged += StringChanged;
            s.OnSymbolChanged += (sen, eve) =>
            {
                txtjson.Text = eve.Symbolstring;
                ucstylepreview.SymbolString = txtjson.Text;
            };
            s.SetValue(Grid.RowProperty, 0);
            s.SetValue(Grid.ColumnProperty, 0);
            grduc.Children.Clear();
            grduc.Children.Add(s);
            //initializing first time
            txtjson.Text = s.SymbolString;
            ucstylepreview.SymbolString = s.SymbolString;

        }
        private void StringChanged(object sender, SymbolStringChangedEventArgs e)
        {
//            var jsonstring = @"{
//    ""type"": ""esriSMS"",
//    ""style"": ""esriSMSSquare"",
//    ""color"": [76,115,0,255],
//    ""size"": 8,
//    ""angle"": 0,
//    ""xoffset"": 0,
//    ""yoffset"": 0,
//    ""outline"": 
//    {
//        ""color"": [152,230,0,255],
//        ""width"": 1
//    }
//}";
//            txtjson.Text = jsonstring;
//            ucstylepreview.SymbolString = jsonstring;


            txtjson.Text = e.Symbolstring;
            ucstylepreview.SymbolString = txtjson.Text;
        }

        private void txtjson_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var sym = ConvertSymbol.toJSON(txtjson.Text);
                if (sym is GISServer.Core.Client.Symbols.SimpleLineSymbol)
                {
                    //ucpicturefillsymbol.SymbolString = txtjson.Text;
                    ucstylepreview.SymbolString = txtjson.Text;
                }
            }
            catch (Exception)
            {

            }
        }

        private void cbxsymboltype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grduc!=null)
            {
                switch ((sender as ComboBox).SelectedIndex)
                {
                    case 0:
                        {
                            var s = new SimpleMarkerSymbol();
                            s.OnSymbolChanged += StringChanged;
                            s.OnSymbolChanged += (sen, eve) =>
                            {
                                txtjson.Text = eve.Symbolstring;
                                ucstylepreview.SymbolString = txtjson.Text;
                            };
                            s.SetValue(Grid.RowProperty, 0);
                            s.SetValue(Grid.ColumnProperty, 0);
                            grduc.Children.Clear();
                            grduc.Children.Add(s);
                            //initializing first time
                            txtjson.Text = s.SymbolString;
                            ucstylepreview.SymbolString = s.SymbolString;
                            break;
                        }
                    case 1:
                        {
                            var s = new SimpleLineSymbol();
                            s.OnSymbolChanged += StringChanged;
                            s.OnSymbolChanged += (sen, eve) =>
                            {
                                txtjson.Text = eve.Symbolstring;
                                ucstylepreview.SymbolString = txtjson.Text;
                            };
                            s.SetValue(Grid.RowProperty, 0);
                            s.SetValue(Grid.ColumnProperty, 0);
                            grduc.Children.Clear();
                            grduc.Children.Add(s);
                            //initializing first time
                            txtjson.Text = s.SymbolString;
                            ucstylepreview.SymbolString = s.SymbolString;
                            break;
                        }
                    case 2:
                        {
                            var s = new SimpleFillSymbol();
                            s.OnSymbolChanged += StringChanged;
                            s.OnSymbolChanged += (sen, eve) =>
                            {
                                txtjson.Text = eve.Symbolstring;
                                ucstylepreview.SymbolString = txtjson.Text;
                            };
                            s.SetValue(Grid.RowProperty, 0);
                            s.SetValue(Grid.ColumnProperty, 0);
                            grduc.Children.Clear();
                            grduc.Children.Add(s);
                            //initializing first time
                            txtjson.Text = s.SymbolString;
                            ucstylepreview.SymbolString = s.SymbolString;
                            break;
                        }
                    case 3:
                        {
                            var s = new PictureMarkerSymbol();
                            s.OnSymbolChanged += StringChanged;
                            s.OnSymbolChanged += (sen, eve) =>
                            {
                                txtjson.Text = eve.Symbolstring;
                                ucstylepreview.SymbolString = txtjson.Text;
                            };
                            s.SetValue(Grid.RowProperty, 0);
                            s.SetValue(Grid.ColumnProperty, 0);
                            grduc.Children.Clear();
                            grduc.Children.Add(s);
                            //initializing first time
                            txtjson.Text = s.SymbolString;
                            ucstylepreview.SymbolString = s.SymbolString;
                            break;
                        }
                    case 4:
                        {
                            var s = new PictureFillSymbol();
                            s.OnSymbolChanged += StringChanged;
                            s.OnSymbolChanged += (sen, eve) =>
                            {
                                txtjson.Text = eve.Symbolstring;
                                ucstylepreview.SymbolString = txtjson.Text;
                            };
                            s.SetValue(Grid.RowProperty, 0);
                            s.SetValue(Grid.ColumnProperty, 0);
                            grduc.Children.Clear();
                            grduc.Children.Add(s);
                            //initializing first time
                            txtjson.Text = s.SymbolString;
                            ucstylepreview.SymbolString = s.SymbolString;
                            break;
                        }
                }
            }
           
        }
    }
}
