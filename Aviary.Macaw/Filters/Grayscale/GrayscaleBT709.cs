using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Grayscale
{
    public class GrayscaleBT709 : Filter
    {

        #region members



        #endregion

        #region constructors

        public GrayscaleBT709() : base()
        {
            SetFilter();
        }

        public GrayscaleBT709(GrayscaleBT709 filter) : base(filter)
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
            Af.Grayscale newFilter = Af.Grayscale.CommonAlgorithms.BT709;

            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: BT709 Grayscale";
        }

        #endregion

    }
}
