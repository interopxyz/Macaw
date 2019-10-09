using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class GrayWorld : Filter
    {

        #region members



        #endregion

        #region constructors

        public GrayWorld() : base()
        {
            SetFilter();
        }

        public GrayWorld(GrayWorld filter) : base(filter)
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
            Af.GrayWorld newFilter = new Af.GrayWorld();
            imageFilter = newFilter;
        }

        #endregion

    }
}
