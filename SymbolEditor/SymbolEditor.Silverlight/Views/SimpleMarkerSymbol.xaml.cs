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
using System.Windows.Navigation;
using GISServer.Core.Client;
using InnerProduct;
using SymbolEditor.Silverlight.Views.Windows;

namespace SymbolEditor.Silverlight.Views
{
    public partial class SimpleMarkerSymbol : Page
    {
        GISServer.Core.Client.Symbols.SimpleMarkerSymbol simplemarkersymbol;

        public SimpleMarkerSymbol()
        {
            InitializeComponent();
            simplemarkersymbol = new GISServer.Core.Client.Symbols.SimpleMarkerSymbol();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void txttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            simplemarkersymbol.Type = (sender as TextBox).Text;
            txtjson.Text = simplemarkersymbol.ToJSON();
        }


        

        private void txtsize_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                simplemarkersymbol.Size = output;
            }
            else
            {

            }
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void txtangle_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                simplemarkersymbol.Angle = output;
            }
            else
            {

            }
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void txtxoffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                simplemarkersymbol.Xoffset = output;
            }
            else
            {

            }
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void txtyoffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                simplemarkersymbol.Yoffset = output;
            }
            else
            {

            }
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void txtoutline_TextChanged(object sender, TextChangedEventArgs e)
        {
            //simplemarkersymbol.Outline = (sender as TextBox).Text;
            //txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void cbxstyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            simplemarkersymbol.Style = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void reccolor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rec = (sender as Rectangle);
            var initialcolor = (rec.Fill as SolidColorBrush).Color;
            var window = new SelectColorWindow(new List<byte>(
                    new byte[] { initialcolor.R, initialcolor.G, initialcolor.B, initialcolor.A }
                ));
            window.Closed += (s, eve) =>
            {
                SelectColorWindow w = (SelectColorWindow)s;
                if (w.DialogResult == true)
                {
                    simplemarkersymbol.Color = w.Color;
                    var colorbrush = new SolidColorBrush
                        {
                            Color = new System.Windows.Media.Color
                        {
                            R = w.Color[0],
                            G = w.Color[1],
                            B = w.Color[2],
                            A = w.Color[3]
                        }
                        };
                    rec.Fill = colorbrush;
                    txtjson.Text = simplemarkersymbol.ToJSON();
                }
            };
            window.Show();
        }

        private void boroutline_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rec = (sender as Border);
            var initialcolor = (rec.BorderBrush as SolidColorBrush).Color;
            var window = new OutlineWindow(new List<byte>(
                    new byte[] { initialcolor.R, initialcolor.G, initialcolor.B, initialcolor.A }
                ),rec.BorderThickness.Bottom);
            window.Closed += (s, eve) =>
            {
                var w = (OutlineWindow)s;
                if (w.DialogResult == true)
                {
                    simplemarkersymbol.Outline = w.outline;
                    var colorbrush = new SolidColorBrush
                    {
                        Color = new System.Windows.Media.Color
                        {
                            R = w.outline.Color[0],
                            G = w.outline.Color[1],
                            B = w.outline.Color[2],
                            A = w.outline.Color[3]
                        }
                    };
                    rec.BorderBrush = colorbrush;
                    rec.BorderThickness = new Thickness(w.outline.Width);
                    txtjson.Text = simplemarkersymbol.ToJSON();
                }
            };
            window.Show();
        }
    }
}
