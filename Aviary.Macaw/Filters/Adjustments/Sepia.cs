using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Sepia : Filter
    {

        #region members



        #endregion

        #region constructors

        public Sepia() : base()
        {
            SetFilter();
        }

        public Sepia(Sepia filter) : base(filter)
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
            Af.Sepia newFilter = new Af.Sepia();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Sepia";
        }

        #endregion

    }
}
