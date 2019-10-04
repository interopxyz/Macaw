using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterGamma : Filter
    {

        #region members

        protected double gamma = 0;

        #endregion

        #region constructors

        public FilterGamma() : base()
        {
            SetFilter();
        }

        public FilterGamma(double gamma) : base()
        {
            this.gamma = gamma;
            SetFilter();
        }

        public FilterGamma(FilterGamma filter) : base(filter)
        {
            this.gamma = filter.gamma;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Gamma
        {
            get { return gamma; }
            set
            {
                gamma = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            GammaCorrection newFilter = new GammaCorrection();
            newFilter.Gamma = gamma;
            imageFilter = newFilter;
        }

        #endregion

    }
}
