using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sd = System.Drawing;
using Si = System.Windows.Media.Imaging;
using Sw = System.Windows.Interop;

using Di = SoundInTheory.DynamicImage;
using Ds = SoundInTheory.DynamicImage.Sources;
using System.Windows;
using System.IO;

namespace Aviary.Macaw
{
    public static class BitmapExtensions
    {

        #region fromBitmap

        public static Di.Sources.ImageImageSource ToImageImageSource(this Sd.Bitmap input)
        {
            Ds.ImageImageSource output = new Ds.ImageImageSource();
            output.Image = input.ToWriteableBitmap();

            return output;
        }

        public static Si.WriteableBitmap ToWriteableBitmap(this Sd.Bitmap input)
        {
            return new Si.WriteableBitmap(input.ToBitmapSource());
        }

        public static Si.BitmapSource ToBitmapSource(this Sd.Bitmap input)
        {
            Si.BitmapSource output = Sw.Imaging.CreateBitmapSourceFromHBitmap(input.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, Si.BitmapSizeOptions.FromEmptyOptions());

            return output;
        }

        #endregion

        #region toBitmap

        public static Sd.Bitmap ToBitmap(this Si.BitmapSource input)
        {
            Sd.Bitmap output = new Sd.Bitmap(10, 10);
            using (MemoryStream outStream = new MemoryStream())
            {
                Si.PngBitmapEncoder enc = new Si.PngBitmapEncoder();

                enc.Frames.Add(Si.BitmapFrame.Create(input));
                enc.Save(outStream);
                output = new Sd.Bitmap(outStream);
            }

            return output;
        }

        #endregion

    }
}
