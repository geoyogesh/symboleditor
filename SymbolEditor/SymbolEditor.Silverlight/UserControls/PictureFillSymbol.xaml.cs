﻿using System;
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
using System.IO;

namespace SymbolEditor.Silverlight.UserControls
{
    public partial class PictureFillSymbol : UserControl
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
                    picturemarkersymbol = (GISServer.Core.Client.Symbols.PictureFillSymbol)GISServer.Core.Client.Utilities.ConvertSymbol.toJSON(value);
                    symbolstring = picturemarkersymbol.ToJSON();
                    UpdateUI(picturemarkersymbol);
                }
                catch (Exception)
                {

                }
            }
        }

        private void UpdateUI(GISServer.Core.Client.Symbols.PictureFillSymbol picturemarkersymbol)
        {
            txttype.Text = picturemarkersymbol.Type;
            txturl.Text = picturemarkersymbol.Url;
            txtcontenttype.Text = picturemarkersymbol.ContentType;


            txtwidth.Text = picturemarkersymbol.Width.ToString();
            txtheight.Text = picturemarkersymbol.Height.ToString();
            txtangle.Text = picturemarkersymbol.Angle.ToString();
            txtxoffset.Text = picturemarkersymbol.Xoffset.ToString();
            txtyoffset.Text = picturemarkersymbol.Yoffset.ToString();
            txtxscale.Text = picturemarkersymbol.Xscale.ToString();
            txtyscale.Text = picturemarkersymbol.Yscale.ToString();


            var colorbrush = new SolidColorBrush
            {
                Color = new System.Windows.Media.Color
                {
                    R = picturemarkersymbol.Color[0],
                    G = picturemarkersymbol.Color[1],
                    B = picturemarkersymbol.Color[2],
                    A = picturemarkersymbol.Color[3]
                }
            };
            reccolor.Fill = colorbrush;


        }


        GISServer.Core.Client.Symbols.PictureFillSymbol picturemarkersymbol;
        public PictureFillSymbol()
        {
            picturemarkersymbol = new GISServer.Core.Client.Symbols.PictureFillSymbol();
            InitializeComponent();

            UpdateJSONforInitialUI();
        }

        private void UpdateJSONforInitialUI()
        {
            picturemarkersymbol.Type = txttype.Text;
            picturemarkersymbol.Url = txturl.Text;
            picturemarkersymbol.ImageData = @"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";
            picturemarkersymbol.ContentType = txtcontenttype.Text;
            var initialcolor = (reccolor.Fill as SolidColorBrush).Color;
            picturemarkersymbol.Color = new List<byte>(
                    new byte[] { initialcolor.R, initialcolor.G, initialcolor.B, initialcolor.A }
                );
            picturemarkersymbol.Width = Double.Parse(txtwidth.Text);
            picturemarkersymbol.Height = Double.Parse(txtheight.Text);
            picturemarkersymbol.Angle = Double.Parse(txtangle.Text);
            picturemarkersymbol.Xoffset = Double.Parse(txtxoffset.Text);
            picturemarkersymbol.Yoffset = Double.Parse(txtyoffset.Text);
            picturemarkersymbol.Xscale = Double.Parse(txtxscale.Text);
            picturemarkersymbol.Yscale = Double.Parse(txtyscale.Text);
            UpdateJson();
        }

        private void UpdateJson()
        {
            symbolstring = picturemarkersymbol.ToJSON();
            SymbolStringChangedEventArgs newjsonstring = new SymbolStringChangedEventArgs(symbolstring);
            JsonStringChanged(newjsonstring);
        }

       
        private void txttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            picturemarkersymbol.Type = (sender as TextBox).Text;
             UpdateJson();
        }

        private void txturl_TextChanged(object sender, TextChangedEventArgs e)
        {
            picturemarkersymbol.Url = (sender as TextBox).Text;
             UpdateJson();
        }



        private void txtcontenttype_TextChanged(object sender, TextChangedEventArgs e)
        {
            picturemarkersymbol.ContentType = (sender as TextBox).Text;
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
                picturemarkersymbol.Width = output;
            }
            else
            {

            }
             UpdateJson();
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
             UpdateJson();
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
             UpdateJson();
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
             UpdateJson();
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
             UpdateJson();
        }

        private void txtxscale_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                picturemarkersymbol.Xscale = output;
            }
            else
            {

            }
             UpdateJson();
        }

        private void txtyscale_TextChanged(object sender, TextChangedEventArgs e)
        {
            double output;

            var isparsed = Double.TryParse((sender as TextBox).Text, out output);
            if (isparsed)
            {
                picturemarkersymbol.Yscale = output;
            }
            else
            {

            }
             UpdateJson();
        }

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
                     UpdateJson();
                }
            }
            else
            {
                //
            }
        }

        
    }
}
