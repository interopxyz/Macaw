using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters
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
            Accord.Imaging.Filters.Invert newFilter = new Accord.Imaging.Filters.Invert();
            imageFilter = newFilter;
        }

        #endregion

    }
}
