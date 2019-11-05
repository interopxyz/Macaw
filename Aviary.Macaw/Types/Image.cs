using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw
{
    public class Image
    {

        #region members

        protected Bitmap bitmap = new Bitmap(100, 100);
        public List<Filter> Filters = new List<Filter>();
        public enum Channels { Alpha, Red, Green, Blue, Hue, Saturation, Luminance };

        #endregion

        #region constructors

        public Image()
        {

        }

        public Image(Image image)
        {
            this.Bitmap = image.bitmap;
            foreach (Filter filter in image.Filters)
            {
                this.Filters.Add(new Filter(filter));
            }
        }

        public Image(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
        }

        public Image(Bitmap bitmap, Filter filter)
        {
            this.Bitmap = bitmap;
            this.Filters.Add(new Filter(filter));
        }

        #endregion

        #region properties

        public virtual Bitmap Bitmap
        {
            get { return (Bitmap)bitmap.Clone(); }
            set { bitmap = (Bitmap)value.Clone(); }
        }

        #endregion

        #region methods

        public Bitmap GetFilteredBitmap(int iterations = 0)
        {
            if (Filters.Count == 0)
            {
                return Bitmap;
            }
            else
            {
                Filter.ImageTypes imageType = Filter.ImageTypes.ARgb32bpp;

                Af.FiltersSequence sequence = new Af.FiltersSequence();
            foreach (Filter filter in Filters)
            {
                sequence.Add(filter.FilterObject);
                if (filter.ImageType < imageType) imageType = filter.ImageType;
            }

            if (iterations > 0)
            {
                return new Af.FilterIterator(sequence, iterations).Apply(this.bitmap.ToAccordBitmap(imageType));
            }
            else
            {
                return sequence.Apply(this.Bitmap.ToAccordBitmap(imageType));
            }
        }
        }

        public void BuildBitmap(List<Color> colors, int width = 100, int height = 100)
        {
            Bitmap bmp = new Bitmap(width, height);
            int k = 0;
            int c = colors.Count;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    k = (i * width + j) % c;
                    bitmap.SetPixel(j, i, colors[k]);
                }
            }
            this.bitmap = bmp;
        }

        public void SwapChannel(Channels source, Channels target)
        {
            Dictionary<string, List<int>> channels = GetValueDictionary();

            List<int> colors = channels[source.ToString()];
            channels[target.ToString()] = colors;

            Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height);

            int k = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(channels["Alpha"][k], channels["Red"][k], channels["Green"][k], channels["Blue"][k]));
                    k += 1;
                }
            }

            this.bitmap = bmp;
        }

        public void SwapChannels(Channels alpha, Channels red, Channels green, Channels blue)
        {
            Dictionary<string, List<int>> channels = GetValueDictionary();

            List<int> alphas = channels[alpha.ToString()];
            List<int> reds = channels[red.ToString()];
            List<int> greens = channels[green.ToString()];
            List<int> blues = channels[blue.ToString()];

            Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height);

            int k = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(alphas[k], reds[k], greens[k], blues[k]));
                    k += 1;
                }
            }

            bitmap = bmp;
        }

        public Dictionary<string, List<int>> GetValueDictionary()
        {

            Dictionary<string, List<int>> channels = new Dictionary<string, List<int>>();
            channels.Add("Alpha", new List<int>());
            channels.Add("Red", new List<int>());
            channels.Add("Green", new List<int>());
            channels.Add("Blue", new List<int>());
            channels.Add("Hue", new List<int>());
            channels.Add("Saturation", new List<int>());
            channels.Add("Luminance", new List<int>());

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    channels["Alpha"].Add(bitmap.GetPixel(i, j).A);
                    channels["Red"].Add(bitmap.GetPixel(i, j).R);
                    channels["Green"].Add(bitmap.GetPixel(i, j).G);
                    channels["Blue"].Add(bitmap.GetPixel(i, j).B);
                    channels["Hue"].Add((int)(255.0 * bitmap.GetPixel(i, j).GetHue() / 360.0));
                    channels["Saturation"].Add((int)(255.0 * bitmap.GetPixel(i, j).GetSaturation()));
                    channels["Luminance"].Add((int)(255.0 * bitmap.GetPixel(i, j).GetBrightness()));
                }
            }

            return channels;
        }

        #endregion

        #region overrides

        public override string ToString()
        {
            string text = "Image(" + bitmap.Width + "," + bitmap.Height + ")";
            if (Filters.Count > 0) text += ("[" + Filters.Count + " filters]");
            return text;
        }

        #endregion

    }
}
