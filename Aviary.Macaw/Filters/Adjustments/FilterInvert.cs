using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterInvert : Filter
    {

        #region members



        #endregion

        #region constructors

        public FilterInvert() : base()
        {
            SetFilter();
        }

        public FilterInvert(FilterInvert filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties
        


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb24bpp;
            Invert newFilter = new Invert();
            imageFilter = newFilter;
        }

        #endregion

    }
}
