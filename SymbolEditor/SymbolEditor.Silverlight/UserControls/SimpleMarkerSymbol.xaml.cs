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
using SymbolEditor.Silverlight.Windows;

namespace SymbolEditor.Silverlight.UserControls
{
    public delegate void SymbolStringChangedHandler(object sender, SymbolStringChangedEventArgs e);

    public class SymbolStringChangedEventArgs : EventArgs
    {
        public String Symbolstring;

        public SymbolStringChangedEventArgs(string Symbolstring)
        {
            this.Symbolstring = Symbolstring;
        }
    }



    public partial class SimpleMarkerSymbol : UserControl
    {
        private GISServer.Core.Client.Symbols.SimpleMarkerSymbol simplemarkersymbol;

        #region JSON Changed Event
        public event SymbolStringChangedHandler OnSymbolChanged;

        protected virtual void JsonStringChanged(SymbolStringChangedEventArgs e)
        {
            if (OnSymbolChanged != null) { OnSymbolChanged(this, e); }
        }
        #endregion
        private string symbolstring;

        public String SymbolString
        {
            get
            {
                return symbolstring;
            }
            set
            {
                try
                {
                    simplemarkersymbol = (GISServer.Core.Client.Symbols.SimpleMarkerSymbol)GISServer.Core.Client.Utilities.ConvertSymbol.toJSON(value);
                    symbolstring = simplemarkersymbol.ToJSON();
                    UpdateUI(simplemarkersymbol);
                }
                catch (Exception)
                {

                }
            }
        }

        private void UpdateUI(GISServer.Core.Client.Symbols.SimpleMarkerSymbol simplemarkersymbol)
        {
            txttype.Text = simplemarkersymbol.Type;
            txtsize.Text = simplemarkersymbol.Size.ToString();
            txtangle.Text = simplemarkersymbol.Angle.ToString();
            txtxoffset.Text = simplemarkersymbol.Xoffset.ToString();
            txtyoffset.Text = simplemarkersymbol.Yoffset.ToString();


            var colorbrush = new SolidColorBrush
            {
                Color = new System.Windows.Media.Color
                {
                    R = simplemarkersymbol.Color[0],
                    G = simplemarkersymbol.Color[1],
                    B = simplemarkersymbol.Color[2],
                    A = simplemarkersymbol.Color[3]
                }
            };
            reccolor.Fill = colorbrush;

            var bordercolorbrush = new SolidColorBrush
            {
                Color = new System.Windows.Media.Color
                {
                    R = simplemarkersymbol.Outline.Color[0],
                    G = simplemarkersymbol.Outline.Color[1],
                    B = simplemarkersymbol.Outline.Color[2],
                    A = simplemarkersymbol.Outline.Color[3]
                }
            };
            boroutline.BorderBrush = bordercolorbrush;
            boroutline.BorderThickness = new Thickness(simplemarkersymbol.Outline.Width);


            switch (simplemarkersymbol.Style)
            {
                case "esriSMSCircle":
                    cbxstyle.SelectedIndex = 0;
                    break;
                case "esriSMSCross":
                    cbxstyle.SelectedIndex = 1;
                    break;
                case "esriSMSDiamond":
                    cbxstyle.SelectedIndex = 2;
                    break;
                case "esriSMSSquare":
                    cbxstyle.SelectedIndex = 3;
                    break;
                case "esriSMSX":
                    cbxstyle.SelectedIndex = 4;
                    break;
                default:
                    break;
            }

        }

        public SimpleMarkerSymbol()
        {
            simplemarkersymbol = new GISServer.Core.Client.Symbols.SimpleMarkerSymbol();
            InitializeComponent();

            UpdateJSONforInitialUI();

        }

        private void UpdateJSONforInitialUI()
        {
            simplemarkersymbol.Type = txttype.Text;

            simplemarkersymbol.Size = Double.Parse(txtsize.Text);
            simplemarkersymbol.Angle = Double.Parse(txtangle.Text);
            simplemarkersymbol.Xoffset = Double.Parse(txtxoffset.Text);
            simplemarkersymbol.Yoffset = Double.Parse(txtyoffset.Text);

            var initialcolor = (reccolor.Fill as SolidColorBrush).Color;
            simplemarkersymbol.Color = new List<byte>(
                    new byte[] { initialcolor.R, initialcolor.G, initialcolor.B, initialcolor.A }
                );


            var initialbordercolor = (boroutline.BorderBrush as SolidColorBrush).Color;
            simplemarkersymbol.Outline = new GISServer.Core.Client.Symbols.Outline
            {
                Color = new List<byte>(
                    new byte[] { initialbordercolor.R, initialbordercolor.G, initialbordercolor.B, initialbordercolor.A }
                ),
                Width = boroutline.BorderThickness.Bottom
            };

            simplemarkersymbol.Style = (cbxstyle.SelectedItem as ComboBoxItem).Content.ToString();
            UpdateJson();
        }

        private void txttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            simplemarkersymbol.Type = (sender as TextBox).Text;
            UpdateJson();
        }

        private void UpdateJson()
        {
            symbolstring = simplemarkersymbol.ToJSON();
            SymbolStringChangedEventArgs newjsonstring = new SymbolStringChangedEventArgs(symbolstring);
            JsonStringChanged(newjsonstring);
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
            UpdateJson();
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
            UpdateJson();
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
            UpdateJson();
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
            UpdateJson();
        }

        private void cbxstyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                simplemarkersymbol.Style = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
                UpdateJson();
            
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
                    UpdateJson();
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
                ), rec.BorderThickness.Bottom);
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
                    UpdateJson();
                }
            };
            window.Show();
        }


    }
}
