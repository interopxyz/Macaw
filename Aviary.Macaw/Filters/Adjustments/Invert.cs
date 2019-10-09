using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Adjustments
{
    public class Invert : Filter
    {

        #region members



        #endregion

        #region constructors

        public Invert() : base()
        {
            SetFilter();
        }

        public Invert(Invert filter) : base(filter)
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
            Af.Invert newFilter = new Af.Invert();
            imageFilter = newFilter;
        }

        #endregion

    }
}
