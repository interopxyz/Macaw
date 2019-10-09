using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class HatBottom : Filter
    {

        #region members


        #endregion

        #region constructors

        public HatBottom() : base()
        {
            SetFilter();
        }


        public HatBottom(HatBottom filter) : base(filter)
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
            Af.BottomHat newFilter = new Af.BottomHat();
            imageFilter = newFilter;
        }

        #endregion

    }
}