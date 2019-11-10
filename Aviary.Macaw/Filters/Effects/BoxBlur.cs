using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Effects
{
    public class BoxBlur : Filter
    {

        #region members

        protected int horizontal = 3;
        protected int vertical = 3;

        #endregion

        #region constructors

        public BoxBlur() : base()
        {
            SetFilter();
        }

        public BoxBlur(int horizontal, int vertical) : base()
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
            SetFilter();
        }

        public BoxBlur(BoxBlur filter) : base(filter)
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
            Af.FastBoxBlur newFilter = new Af.FastBoxBlur();
            newFilter.HorizontalKernelSize = (byte)horizontal;
            newFilter.VerticalKernelSize = (byte)vertical;
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Box Blur";
        }

        #endregion

    }
}