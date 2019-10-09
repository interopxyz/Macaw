using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class Nilback : Filter
    {

        #region members

        protected double c = 1.0;
        protected double k = 1.0;
        protected int radius = 1;

        #endregion

        #region constructors

        public Nilback() : base()
        {
            SetFilter();
        }

        public Nilback(double c, double k, int radius) : base()
        {
            this.c = c;
            this.k = k;
            this.radius = radius;

            SetFilter();
        }

        public Nilback(Nilback filter) : base(filter)
        {
            this.c = filter.c;
            this.k = filter.k;
            this.radius = filter.radius;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual double C
        {
            get { return c; }
            set
            {
                c = value;
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
            Af.NiblackThreshold newFilter = new Af.NiblackThreshold();
            newFilter.K = k;
            newFilter.C = c;
            newFilter.Radius = radius;

            imageFilter = newFilter;
        }

        #endregion

    }
}