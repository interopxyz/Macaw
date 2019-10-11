using Aviary.Wind.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Filtering
{
    public class ColorFilter : Filter
    {

        #region members

        protected Color color = Color.Black;

        protected Domain red = new Domain(0, 1);
        protected Domain green = new Domain(0, 1);
        protected Domain blue = new Domain(0, 1);

        protected bool outside = false;

        #endregion

        #region constructors

        public ColorFilter() : base()
        {
            SetFilter();
        }

        public ColorFilter(Domain red, Domain green, Domain blue, bool outside, Color color) : base()
        {

            this.red = red;
            this.green = green;
            this.blue = blue;

            this.outside = outside;

            this.color = color;

            SetFilter();
        }

        public ColorFilter(ColorFilter filter) : base(filter)
        {

            this.red = filter.red;
            this.green = filter.green;
            this.blue = filter.blue;

            this.outside = filter.outside;

            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Domain Red
        {
            get { return red; }
            set
            {
                red = value;
                SetFilter();
            }
        }

        public virtual Domain Green
        {
            get { return green; }
            set
            {
                green = value;
                SetFilter();
            }
        }

        public virtual Domain Blue
        {
            get { return blue; }
            set
            {
                blue = value;
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
            Af.ColorFiltering newFilter = new Af.ColorFiltering();

            newFilter.FillColor = new Accord.Imaging.RGB(color);

            newFilter.Red =   new Accord.IntRange((int)Remap(red.T0,0,255), (int)Remap(red.T1, 0, 255));
            newFilter.Green = new Accord.IntRange((int)Remap(green.T0, 0, 255), (int)Remap(green.T1, 0, 255));
            newFilter.Blue =  new Accord.IntRange((int)Remap(blue.T0, 0, 255), (int)Remap(blue.T1, 0, 255));

            newFilter.FillOutsideRange = outside;

            imageFilter = newFilter;
        }

        #endregion

    }
}