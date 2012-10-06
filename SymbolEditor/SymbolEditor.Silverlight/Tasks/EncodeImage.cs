using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Imaging;
using System.Text;

namespace SymbolEditor.Silverlight.Tasks
{
    public static class EncodeImage
    {
        //http://stackoverflow.com/questions/2445449/silverlight-4-0-how-to-convert-byte-to-image
        public static BitmapImage Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0,
          imageBytes.Length))
            {
                BitmapImage im = new BitmapImage();
                im.SetSource(ms);
                return im;
            }
        }

        //http://stackoverflow.com/questions/1958470/silverlight-image-to-byte
        //public static string ImageToBase64(BitmapImage source)
        //{
        //    byte[] imgAsByteArray = null;

        //    if (source != null)
        //    {
        //        imgAsByteArray = (new WriteableBitmap((BitmapSource)source)).Pixels.SelectMany(p => new byte[] 
        //    { 

        //        ( byte )  p        , 
        //        ( byte )( p >> 8  ), 
        //        ( byte )( p >> 16 ), 
        //        ( byte )( p >> 24 ) 

        //    }).ToArray();
        //    }
        //    return Convert.ToBase64String(imgAsByteArray);
        //}




    }
}
