using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class Sauvola : Filter
    {

        #region members

        protected double r = 1.0;
        protected double k = 1.0;
        protected int radius = 1;

        #endregion

        #region constructors

        public Sauvola() : base()
        {
            SetFilter();
        }

        public Sauvola(double r, double k, int radius) : base()
        {
            this.r = r;
            this.k = k;
            this.radius = radius;

            SetFilter();
        }

        public Sauvola(Sauvola filter) : base(filter)
        {
            this.r = filter.r;
            this.k = filter.k;
            this.radius = filter.radius;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual double R
        {
            get { return r; }
            set
            {
                r = value;
                SetFilter();
            }
        }

        public virtual double K
        {
            get { return k; }
            set
            {
                k = value;
                SetFilter();
            }
        }

        public virtual int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.SauvolaThreshold newFilter = new Af.SauvolaThreshold();
            newFilter.K = k;
            newFilter.R = Remap(r, 0, 255);
            newFilter.Radius = radius;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Sauvola Threshold";
        }

        #endregion

    }
}