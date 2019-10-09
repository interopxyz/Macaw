using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class Iterative : Filter
    {

        #region members
        
        protected int minimum = 1;
        protected int threshold = 1;

        #endregion

        #region constructors

        public Iterative() : base()
        {
            SetFilter();
        }

        public Iterative(int minimum, int threshold) : base()
        {
            this.minimum = minimum;
            this.threshold = threshold;

            SetFilter();
        }

        public Iterative(Iterative filter) : base(filter)
        {
            this.minimum = filter.minimum;
            this.threshold = filter.threshold;

            SetFilter();
        }

        #endregion

        #region properties
        
        public virtual int Minimum
        {
            get { return minimum; }
            set
            {
                minimum = value;
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
            ImageType = ImageTypes.Rgb24bpp;
            Af.IterativeThreshold newFilter = new Af.IterativeThreshold();
            newFilter.MinimumError = minimum;
            newFilter.ThresholdValue = threshold;

            imageFilter = newFilter;
        }

        #endregion

    }
}