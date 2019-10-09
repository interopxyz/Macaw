using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af=Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Smoothing
{
    public class Bilateral : Filter
    {

        #region members

        protected int colorFactor = 1;
        protected int colorPower = 1;
        protected int spatialFactor = 1;
        protected int spatialPower = 1;

        #endregion

        #region constructors

        public Bilateral() : base()
        {
            SetFilter();
        }

        public Bilateral(int colorFactor, int colorPower, int spatialFactor, int spatialPower) : base()
        {
            this.colorFactor = colorFactor;
            this.colorPower = colorPower;
            this.spatialFactor = spatialFactor;
            this.spatialPower = spatialPower;
            SetFilter();
        }

        public Bilateral(Bilateral filter) : base(filter)
        {
            this.colorFactor = filter.colorFactor;
            this.colorPower = filter.colorPower;
            this.spatialFactor = filter.spatialFactor;
            this.spatialPower = filter.spatialPower;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int ColorFactor
        {
            get { return colorFactor; }
            set
            {
                colorFactor = value;
                SetFilter();
            }
        }

        public virtual int ColorPower
        {
            get { return colorPower; }
            set
            {
                colorPower = value;
                SetFilter();
            }
        }

        public virtual int SpatialFactor
        {
            get { return spatialFactor; }
            set
            {
                spatialFactor = value;
                SetFilter();
            }
        }

        public virtual int SpatialPower
        {
            get { return spatialPower; }
            set
            {
                spatialPower = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.BilateralSmoothing newFilter = new Af.BilateralSmoothing();
            newFilter.ColorFactor = colorFactor;
            newFilter.ColorPower = colorPower;
            newFilter.SpatialFactor = spatialFactor;
            newFilter.SpatialPower = spatialPower;
            imageFilter = newFilter;
        }

        #endregion

    }
}
