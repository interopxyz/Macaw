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
    public class HSL : Filter
    {

        #region members

        protected Color color = Color.Black;

        protected Domain hue = new Domain(0, 1);
        protected Domain saturation = new Domain(0, 1);
        protected Domain luminance = new Domain(0, 1);

        protected bool outside = false;

        #endregion

        #region constructors

        public HSL() : base()
        {
            SetFilter();
        }

        public HSL(Domain hue, Domain saturation, Domain luminance, bool outside, Color color) : base()
        {
            this.hue = hue;
            this.saturation = saturation;
            this.luminance = luminance;

            this.outside = outside;

            this.color = color;

            SetFilter();
        }

        public HSL(HSL filter) : base(filter)
        {
            this.hue = filter.hue;
            this.saturation = filter.saturation;
            this.luminance = filter.luminance;

            this.outside = filter.outside;

            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Domain Hue
        {
            get { return hue; }
            set
            {
                hue = value;
                SetFilter();
            }
        }

        public virtual Domain Saturation
        {
            get { return saturation; }
            set
            {
                saturation = value;
                SetFilter();
            }
        }

        public virtual Domain Luminance
        {
            get { return luminance; }
            set
            {
                luminance = value;
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

            newFilter.Hue = new Accord.IntRange((int)Remap(hue.T0,0,359), (int)Remap(hue.T1, 0, 359));
            newFilter.Saturation = new Accord.Range((float)saturation.T0, (float)saturation.T1);
            newFilter.Luminance = new Accord.Range((float)luminance.T0, (float)luminance.T1);

            newFilter.FillOutsideRange = outside;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: HSL Filtering";
        }

        #endregion

    }
}