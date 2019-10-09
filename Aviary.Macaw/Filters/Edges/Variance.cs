using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Variance : Filter
    {

        #region members

        protected int radius = 1;
        bool fast = false;

        #endregion

        #region constructors

        public Variance() : base()
        {
            SetFilter();
        }

        public Variance(int radius, bool fast) : base()
        {
            this.radius = radius;
            this.fast = fast;

            SetFilter();
        }

        public Variance(Variance filter) : base(filter)
        {
            this.radius = filter.radius;
            this.fast = filter.fast;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                SetFilter();
            }
        }

        public virtual bool IsFast
        {
            get { return fast; }
            set
            {
                fast = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            if (fast)
            {
                ImageType = ImageTypes.Rgb24bpp;
                Af.FastVariance newFilter = new Af.FastVariance();
                newFilter.Radius = radius;
                imageFilter = newFilter;
            }
            else
            {
                ImageType = ImageTypes.Rgb24bpp;
                Af.Variance newFilter = new Af.Variance();
                newFilter.Radius = radius;
                imageFilter = newFilter;
            }

        }

        #endregion

    }
}