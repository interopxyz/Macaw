using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Grayscale
{
    public class GrayscaleRMY : Filter
    {

        #region members



        #endregion

        #region constructors

        public GrayscaleRMY() : base()
        {
            SetFilter();
        }

        public GrayscaleRMY(GrayscaleRMY filter) : base(filter)
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
            Af.Grayscale newFilter = Af.Grayscale.CommonAlgorithms.RMY;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: RMY Grayscale";
        }

        #endregion

    }
}
