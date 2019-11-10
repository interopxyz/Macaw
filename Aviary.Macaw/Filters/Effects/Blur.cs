using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Blur : Filter
    {

        #region members

        protected double divisor = 0;
        protected double threshold = 0;

        #endregion

        #region constructors

        public Blur() : base()
        {
            SetFilter();
        }

        public Blur(double divisor, double threshold) : base()
        {
            this.divisor = divisor;
            this.threshold = threshold;
            SetFilter();
        }

        public Blur(Blur filter) : base(filter)
        {
            this.divisor = filter.divisor;
            this.threshold = filter.threshold;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Divisor
        {
            get { return divisor; }
            set
            {
                divisor = value;
                SetFilter();
            }
        }

        public virtual double Threshold
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
            ImageType = ImageTypes.Rgb32bpp;
            Af.Blur newFilter = new Af.Blur();
            newFilter.Divisor = (int)Remap(Math.Abs(divisor),1,100);
            newFilter.Threshold = (int)Remap(threshold,0,100);
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Blur";
        }

        #endregion

    }
}