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

        public enum ImageTypes { GrayscaleBT709, GrayscaleRMY, GrayscaleY, GrayScale16bpp, Rgb16bpp, Rgb24bpp, None };
        public ImageTypes ImageType = ImageTypes.Rgb24bpp;

        protected Bitmap bitmap = new Bitmap(100, 100);
        public List<Filter> Filters = new List<Filter>();

        #endregion

        #region constructors

        public Image()
        {

        }

        public Image(Image image)
        {
            this.Bitmap = image.bitmap;
            this.ImageType = image.ImageType;
            foreach(Filter filter in image.Filters)
            {
                this.Filters.Add(new Filter(filter));
            }
        }

        public Image(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
        }

        #endregion

        #region properties

        public virtual Bitmap Bitmap
        {
            get { return (Bitmap)bitmap.Clone(); }
            set { bitmap = (Bitmap)value.Clone(); }
        }

        #endregion

        #region members

        public Bitmap GetFilteredBitmap()
        {
            Af.FiltersSequence sequence = new Af.FiltersSequence();
            foreach(Filter filter in Filters)
            {
                sequence.Add(filter.FilterObject);
            }



            return sequence.Apply(this.Bitmap);

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
