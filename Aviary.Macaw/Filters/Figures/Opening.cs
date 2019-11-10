using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Af = Accord.Imaging.Filters;

namespace Aviary.Macaw.Filters.Figures
{
    public class Opening : Filter
    {

        #region members


        #endregion

        #region constructors

        public Opening() : base()
        {
            SetFilter();
        }


        public Opening(Opening filter) : base(filter)
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
            Af.Opening newFilter = new Af.Opening();
            imageFilter = newFilter;
        }

        #endregion

        #region override

        public override string ToString()
        {
            return "Filter: Opening";
        }

        #endregion

    }
}