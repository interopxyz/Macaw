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

        protected double factor = 0.5;

        #endregion

        #region constructors

        public Contrast() : base()
        {
            SetFilter();
        }

        public Contrast(double factor) : base()
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

        public virtual double Factor
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
            newFilter.Factor = (int)Remap(factor, -127, 127); ;
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Contrast";
        }

        #endregion

    }
}
