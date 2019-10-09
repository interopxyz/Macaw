using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af=Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Smoothing
{
    public class Mean : Filter
    {

        #region members

        protected int divisor = 1;
        protected int threshold = 0;

        #endregion

        #region constructors

        public Mean() : base()
        {
            SetFilter();
        }

        public Mean(int divisor, int threshold) : base()
        {
            this.divisor = divisor;
            this.threshold = threshold;
            SetFilter();
        }

        public Mean(Mean filter) : base(filter)
        {
            this.divisor = filter.divisor;
            this.threshold = filter.threshold;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Divisor
        {
            get { return divisor; }
            set
            {
                divisor = value;
                SetFilter();
            }
        }

        public virtual int Threshold
        {
            get { return threshold; }
            set
            {
                threshold = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.Mean newFilter = new Af.Mean();
            newFilter.Divisor = divisor;
            newFilter.Threshold = threshold;
            imageFilter = newFilter;
        }

        #endregion

    }
}
