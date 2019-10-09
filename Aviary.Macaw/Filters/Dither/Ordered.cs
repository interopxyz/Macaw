using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Dither
{
    public class Ordered : Filter
    {

        #region members



        #endregion

        #region constructors

        public Ordered() : base()
        {
            SetFilter();
        }

        public Ordered(Ordered filter) : base(filter)
        {
            SetFilter();
        }

        #endregion

        #region properties



        #endregion

        #region methods

        private void SetFilter()
        {
            ImageType = ImageTypes.GrayscaleBT709;
            Af.OrderedDithering newFilter = new Af.OrderedDithering();
            imageFilter = newFilter;
        }

        #endregion

    }
}