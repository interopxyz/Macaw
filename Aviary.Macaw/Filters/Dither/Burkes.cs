using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Dither
{
    public class Burkes : Filter
    {

        #region members

        protected int threshold = 1;

        #endregion

        #region constructors

        public Burkes() : base()
        {
            SetFilter();
        }

        public Burkes(int threshold) : base()
        {
            this.threshold = threshold;
            SetFilter();
        }

        public Burkes(Burkes filter) : base(filter)
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
            Af.BurkesDithering newFilter = new Af.BurkesDithering();
            newFilter.ThresholdValue = (byte)threshold;
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Dither Burkes";
        }

        #endregion

    }
}