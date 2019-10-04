using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterSaltPepper : Filter
    {

        #region members

        protected double noise = 0;

        #endregion

        #region constructors

        public FilterSaltPepper() : base()
        {
            SetFilter();
        }

        public FilterSaltPepper(int noise) : base()
        {
            this.noise = noise;
            SetFilter();
        }

        public FilterSaltPepper(FilterSaltPepper filter) : base(filter)
        {
            this.noise = filter.noise;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual double Noise
        {
            get { return noise; }
            set
            {
                noise = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            SaltAndPepperNoise newFilter = new SaltAndPepperNoise();
            newFilter.NoiseAmount = noise;
            imageFilter = newFilter;
        }

        #endregion

    }
}