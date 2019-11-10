using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Af = Accord.Imaging.Filters;
using Wd = Aviary.Wind.Mathematics;

namespace Aviary.Macaw.Filters.Levels
{
    public class YCbCr : Filter
    {

        #region members

        protected Wd.Domain yIn = new Wd.Domain(0, 1);
        protected Wd.Domain yOut = new Wd.Domain(0, 1);
        protected Wd.Domain cbIn = new Wd.Domain(0, 1);
        protected Wd.Domain cbOut = new Wd.Domain(0, 1);
        protected Wd.Domain crIn = new Wd.Domain(0, 1);
        protected Wd.Domain crOut = new Wd.Domain(0, 1);
        
        #endregion

        #region constructors

        public YCbCr() : base()
        {

            SetFilter();
        }

        public YCbCr(Wd.Domain yIn, Wd.Domain yOut, Wd.Domain cbIn, Wd.Domain cbOut, Wd.Domain crIn, Wd.Domain crOut) : base()
        {
            this.yIn = yIn;
            this.yOut = yOut;
            this.cbIn = cbIn;
            this.cbOut = cbOut;
            this.crIn = crIn;
            this.crOut = crOut;

            SetFilter();
        }

        public YCbCr(YCbCr filter) : base(filter)
        {
            this.yIn = filter.yIn;
            this.yOut = filter.yOut;
            this.cbIn = filter.cbIn;
            this.cbOut = filter.cbOut;
            this.crIn = filter.crIn;
            this.crOut = filter.crOut;

            SetFilter();
        }

        #endregion

        #region properties

        public virtual Wd.Domain YIn
        {
            get { return yIn; }
            set
            {
                yIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain YOut
        {
            get { return yOut; }
            set
            {
                yOut = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain CbIn
        {
            get { return cbIn; }
            set
            {
                cbIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain CbOut
        {
            get { return cbOut; }
            set
            {
                cbOut = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain CrIn
        {
            get { return crIn; }
            set
            {
                crIn = value;
                SetFilter();
            }
        }

        public virtual Wd.Domain CrOut
        {
            get { return crOut; }
            set
            {
                crOut = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.YCbCrLinear newFilter = new Af.YCbCrLinear();
            newFilter.InY = yIn.ToIntRange(0,255);
            newFilter.OutY = yOut.ToIntRange(0, 255);
            newFilter.InCb = cbIn.ToIntRange(0, 255);
            newFilter.OutCb = cbOut.ToIntRange(0, 255);
            newFilter.InCr = crIn.ToIntRange(0, 255);
            newFilter.OutCr = crOut.ToIntRange(0, 255);
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: YCbCr Levels";
        }

        #endregion

    }
}
