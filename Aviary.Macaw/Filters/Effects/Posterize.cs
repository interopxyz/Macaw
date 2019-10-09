using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class Posterize : Filter
    {

        #region members

        protected int type = 0;
        protected int interval = 1;

        #endregion

        #region constructors

        public Posterize() : base()
        {
            SetFilter();
        }

        public Posterize(int type, int interval) : base()
        {
            this.type = type;
            this.interval = interval;
            SetFilter();
        }

        public Posterize(Posterize filter) : base(filter)
        {
            this.type = filter.type;
            this.interval = filter.interval;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Type
        {
            get { return type; }
            set
            {
                type = value%3;
                SetFilter();
            }
        }

        public virtual int Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            Af.SimplePosterization newFilter = new Af.SimplePosterization();
            newFilter.FillingType = (Af.SimplePosterization.PosterizationFillingType) type;
            newFilter.PosterizationInterval = (byte)interval;
            imageFilter = newFilter;
        }

        #endregion

    }
}