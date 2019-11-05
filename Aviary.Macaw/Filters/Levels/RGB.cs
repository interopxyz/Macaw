using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Af = Accord.Imaging.Filters;
using Wd = Aviary.Wind.Mathematics;

namespace Aviary.Macaw.Filters.Levels
{
    public class RGB : Filter
    {

        #region members

        protected Wd.Domain redIn = new Wd.Domain(0, 1);
        protected Wd.Domain redOut = new Wd.Domain(0, 1);
        protected Wd.Domain greenIn = new Wd.Domain(0, 1);
        protected Wd.Domain greenOut = new Wd.Domain(0, 1);
        protected Wd.Domain blueIn = new Wd.Domain(0, 1);
        protected Wd.Domain blueOut = new Wd.Domain(0, 1);


        #endregion

        #region constructors

        public RGB() : base()
        {

            SetFilter();
        }

        public RGB(Wd.Domain redIn, Wd.Domain redOut, Wd.Domain greenIn, Wd.Domain greenOut, Wd.Domain blueIn, Wd.Domain blueOut) : base()
        {
            this.redIn = redIn;
            this.redOut = redOut;
            this.greenIn = greenIn;
            this.greenOut = greenOut;
            this.blueIn = blueIn;
            this.blueOut = blueOut;

            SetFilter();
        }

        public RGB(RGB filter) : base(filter)
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
            Af.LevelsLinear newFilter = new Af.LevelsLinear();
            newFilter.InRed = redIn.ToIntRange(0,255);
            newFilter.OutRed = redOut.ToIntRange(0, 255);
            newFilter.InGreen = greenIn.ToIntRange(0, 255);
            newFilter.OutGreen = greenOut.ToIntRange(0, 255);
            newFilter.InBlue = blueIn.ToIntRange(0, 255);
            newFilter.OutBlue = blueOut.ToIntRange(0, 255);
            imageFilter = newFilter;
        }

        #endregion

    }
}
