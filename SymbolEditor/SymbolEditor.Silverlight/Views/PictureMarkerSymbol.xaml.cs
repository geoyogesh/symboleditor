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
using System.Windows.Media.Imaging;
using System.IO;


namespace SymbolEditor.Silverlight.Views
{
    public partial class PictureMarkerSymbol : Page
    {
        GISServer.Core.Client.Symbols.PictureMarkerSymbol picturemarkersymbol;
        public PictureMarkerSymbol()
        {
            InitializeComponent();

            picturemarkersymbol = new GISServer.Core.Client.Symbols.PictureMarkerSymbol();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void txttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            picturemarkersymbol.Type = (sender as TextBox).Text;
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        private void txturl_TextChanged(object sender, TextChangedEventArgs e)
        {
            picturemarkersymbol.Url = (sender as TextBox).Text;
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        

        private void txtcontenttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            picturemarkersymbol.ContentType = (sender as TextBox).Text;
            txtjson.Text = picturemarkersymbol.ToJSON();
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
                    picturemarkersymbol.Color = w.Color;
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
                    txtjson.Text = picturemarkersymbol.ToJSON();
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
                picturemarkersymbol.Width = output;
            }
            else
            {

            }
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        private void txtheight_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                picturemarkersymbol.Height = output;
            }
            else
            {

            }
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        private void txtangle_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                picturemarkersymbol.Angle = output;
            }
            else
            {

            }
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        private void txtxoffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                picturemarkersymbol.Xoffset = output;
            }
            else
            {

            }
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        private void txtyoffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                picturemarkersymbol.Yoffset = output;
            }
            else
            {

            }
            txtjson.Text = picturemarkersymbol.ToJSON();
        }

        //reference http://silverlightsnippets.blogspot.com/2010/02/browse-image-and-drag-it-silverlight.html
        private void imgimagedata_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var imgcontrol = (sender as Image);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files (*.*)|*.*";
            ofd.FilterIndex = 1;
            if ((bool)ofd.ShowDialog())
            {
                ofd.FilterIndex = 1;
                using (FileStream stream = ofd.File.OpenRead())
                {
                    Byte[] bytes = new Byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    var base64encodedstr = Convert.ToBase64String(bytes);

                    //BitmapImage imgSrc = new BitmapImage();
                    //imgSrc.SetSource(stream);
                    //imgcontrol.Source = imgSrc;

                    imgcontrol.Source = SymbolEditor.Silverlight.Tasks.EncodeImage.Base64ToImage(base64encodedstr);
                    picturemarkersymbol.ImageData = base64encodedstr;
                    txtjson.Text = picturemarkersymbol.ToJSON();
                }
            }
            else
            {
                //
            }
        }

    }
}
