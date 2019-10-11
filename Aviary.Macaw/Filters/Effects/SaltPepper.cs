using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class SaltPepper : Filter
    {

        #region members

        protected double noise = 0;

        #endregion

        #region constructors

        public SaltPepper() : base()
        {
            SetFilter();
        }

        public SaltPepper(double noise) : base()
        {
            this.noise = noise;
            SetFilter();
        }

        public SaltPepper(SaltPepper filter) : base(filter)
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
            Af.SaltAndPepperNoise newFilter = new Af.SaltAndPepperNoise();
            newFilter.NoiseAmount = Remap(noise,0,100);
            imageFilter = newFilter;
        }

        #endregion

    }
}