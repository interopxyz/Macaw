using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Saturation : Filter
    {

        #region members

        protected double adjust = 0;

        #endregion

        #region constructors

        public Saturation() : base()
        {
            SetFilter();
        }

        public Saturation(double adjust) : base()
        {
            this.adjust = adjust;
            SetFilter();
        }

        public Saturation(Saturation filter) : base(filter)
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
            Af.SaturationCorrection newFilter = new Af.SaturationCorrection();
            newFilter.AdjustValue = (float)Remap(adjust,-1.0,1.0);
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Saturation";
        }

        #endregion

    }
}
