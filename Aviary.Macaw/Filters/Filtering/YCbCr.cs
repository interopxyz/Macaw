using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging;
using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Filtering
{
    public class YCbCr : Filter
    {

        #region members

        protected Color color = Color.Black;

        protected double yLow = 0;
        protected double yHigh = 1.0;

        protected double blueLow = 0;
        protected double blueHigh = 1.0;

        protected double redLow = 0;
        protected double redHigh = 1.0;

        protected bool outside = false;

        #endregion

        #region constructors

        public YCbCr() : base()
        {
            SetFilter();
        }

        public YCbCr(double yLow, double yHigh, double blueLow, double blueHigh, double redLow, double redHigh, bool outside, Color color) : base()
        {
            this.yLow = yLow;
            this.yHigh = yHigh;
            this.blueLow = blueLow;
            this.blueHigh = blueHigh;
            this.redLow = redLow;
            this.redHigh = redHigh;

            this.outside = outside;

            this.color = color;

            SetFilter();
        }

        public YCbCr(YCbCr filter) : base(filter)
        {
            this.yLow = filter.yLow;
            this.yHigh = filter.yHigh;
            this.blueLow = filter.blueLow;
            this.blueHigh = filter.blueHigh;
            this.redLow = filter.redLow;
            this.redHigh = filter.redHigh;

            this.outside = filter.outside;

            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual double YLow
        {
            get { return yLow; }
            set
            {
                yLow = value;
                SetFilter();
            }
        }

        public virtual double YHigh
        {
            get { return yHigh; }
            set
            {
                yHigh = value;
                SetFilter();
            }
        }

        public virtual double BlueLow
        {
            get { return blueLow; }
            set
            {
                blueLow = value;
                SetFilter();
            }
        }

        public virtual double BlueHigh
        {
            get { return blueHigh; }
            set
            {
                blueHigh = value;
                SetFilter();
            }
        }

        public virtual double RedLow
        {
            get { return redLow; }
            set
            {
                redLow = value;
                SetFilter();
            }
        }

        public virtual double RedHigh
        {
            get { return redHigh; }
            set
            {
                redHigh = value;
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

            newFilter.Y = new Accord.Range((float)yLow, (float)yHigh);
            newFilter.Cb = new Accord.Range((float)(-0.5 + blueLow), (float)(-0.5 + blueHigh));
            newFilter.Cr = new Accord.Range((float)(-0.5 + redLow), (float)(-0.5 + redHigh));

            newFilter.FillOutsideRange = outside;

            imageFilter = newFilter;
        }

        #endregion

    }
}
