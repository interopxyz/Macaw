using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterWhitePatch : Filter
    {

        #region members



        #endregion

        #region constructors

        public FilterWhitePatch() : base()
        {
            SetFilter();
        }

        public FilterWhitePatch(FilterWhitePatch filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties
        


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.None;
            WhitePatch newFilter = new WhitePatch();
            imageFilter = newFilter;
        }

        #endregion

    }
}
