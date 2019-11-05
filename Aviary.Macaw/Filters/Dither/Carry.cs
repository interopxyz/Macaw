using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Dither
{
    public class Carry : Filter
    {

        #region members

        protected int threshold = 4;

        #endregion

        #region constructors

        public Carry() : base()
        {
            SetFilter();
        }

        public Carry(int threshold) : base()
        {
            this.threshold = threshold;
            SetFilter();
        }

        public Carry(Carry filter) : base(filter)
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
            ImageType = ImageTypes.GrayscaleBT709;
            Af.ThresholdWithCarry newFilter = new Af.ThresholdWithCarry();
            newFilter.ThresholdValue = (byte)threshold;
            imageFilter = newFilter;
        }

        #endregion

    }
}