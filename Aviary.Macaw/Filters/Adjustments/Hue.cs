using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Hue : Filter
    {

        #region members

        protected double hue = 0;

        #endregion

        #region constructors

        public Hue() : base()
        {
            SetFilter();
        }

        public Hue(double hue) : base()
        {
            this.hue = hue;
            SetFilter();
        }

        public Hue(Hue filter) : base(filter)
        {
            this.hue = filter.hue;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Factor
        {
            get { return hue; }
            set
            {
                hue = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.HueModifier newFilter = new Af.HueModifier();
            newFilter.Hue = (int)Remap(hue, 0, 359);
            imageFilter = newFilter;
        }

        #endregion

    }
}
