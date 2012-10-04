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
using SymbolEditor.Silverlight.Views.Windows;

namespace SymbolEditor.Silverlight.Views
{
    public partial class TextSymbol : Page
    {
        GISServer.Core.Client.Symbols.TextSymbol simplemarkersymbol;
        public TextSymbol()
        {
            InitializeComponent();
            simplemarkersymbol = new GISServer.Core.Client.Symbols.TextSymbol();
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

        private void recbackcolor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                    simplemarkersymbol.BackgroundColor = w.Color;
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

        private void recborderlinecolor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                    simplemarkersymbol.BorderLineColor = w.Color;
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

        private void cbxverticalalignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            simplemarkersymbol.VerticalAlignment = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void cbxhorizontalalignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            simplemarkersymbol.HorizontalAlignment = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            txtjson.Text = simplemarkersymbol.ToJSON();
        }

        private void cbxrighttoleft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            simplemarkersymbol.RightToLeft = Convert.ToBoolean(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString());
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

        private void txtfont_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var previewtextblock = (sender as TextBlock);

            var initialfont = new GISServer.Core.Client.Symbols.Font
                {
                    Size = previewtextblock.FontSize,
                    Family = previewtextblock.FontFamily.Source
                };



            var window = new FontWindow(initialfont);
            window.Closed += (s, eve) =>
            {
                var w = (FontWindow)s;
                if (w.DialogResult == true)
                {
                    simplemarkersymbol.Font = w.fontsymbol;

                    Update(w.fontsymbol);
                    txtjson.Text = simplemarkersymbol.ToJSON();
                }
            };

            window.Show();
        }

        private void Update(GISServer.Core.Client.Symbols.Font fontsymbol)
        {
            txtfont.FontSize = fontsymbol.Size;

            switch (fontsymbol.Weight)
            {
                case "bold":
                    txtfont.FontWeight = FontWeights.Bold;
                    break;
                case "bolder":
                    txtfont.FontWeight = FontWeights.ExtraBold;
                    break;
                case "lighter":
                    txtfont.FontWeight = FontWeights.Light;
                    break;
                case "normal":
                    txtfont.FontWeight = FontWeights.Normal;
                    break;

                default:
                    break;
            }

            switch (fontsymbol.Style)
            {
                case "italic":
                    txtfont.FontStyle = FontStyles.Italic;
                    break;
                case "normal":
                    txtfont.FontStyle = FontStyles.Normal;
                    break;
                case "oblique": //need to fix the oblique
                    txtfont.FontStyle = FontStyles.Italic;
                    break;

                default:
                    break;
            }
            switch (fontsymbol.Decoration)
            {
                case "line-through":
                    txtfont.TextDecorations = TextDecorations.Underline;
                    break;
                case "underline":
                    txtfont.TextDecorations = TextDecorations.Underline;
                    break;
                case "none": //need to fix the oblique
                    txtfont.TextDecorations = null;
                    break;

                default:
                    break;
            }

            txtfont.FontFamily = new FontFamily(fontsymbol.Family);
        }

    }
}
