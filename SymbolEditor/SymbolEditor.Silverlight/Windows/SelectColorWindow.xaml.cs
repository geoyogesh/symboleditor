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
    public partial class SelectColorWindow : ChildWindow
    {
        public List<byte> Color { get; set; }
        public SelectColorWindow()
        {
            InitializeComponent();
        }

        public SelectColorWindow(List<byte> Color)
        {
            InitializeComponent();
            this.Color = Color;

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
            reccolor.Fill = colorbrush;
            colorchooser.R = Color[0];
            colorchooser.G = Color[1];
            colorchooser.B = Color[2];
            colorchooser.A = Color[3];
            txtjson.Text = GISServer.Core.Client.Utilities.Serializer.ToJson(Color);
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

            Color = new List<byte>(
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
            reccolor.Fill = colorbrush;
            txtjson.Text = GISServer.Core.Client.Utilities.Serializer.ToJson(Color);
        }
    }
}

