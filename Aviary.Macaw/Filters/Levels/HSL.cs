using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Af = Accord.Imaging.Filters;
using Wd = Aviary.Wind.Mathematics;

namespace Aviary.Macaw.Filters.Levels
{
    public class HSL : Filter
    {

        #region members

        protected Wd.Domain luminanceIn = new Wd.Domain(0, 1);
        protected Wd.Domain luminanceOut = new Wd.Domain(0, 1);
        protected Wd.Domain saturationIn = new Wd.Domain(0, 1);
        protected Wd.Domain saturationOut = new Wd.Domain(0, 1);


        #endregion

        #region constructors

        public HSL() : base()
        {

            SetFilter();
        }

        public HSL(Wd.Domain saturationIn, Wd.Domain saturationOut, Wd.Domain luminanceIn, Wd.Domain luminanceOut) : base()
        {
            this.luminanceIn = luminanceIn;
            this.luminanceOut = luminanceOut;
            this.saturationIn = saturationIn;
            this.saturationOut = saturationOut;

            SetFilter();
        }

        public HSL(HSL filter) : base(filter)
        {
            this.luminanceIn = filter.luminanceIn;
            this.luminanceOut = filter.luminanceOut;
            this.saturationIn = filter.saturationIn;
            this.saturationOut = filter.saturationOut;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Wd.Domain LuminanceIn
        {
            get { return luminanceIn; }
            set
            {
                luminanceIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain LuminanceOut
        {
            get { return luminanceOut; }
            set
            {
                luminanceOut = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain SaturationIn
        {
            get { return saturationIn; }
            set
            {
                saturationIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain SaturationOut
        {
            get { return saturationOut; }
            set
            {
                saturationOut = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.HSLLinear newFilter = new Af.HSLLinear();
            newFilter.InLuminance = luminanceIn.ToRange();
            newFilter.OutLuminance = luminanceOut.ToRange();
            newFilter.InSaturation = saturationIn.ToRange();
            newFilter.OutSaturation= saturationOut.ToRange();
            imageFilter = newFilter;
        }

        #endregion

    }
}
