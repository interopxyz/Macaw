using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Grayscale
{
    public class GrayscaleY : Filter
    {

        #region members



        #endregion

        #region constructors

        public GrayscaleY() : base()
        {
            SetFilter();
        }

        public GrayscaleY(GrayscaleY filter) : base(filter)
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
            Af.Grayscale newFilter = Af.Grayscale.CommonAlgorithms.Y;
            
            imageFilter = newFilter;
        }

        #endregion

    }
}
