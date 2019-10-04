using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
{
    public class FilterGrayWorld : Filter
    {

        #region members



        #endregion

        #region constructors

        public FilterGrayWorld() : base()
        {
            SetFilter();
        }

        public FilterGrayWorld(FilterGrayWorld filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties
        


        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb32bpp;
            GrayWorld newFilter = new GrayWorld();
            imageFilter = newFilter;
        }

        #endregion

    }
}
