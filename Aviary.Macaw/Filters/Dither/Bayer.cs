using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Dither
{
    public class Bayer : Filter
    {

        #region members



        #endregion

        #region constructors

        public Bayer() : base()
        {
            SetFilter();
        }

        public Bayer(Bayer filter) : base(filter)
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
            Af.BayerDithering newFilter = new Af.BayerDithering();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Dither Bayer";
        }

        #endregion

    }
}