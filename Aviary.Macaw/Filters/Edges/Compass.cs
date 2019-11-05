using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Compass : Filter
    {

        #region members



        #endregion

        #region constructors

        public Compass() : base()
        {
            SetFilter();
        }

        public Compass(Difference filter) : base(filter)
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
            //Af.CompassConvolution newFilter = new Af.CompassConvolution();
            //imageFilter = newFilter;
        }

        #endregion

    }
}