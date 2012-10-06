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

namespace SymbolEditor.Silverlight.Windows
{
    public partial class FontWindow : ChildWindow
    {
        public GISServer.Core.Client.Symbols.Font fontsymbol { get; set; }
        public FontWindow()
        {
            InitializeComponent();
            fontsymbol = new GISServer.Core.Client.Symbols.Font();
        }

        public FontWindow(GISServer.Core.Client.Symbols.Font initialfont)
        {
            InitializeComponent();
            fontsymbol = new GISServer.Core.Client.Symbols.Font
            {
                Size = initialfont.Size,
                Family = initialfont.Family,
                Weight = "normal",
                Decoration = "none",
                Style = "style"
            };
            Update();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


        private void cbxstyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fontsymbol.Style = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            Update();
        }

        private void Update()
        {
            txtjson.Text = fontsymbol.ToJSON();
            txtpreview.FontSize = fontsymbol.Size;

            switch (fontsymbol.Weight)
            {
                case "bold":
                    txtpreview.FontWeight = FontWeights.Bold;
                    break;
                case "bolder":
                    txtpreview.FontWeight = FontWeights.ExtraBold;
                    break;
                case "lighter":
                    txtpreview.FontWeight = FontWeights.Light;
                    break;
                case "normal":
                    txtpreview.FontWeight = FontWeights.Normal;
                    break;

                default:
                    break;
            }

            switch (fontsymbol.Style)
            {
                case "italic":
                    txtpreview.FontStyle = FontStyles.Italic;
                    break;
                case "normal":
                    txtpreview.FontStyle = FontStyles.Normal;
                    break;
                case "oblique": //need to fix the oblique
                    txtpreview.FontStyle = FontStyles.Italic;
                    break;

                default:
                    break;
            }
            switch (fontsymbol.Decoration)
            {
                case "line-through":
                    txtpreview.TextDecorations = TextDecorations.Underline;
                    break;
                case "underline":
                    txtpreview.TextDecorations = TextDecorations.Underline;
                    break;
                case "none": //need to fix the oblique
                    txtpreview.TextDecorations = null;
                    break;

                default:
                    break;
            }

            txtpreview.FontFamily = new FontFamily(fontsymbol.Family);

        }

        private void cbxweight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fontsymbol.Weight = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            Update();
        }

        private void cbxdecoration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fontsymbol.Decoration = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            Update();
        }

        private void txtsize_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                fontsymbol.Size = output;
            }
            else
            {

            }
            Update();
        }

        private void cbxfamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fontsymbol.Family = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            Update();
        }
    }
}

