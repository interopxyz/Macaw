using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterColorFiltering : Filter
    {

        #region members

        protected Color color = Color.Black;

        protected double redLow = 0;
        protected double redHigh = 255;
                  
        protected double greenLow = 0;
        protected double greenHigh = 255;
                  
        protected double blueLow = 0;
        protected double blueHigh = 255;

        protected bool outside = false;

        #endregion

        #region constructors

        public FilterColorFiltering() : base()
        {
            SetFilter();
        }

        public FilterColorFiltering(double redLow, double redHigh, double greenLow, double greenHigh, double blueLow, double blueHigh, bool outside, Color color) : base()
        {
            this.redLow = redLow;
            this.redHigh = redHigh;
            this.greenLow = greenLow;
            this.greenHigh = greenHigh;
            this.blueLow = blueLow;
            this.blueHigh = blueHigh;

            this.outside = outside;

            this.color = color;

            SetFilter();
        }

        public FilterColorFiltering(FilterColorFiltering filter) : base(filter)
        {
            this.redLow = filter.redLow;
            this.redHigh = filter.redHigh;
            this.greenLow = filter.greenLow;
            this.greenHigh = filter.greenHigh;
            this.blueLow = filter.blueLow;
            this.blueHigh = filter.blueHigh;

            this.outside = filter.outside;

            this.color = filter.color;

            SetFilter();
        }

        #endregion

        #region properties

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

        public virtual double GreenLow
        {
            get { return greenLow; }
            set
            {
                greenLow = value;
                SetFilter();
            }
        }

        public virtual double GreenHigh
        {
            get { return greenHigh; }
            set
            {
                greenHigh = value;
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
            ColorFiltering newFilter = new ColorFiltering();

            newFilter.FillColor = new Accord.Imaging.RGB(color);

            newFilter.Red = new Accord.IntRange((int)(255.0*redLow), (int)(255.0 * redHigh));
            newFilter.Green = new Accord.IntRange((int)(255.0 * greenLow), (int)(255.0 * greenHigh));
            newFilter.Blue = new Accord.IntRange((int)(255.0 * blueLow), (int)(255.0 * blueHigh));

            newFilter.FillOutsideRange = outside;

            imageFilter = newFilter;
        }

        #endregion

    }
}