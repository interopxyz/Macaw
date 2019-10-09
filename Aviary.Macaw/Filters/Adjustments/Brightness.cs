using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af=Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Brightness : Filter
    {

        #region members

        protected int adjust = 0;

        #endregion

        #region constructors

        public Brightness() : base()
        {
            SetFilter();
        }

        public Brightness(int adjust) : base()
        {
            this.adjust = adjust;
            SetFilter();
        }

        public Brightness(Brightness filter) : base(filter)
        {
            this.adjust = filter.adjust;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Adjust
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
            Af.BrightnessCorrection newFilter = new Af.BrightnessCorrection();
            newFilter.AdjustValue = adjust;
            imageFilter = newFilter;
        }

        #endregion

    }
}
