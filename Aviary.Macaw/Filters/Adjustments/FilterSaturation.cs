using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterSaturation : Filter
    {

        #region members

        protected double adjust = 0;

        #endregion

        #region constructors

        public FilterSaturation() : base()
        {
            SetFilter();
        }

        public FilterSaturation(double adjust) : base()
        {
            this.adjust = adjust;
            SetFilter();
        }

        public FilterSaturation(FilterSaturation filter) : base(filter)
        {
            this.adjust = filter.adjust;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Adjust
        {
            get { return adjust; }
            set
            {
                adjust = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            SaturationCorrection newFilter = new SaturationCorrection();
            newFilter.AdjustValue = (float)adjust;
            imageFilter = newFilter;
        }

        #endregion

    }
}
