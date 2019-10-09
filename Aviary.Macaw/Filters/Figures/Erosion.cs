using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class Erosion : Filter
    {

        #region members


        #endregion

        #region constructors

        public Erosion() : base()
        {
            SetFilter();
        }


        public Erosion(Erosion filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties



        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.Rgb48bpp;
            Af.Erosion newFilter = new Af.Erosion();
            imageFilter = newFilter;
        }

        #endregion

    }
}