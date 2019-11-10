using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Af = Accord.Imaging.Filters;
using Wd = Aviary.Wind.Mathematics;

namespace Aviary.Macaw.Filters.Levels
{
    public class RGB16 : Filter
    {

        #region members

        protected Wd.Domain redIn = new Wd.Domain(0, 255);
        protected Wd.Domain redOut = new Wd.Domain(0, 255);
        protected Wd.Domain greenIn = new Wd.Domain(0, 255);
        protected Wd.Domain greenOut = new Wd.Domain(0, 255);
        protected Wd.Domain blueIn = new Wd.Domain(0, 255);
        protected Wd.Domain blueOut = new Wd.Domain(0, 255);


        #endregion

        #region constructors

        public RGB16() : base()
        {

            SetFilter();
        }

        public RGB16(Wd.Domain redIn, Wd.Domain redOut, Wd.Domain greenIn, Wd.Domain greenOut, Wd.Domain blueIn, Wd.Domain blueOut) : base()
        {
            this.redIn = redIn;
            this.redOut = redOut;
            this.greenIn = greenIn;
            this.greenOut = greenOut;
            this.blueIn = blueIn;
            this.blueOut = blueOut;

            SetFilter();
        }

        public RGB16(RGB16 filter) : base(filter)
        {
            this.redIn = filter.redIn;
            this.redOut = filter.redOut;
            this.greenIn = filter.greenIn;
            this.greenOut = filter.greenOut;
            this.blueIn = filter.blueIn;
            this.blueOut = filter.blueOut;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Wd.Domain RedIn
        {
            get { return redIn; }
            set
            {
                redIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain RedOut
        {
            get { return redOut; }
            set
            {
                redOut = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain GreenIn
        {
            get { return greenIn; }
            set
            {
                greenIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain GreenOut
        {
            get { return greenOut; }
            set
            {
                greenOut = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain BlueIn
        {
            get { return blueIn; }
            set
            {
                blueIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain BlueOut
        {
            get { return blueOut; }
            set
            {
                blueOut = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.LevelsLinear16bpp newFilter = new Af.LevelsLinear16bpp();
            newFilter.InRed = redIn.ToIntRange();
            newFilter.OutRed = redOut.ToIntRange();
            newFilter.InGreen = greenIn.ToIntRange();
            newFilter.OutGreen = greenOut.ToIntRange();
            newFilter.InBlue = blueIn.ToIntRange();
            newFilter.OutBlue = blueOut.ToIntRange();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: RGB16 Levels";
        }

        #endregion

    }
}
