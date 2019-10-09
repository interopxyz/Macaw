using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Ripple : Filter
    {

        #region members

        protected int horizontalAmplitude = 1;
        protected int horizontalCount = 10;
        protected int verticalAmplitude = 1;
        protected int verticalCount = 10;

        #endregion

        #region constructors

        public Ripple() : base()
        {
            SetFilter();
        }

        public Ripple(int horizontalAmplitude, int horizontalCount, int verticalAmplitude, int verticalCount) : base()
        {
            this.horizontalAmplitude = horizontalAmplitude;
            this.horizontalCount = horizontalCount;
            this.verticalAmplitude = verticalAmplitude;
            this.verticalCount = verticalCount;
            SetFilter();
        }

        public Ripple(Ripple filter) : base(filter)
        {
            this.horizontalAmplitude = filter.horizontalAmplitude;
            this.horizontalCount = filter.horizontalCount;
            this.verticalAmplitude = filter.verticalAmplitude;
            this.verticalCount = filter.verticalCount;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int HorizontalAmplitude
        {
            get { return horizontalAmplitude; }
            set
            {
                horizontalAmplitude = value;
                SetFilter();
            }
        }

        public virtual int HorizontalCount
        {
            get { return horizontalCount; }
            set
            {
                horizontalCount = value;
                SetFilter();
            }
        }

        public virtual int VerticalAmplitude
        {
            get { return verticalAmplitude; }
            set
            {
                verticalAmplitude = value;
                SetFilter();
            }
        }

        public virtual int VerticalCount
        {
            get { return verticalCount; }
            set
            {
                verticalCount = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.WaterWave newFilter = new Af.WaterWave();
            newFilter.HorizontalWavesAmplitude = horizontalAmplitude;
            newFilter.HorizontalWavesCount = horizontalCount;
            newFilter.VerticalWavesAmplitude = verticalAmplitude;
            newFilter.VerticalWavesCount = verticalCount;
            imageFilter = newFilter;
        }

        #endregion

    }
}