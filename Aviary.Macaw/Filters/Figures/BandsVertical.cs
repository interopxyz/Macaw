using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class BandsVertical : Filter
    {

        #region members

        protected int gap = 10;
        protected bool borders = false;

        #endregion

        #region constructors

        public BandsVertical() : base()
        {
            SetFilter();
        }

        public BandsVertical(int gap, bool borders) : base()
        {
            this.gap = gap;
            this.borders = borders;

            SetFilter();
        }

        public BandsVertical(BandsVertical filter) : base(filter)
        {
            this.gap = filter.gap;
            this.borders = filter.borders;

            SetFilter();
        }

        #endregion

        #region properties
        
        public virtual int Gap
        {
            get { return gap; }
            set
            {
                gap = value;
                SetFilter();
            }
        }

        public virtual bool Borders
        {
            get { return borders; }
            set
            {
                borders = value;
                SetFilter();
            }
        }


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Af.VerticalRunLengthSmoothing newFilter = new Af.VerticalRunLengthSmoothing();
            newFilter.MaxGapSize = gap;
            newFilter.ProcessGapsWithImageBorders = borders;
            imageFilter = newFilter;
        }

        #endregion

    }
}