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

namespace SymbolEditor.Silverlight.Views.Windows
{
    public partial class OutlineWindow : ChildWindow
    {
        

        public GISServer.Core.Client.Symbols.Outline outline { get; set; }

        public OutlineWindow()
        {
            InitializeComponent();
        }

        public OutlineWindow(List<byte> Color,double Thickness)
        {
            InitializeComponent();

            //Setting the initial Values
            outline = new GISServer.Core.Client.Symbols.Outline(Thickness, Color);
            var colorbrush = new SolidColorBrush
            {
                Color = new System.Windows.Media.Color
                {
                    R = Color[0],
                    G = Color[1],
                    B = Color[2],
                    A = Color[3]
                }
            };
            reccolor.BorderThickness = new Thickness(Thickness);


            //Updating the UI based initial values
            reccolor.BorderBrush = colorbrush;
            colorchooser.R = Color[0];
            colorchooser.G = Color[1];
            colorchooser.B = Color[2];
            colorchooser.A = Color[3];
            txtwidth.Text=Thickness.ToString();
            txtjson.Text = GISServer.Core.Client.Utilities.Serializer.ToJson(outline);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void colorchooser_updatecolor(object sender, EventArgs e)
        {
            var colorpick = (sender as InnerProduct.ColorPickr);

            outline.Color = new List<byte>(
                new byte[] { colorpick.R, colorpick.G, colorpick.B, colorpick.A }
                );
            var colorbrush = new SolidColorBrush
            {
                Color = new System.Windows.Media.Color
                {
                    R = colorpick.R,
                    G = colorpick.G,
                    B = colorpick.B,
                    A = colorpick.A
                }
            };
            reccolor.BorderBrush = colorbrush;
            txtjson.Text = GISServer.Core.Client.Utilities.Serializer.ToJson(this.outline);
        }

        private void txtwidth_TextChanged(object sender, TextChangedEventArgs e)
        {

            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
               outline.Width = output;
               txtjson.Text = GISServer.Core.Client.Utilities.Serializer.ToJson(this.outline);
            }
            else
            {

            }
        }
    }
}

