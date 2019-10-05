using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
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
            ImageType = ImageTypes.Rgb32bpp;
            Accord.Imaging.Filters.GrayWorld newFilter = new Accord.Imaging.Filters.GrayWorld();
            imageFilter = newFilter;
        }

        #endregion

    }
}
