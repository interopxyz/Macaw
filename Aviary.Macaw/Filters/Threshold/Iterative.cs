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
        
        protected double minimum = 1;
        protected double threshold = 1;

        #endregion

        #region constructors

        public Iterative() : base()
        {
            SetFilter();
        }

        public Iterative(double minimum, double threshold) : base()
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
        
        public virtual double Minimum
        {
            get { return minimum; }
            set
            {
                minimum = value;
                SetFilter();
            }
        }
        public virtual double Threshold
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
            ImageType = ImageTypes.GrayscaleBT709;
            Af.IterativeThreshold newFilter = new Af.IterativeThreshold();
            newFilter.MinimumError = (int)Remap(minimum, 0, 10);
            newFilter.ThresholdValue = (int)Remap(threshold, 0, 255);

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Iterative Threshold";
        }

        #endregion

    }
}