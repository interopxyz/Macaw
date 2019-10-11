using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging;
using Aviary.Wind.Mathematics;
using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Filtering
{
    public class YCbCr : Filter
    {

        #region members

        protected Color color = Color.Black;

        protected Domain y = new Domain(0,1);
        protected Domain cb = new Domain(0, 1);
        protected Domain cr = new Domain(0, 1);

        protected bool outside = false;

        #endregion

        #region constructors

        public YCbCr() : base()
        {
            SetFilter();
        }

        public YCbCr(Domain y, Domain cb, Domain cr, bool outside, Color color) : base()
        {
            this.y = y;
            this.cb = cb;
            this.cr = cr;

            this.outside = outside;

            this.color = color;

            SetFilter();
        }

        public YCbCr(YCbCr filter) : base(filter)
        {
            this.y = filter.y;
            this.cb = filter.cb;
            this.cr = filter.cr;

            this.outside = filter.outside;

            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Domain Y
        {
            get { return y; }
            set
            {
                y = value;
                SetFilter();
            }
        }

        public virtual Domain Cr
        {
            get { return cr; }
            set
            {
                cr = value;
                SetFilter();
            }
        }

        public virtual Domain Cb
        {
            get { return cb; }
            set
            {
                cb = value;
                SetFilter();
            }
        }

        public virtual Color Color
        {
            get { return color; }
            set
            {
                color = value;
                SetFilter();
            }
        }

        public virtual bool Outside
        {
            get { return outside; }
            set
            {
                outside = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.YCbCrFiltering newFilter = new Af.YCbCrFiltering();

            newFilter.FillColor = Accord.Imaging.YCbCr.FromRGB(new Accord.Imaging.RGB(color));

            newFilter.Y = new Accord.Range((float)y.T0, (float)y.T1);
            newFilter.Cb = new Accord.Range((float)Remap(cb.T0,-0.5,0.5), (float)Remap(cb.T1, -0.5, 0.5));
            newFilter.Cr = new Accord.Range((float)Remap(cr.T0, -0.5, 0.5), (float)Remap(cr.T1, -0.5, 0.5));

            newFilter.FillOutsideRange = outside;

            imageFilter = newFilter;
        }

        #endregion

    }
}
