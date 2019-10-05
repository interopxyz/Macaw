using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class Gamma : Filter
    {

        #region members

        protected double gamma = 0;

        #endregion

        #region constructors

        public Gamma() : base()
        {
            SetFilter();
        }

        public Gamma(double gamma) : base()
        {
            this.gamma = gamma;
            SetFilter();
        }

        public Gamma(Gamma filter) : base(filter)
        {
            this.gamma = filter.gamma;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double GammaValue
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
