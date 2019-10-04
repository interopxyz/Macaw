using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterHue : Filter
    {

        #region members

        protected int hue = 0;

        #endregion

        #region constructors

        public FilterHue() : base()
        {
            SetFilter();
        }

        public FilterHue(int hue) : base()
        {
            this.hue = hue;
            SetFilter();
        }

        public FilterHue(FilterHue filter) : base(filter)
        {
            this.hue = filter.hue;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Factor
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
            HueModifier newFilter = new HueModifier();
            newFilter.Hue = hue;
            imageFilter = newFilter;
        }

        #endregion

    }
}
