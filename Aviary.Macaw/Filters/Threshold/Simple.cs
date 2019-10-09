using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Threshold
{
    public class Simple : Filter
    {

        #region members
        
        protected int threshold = 1;

        #endregion

        #region constructors

        public Simple() : base()
        {
            SetFilter();
        }

        public Simple(int threshold) : base()
        {
            this.threshold = threshold;
            SetFilter();
        }

        public Simple(Simple filter) : base(filter)
        {
            this.threshold = filter.threshold;
            SetFilter();
        }

        #endregion

        #region properties

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
            Af.Threshold newFilter = new Af.Threshold();
            newFilter.ThresholdValue = threshold;

            imageFilter = newFilter;
        }

        #endregion

    }
}