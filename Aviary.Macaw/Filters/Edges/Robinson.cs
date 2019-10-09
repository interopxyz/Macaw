using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Edges
{
    public class Robinson : Filter
    {

        #region members



        #endregion

        #region constructors

        public Robinson() : base()
        {
            SetFilter();
        }

        public Robinson(Robinson filter) : base(filter)
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
            Af.RobinsonEdgeDetector newFilter = new Af.RobinsonEdgeDetector();
            imageFilter = newFilter;
        }

        #endregion

    }
}