using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterBlur : Filter
    {

        #region members

        protected int divisor = 0;
        protected int threshold = 0;

        #endregion

        #region constructors

        public FilterBlur() : base()
        {
            SetFilter();
        }

        public FilterBlur(int divisor, int threshold) : base()
        {
            this.divisor = divisor;
            this.threshold = threshold;
            SetFilter();
        }

        public FilterBlur(FilterBlur filter) : base(filter)
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
            Blur newFilter = new Blur();
            newFilter.Divisor = divisor;
            newFilter.Threshold = threshold;
            imageFilter = newFilter;
        }

        #endregion

    }
}