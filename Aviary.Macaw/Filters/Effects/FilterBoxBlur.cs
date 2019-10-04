using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterBoxBlur : Filter
    {

        #region members

        protected int horizontal = 3;
        protected int vertical = 3;

        #endregion

        #region constructors

        public FilterBoxBlur() : base()
        {
            SetFilter();
        }

        public FilterBoxBlur(int horizontal, int vertical) : base()
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
            SetFilter();
        }

        public FilterBoxBlur(FilterBoxBlur filter) : base(filter)
        {
            this.horizontal = filter.horizontal;
            this.vertical = filter.vertical;
            SetFilter();
        }

        #endregion

        #region properties

        public virtual int Horizontal
        {
            get { return horizontal; }
            set
            {
                horizontal = value;
                SetFilter();
            }
        }

        public virtual int Vertical
        {
            get { return vertical; }
            set
            {
                vertical = value;
                SetFilter();
            }
        }

        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            FastBoxBlur newFilter = new FastBoxBlur();
            newFilter.HorizontalKernelSize = (byte)horizontal;
            newFilter.VerticalKernelSize = (byte)vertical;
            imageFilter = newFilter;
        }

        #endregion

    }
}