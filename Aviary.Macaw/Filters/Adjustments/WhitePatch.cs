using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class WhitePatch : Filter
    {

        #region members



        #endregion

        #region constructors

        public WhitePatch() : base()
        {
            SetFilter();
        }

        public WhitePatch(WhitePatch filter) : base(filter)
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
            Af.WhitePatch newFilter = new Af.WhitePatch();
            imageFilter = newFilter;
        }

        #endregion

    }
}
