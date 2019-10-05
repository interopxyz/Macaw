using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class Blur : Filter
    {

        #region members

        protected int divisor = 0;
        protected int threshold = 0;

        #endregion

        #region constructors

        public Blur() : base()
        {
            SetFilter();
        }

        public Blur(int divisor, int threshold) : base()
        {
            this.divisor = divisor;
            this.threshold = threshold;
            SetFilter();
        }

        public Blur(Blur filter) : base(filter)
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
            Accord.Imaging.Filters.Blur newFilter = new Accord.Imaging.Filters.Blur();
            newFilter.Divisor = divisor;
            newFilter.Threshold = threshold;
            imageFilter = newFilter;
        }

        #endregion

    }
}