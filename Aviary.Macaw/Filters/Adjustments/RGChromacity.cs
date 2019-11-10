using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class RGChromacity : Filter
    {

        #region members
        

        #endregion

        #region constructors

        public RGChromacity() : base()
        {
            SetFilter();
        }

        public RGChromacity(RGChromacity filter) : base(filter)
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
            Af.RGChromacity newFilter = new Af.RGChromacity();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: RGB Chromacity";
        }

        #endregion

    }
}
