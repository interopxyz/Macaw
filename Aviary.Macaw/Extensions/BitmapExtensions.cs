using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sd = System.Drawing;
using Si = System.Windows.Media.Imaging;
using Sw = System.Windows.Interop;

using Ai = Accord.Imaging;

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

        public static Sd.Bitmap ToAccordBitmap(this Sd.Bitmap input, Filter.ImageTypes imageType)
        {
            switch(imageType)
            {
                default:
                    return (Sd.Bitmap)input.Clone();
                case Filter.ImageTypes.GrayScale16bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format16bppGrayScale);
                case Filter.ImageTypes.GrayscaleBT709:
                    if(input.PixelFormat != Sd.Imaging.PixelFormat.Format8bppIndexed)
                    {
                        return Ai.Filters.Grayscale.CommonAlgorithms.BT709.Apply((Sd.Bitmap)input.Clone());
                    }
                    else
                    {
                        return (Sd.Bitmap)input.Clone();
                    }
                case Filter.ImageTypes.GrayscaleRMY:
                    return Ai.Filters.Grayscale.CommonAlgorithms.RMY.Apply((Sd.Bitmap)input.Clone());
                case Filter.ImageTypes.GrayscaleY:
                    return Ai.Filters.Grayscale.CommonAlgorithms.Y.Apply((Sd.Bitmap)input.Clone());
                case Filter.ImageTypes.Rgb16bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format16bppRgb555);
                case Filter.ImageTypes.Rgb24bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format24bppRgb);
                case Filter.ImageTypes.Rgb32bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format32bppRgb);
                case Filter.ImageTypes.ARgb32bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format32bppArgb);
                case Filter.ImageTypes.Rgb48bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format48bppRgb);
                case Filter.ImageTypes.Rgb64bpp:
                    return Ai.Image.Clone(input, Sd.Imaging.PixelFormat.Format64bppArgb);
            }

        }

        #endregion

        #region getValues

        public static List<Sd.Color> GetColorValues(this Sd.Bitmap input)
        {
            List<Sd.Color> output = new List<Sd.Color>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i));
                }
            }

            return output;
        }

        public static List<int> GetAValues(this Sd.Bitmap input)
        {
            List<int> output = new List<int>();

            for(int i =0;i<input.Height;i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).A);
                }
            }

            return output;
        }

        public static List<int> GetRValues(this Sd.Bitmap input)
        {
            List<int> output = new List<int>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).R);
                }
            }

            return output;
        }

        public static List<int> GetGValues(this Sd.Bitmap input)
        {
            List<int> output = new List<int>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).G);
                }
            }

            return output;
        }

        public static List<int> GetBValues(this Sd.Bitmap input)
        {
            List<int> output = new List<int>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).B);
                }
            }

            return output;
        }

        public static List<double> GetHueValues(this Sd.Bitmap input)
        {
            List<double> output = new List<double>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).GetHue());
                }
            }

            return output;
        }

        public static List<double> GetSaturationValues(this Sd.Bitmap input)
        {
            List<double> output = new List<double>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).GetSaturation());
                }
            }

            return output;
        }

        public static List<double> GetBrightnessValues(this Sd.Bitmap input)
        {
            List<double> output = new List<double>();

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    output.Add(input.GetPixel(j, i).GetBrightness());
                }
            }

            return output;
        }

        #endregion

    }
}
