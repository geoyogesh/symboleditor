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
    public partial class SimpleLineSymbol : UserControl
    {
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
                    simplemarkersymbol = (GISServer.Core.Client.Symbols.SimpleLineSymbol)GISServer.Core.Client.Utilities.ConvertSymbol.toJSON(value);
                    symbolstring = simplemarkersymbol.ToJSON();
                    UpdateUI(simplemarkersymbol);
                }
                catch (Exception)
                {

                }
            }
        }

        private void UpdateUI(GISServer.Core.Client.Symbols.SimpleLineSymbol simplemarkersymbol)
        {
            txttype.Text = simplemarkersymbol.Type;
            txtwidth.Text = simplemarkersymbol.Width.ToString();

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

            switch (simplemarkersymbol.Style)
            {
                case "esriSLSDash":
                    cbxstyle.SelectedIndex = 0;
                    break;
                case "esriSLSDashDotDot":
                    cbxstyle.SelectedIndex = 1;
                    break;
                case "esriSLSDot":
                    cbxstyle.SelectedIndex = 2;
                    break;
                case "esriSLSNull":
                    cbxstyle.SelectedIndex = 3;
                    break;
                case "esriSLSSolid":
                    cbxstyle.SelectedIndex = 4;
                    break;
                default:
                    break;
            }
        }


        GISServer.Core.Client.Symbols.SimpleLineSymbol simplemarkersymbol;
        public SimpleLineSymbol()
        {
            simplemarkersymbol = new GISServer.Core.Client.Symbols.SimpleLineSymbol();
            InitializeComponent();

            UpdateJSONforInitialUI();

        }

        private void UpdateJSONforInitialUI()
        {
            simplemarkersymbol.Type = txttype.Text;
            simplemarkersymbol.Style = (cbxstyle.SelectedItem as ComboBoxItem).Content.ToString();
            simplemarkersymbol.Width = Double.Parse(txtwidth.Text);
            var initialcolor = (reccolor.Fill as SolidColorBrush).Color;
            simplemarkersymbol.Color = new List<byte>(
                    new byte[] { initialcolor.R, initialcolor.G, initialcolor.B, initialcolor.A }
                );
            UpdateJson();
        }

        private void UpdateJson()
        {
            symbolstring = simplemarkersymbol.ToJSON();
            SymbolStringChangedEventArgs newjsonstring = new SymbolStringChangedEventArgs(symbolstring);
            JsonStringChanged(newjsonstring);
        }

        private void txttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            simplemarkersymbol.Type = (sender as TextBox).Text;
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
                var w = (SelectColorWindow)s;
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

        private void txtwidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                simplemarkersymbol.Width = output;
            }
            else
            {

            }
            UpdateJson();
        }

    }
}
