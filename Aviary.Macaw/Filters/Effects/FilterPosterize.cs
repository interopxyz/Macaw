using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterPosterize : Filter
    {

        #region members

        protected int type = 0;
        protected int interval = 1;

        #endregion

        #region constructors

        public FilterPosterize() : base()
        {
            SetFilter();
        }

        public FilterPosterize(int type, int interval) : base()
        {
            this.type = type;
            this.interval = interval;
            SetFilter();
        }

        public FilterPosterize(FilterPosterize filter) : base(filter)
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
            SimplePosterization newFilter = new SimplePosterization();
            newFilter.FillingType = (SimplePosterization.PosterizationFillingType) type;
            newFilter.PosterizationInterval = (byte)interval;
            imageFilter = newFilter;
        }

        #endregion

    }
}