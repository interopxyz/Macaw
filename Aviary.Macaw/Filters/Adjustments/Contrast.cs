using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Contrast : Filter
    {

        #region members

        protected int factor = 0;

        #endregion

        #region constructors

        public Contrast() : base()
        {
            SetFilter();
        }

        public Contrast(int factor) : base()
        {
            this.factor = factor;
            SetFilter();
        }

        public Contrast(Contrast filter) : base(filter)
        {
            this.factor = filter.factor;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Factor
        {
            get { return factor; }
            set
            {
                factor = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.ContrastCorrection newFilter = new Af.ContrastCorrection();
            newFilter.Factor = factor;
            imageFilter = newFilter;
        }

        #endregion

    }
}
