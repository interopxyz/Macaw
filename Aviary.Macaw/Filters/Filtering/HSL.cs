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
    public class HSL : Filter
    {

        #region members

        protected Color color = Color.Black;

        protected double  hueLow = 0;
        protected double  hueHigh = 1.0;
                   
        protected double  saturationLow = 0;
        protected double  saturationHigh = 1.0;
                   
        protected double  luminanceLow = 0;
        protected double  luminanceHigh = 1.0;

        protected bool outside = false;

        #endregion

        #region constructors

        public HSL() : base()
        {
            SetFilter();
        }

        public HSL(double hueLow, double hueHigh, double saturationLow, double saturationHigh, double luminanceLow, double luminanceHigh, bool outside, Color color) : base()
        {
            this.hueLow = hueLow;
            this.hueHigh = hueHigh;
            this.saturationLow = saturationLow;
            this.saturationHigh = saturationHigh;
            this.luminanceLow = luminanceLow;
            this.luminanceHigh = luminanceHigh;

            this.outside = outside;

            this.color = color;

            SetFilter();
        }

        public HSL(HSL filter) : base(filter)
        {
            this.hueLow = filter.hueLow;
            this.hueHigh = filter.hueHigh;
            this.saturationLow = filter.saturationLow;
            this.saturationHigh = filter.saturationHigh;
            this.luminanceLow = filter.luminanceLow;
            this.luminanceHigh = filter.luminanceHigh;

            this.outside = filter.outside;

            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual double HueLow
        {
            get { return hueLow; }
            set
            {
                hueLow = value;
                SetFilter();
            }
        }

        public virtual double HueHigh
        {
            get { return hueHigh; }
            set
            {
                hueHigh = value;
                SetFilter();
            }
        }

        public virtual double SaturationLow
        {
            get { return saturationLow; }
            set
            {
                saturationLow = value;
                SetFilter();
            }
        }

        public virtual double SaturationHigh
        {
            get { return saturationHigh; }
            set
            {
                saturationHigh = value;
                SetFilter();
            }
        }

        public virtual double LuminanceLow
        {
            get { return luminanceLow; }
            set
            {
                luminanceLow = value;
                SetFilter();
            }
        }

        public virtual double LuminanceHigh
        {
            get { return luminanceHigh; }
            set
            {
                luminanceHigh = value;
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
            Af.HSLFiltering newFilter = new Af.HSLFiltering();

            newFilter.FillColor = Accord.Imaging.HSL.FromRGB(new Accord.Imaging.RGB(color));

            newFilter.Hue = new Accord.IntRange((int)(359.0*hueLow), (int)(359.0 * hueHigh));
            newFilter.Saturation = new Accord.Range((float)saturationLow, (float)saturationHigh);
            newFilter.Luminance = new Accord.Range((float)luminanceLow, (float)luminanceHigh);

            newFilter.FillOutsideRange = outside;

            imageFilter = newFilter;
        }

        #endregion

    }
}